using System.Collections;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField, Tooltip("")] private Animator animator;

    [SerializeField, Tooltip("The state that the enemy is in, used for determining player losing")] private EnemyState currentState=EnemyState.NormalChase;
    [SerializeField,Tooltip("After time passes the enemy will return to its normal chase")] private float stateRegenRate=6;
    [SerializeField, Tooltip("The position that the enemy will be when the player is nearing failure")] private Transform playerCloseChaseRange;
    [SerializeField, Tooltip("The position that the enemy will be when the player is doing okay, should be off screen")] private Transform playerNormalChaseRange;
    [SerializeField, Tooltip("The position that the enemy needs to be when performing a finisher on the player")] private Transform playerUppercutRange;
    [SerializeField, Tooltip("How long it takes to reach the position")] private float transitionSpeedOfChase= 0.005f;
    [SerializeField, Tooltip("How long it takes to reach the position")] private float transitionSpeedOfUppercut = 0.01f;
    [SerializeField, Tooltip("How long it takes for an animation to play, these are copies of the player")] private float delayTime=0.25f;
    private float stateSwapTimeStamp;

    //the animation that will be played after a delay
    private string nextAnimationToPlay="empty";

    //used for when the enemy starts its uppercut on the palyer
    private bool finisherStarted=false;

    private void OnEnable()
    {
        EventManager.currentManager.Subscribe(EventType.PlayerHitObstacle, OnPlayerHitObject);
        EventManager.currentManager.Subscribe(EventType.PlayerDodged, OnPlayerDodged);
        EventManager.currentManager.Subscribe(EventType.PlayerJumped, OnPlayerJumped);
        EventManager.currentManager.Subscribe(EventType.PlayerSlided, OnPlayerSlided);
        EventManager.currentManager.Subscribe(EventType.PlayerUppercutted, OnPlayerUppercutted);
    }

    private void OnDisable()
    {
        EventManager.currentManager.Unsubscribe(EventType.PlayerHitObstacle, OnPlayerHitObject);
        EventManager.currentManager.Unsubscribe(EventType.PlayerDodged, OnPlayerDodged);
        EventManager.currentManager.Unsubscribe(EventType.PlayerJumped, OnPlayerJumped);
        EventManager.currentManager.Unsubscribe(EventType.PlayerSlided, OnPlayerSlided);
        EventManager.currentManager.Unsubscribe(EventType.PlayerUppercutted, OnPlayerUppercutted);
    }

    private void FixedUpdate()
    {
        HandleStateSwapping();
        HandleEnemyRange();
    }

    private void HandleStateSwapping()
    {
        //if the enemy is close to the player and the state has reached its regeneration point
        if (currentState==EnemyState.CloseChase && stateSwapTimeStamp<=Time.time)
        {
            currentState = EnemyState.NormalChase;
        }
    }

    private void HandleEnemyRange()
    {
        Vector3 newPosition = transform.position;
        //Changes the enemies position based on the players performance
        switch (currentState)
        {
            //Be off screen
            case EnemyState.NormalChase:
                newPosition = Vector3.Slerp(transform.position, playerNormalChaseRange.position, transitionSpeedOfChase);
                break;
            //Be behind the player
            case EnemyState.CloseChase:
                newPosition = Vector3.Slerp(transform.position, playerCloseChaseRange.position, transitionSpeedOfChase);
                break;
            //Knock the player out
            case EnemyState.Caught:
                newPosition = Vector3.Slerp(transform.position, playerUppercutRange.position, transitionSpeedOfUppercut);
                break;
        }
        if(!finisherStarted)
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        animator.Play(nextAnimationToPlay);
    }

    #region On Events

    private void OnPlayerHitObject(EventData eventData)
    {
        if (eventData is PlayerHitObstacle)
        {
            switch (currentState)
            {
                case EnemyState.NormalChase:
                    currentState = EnemyState.CloseChase;
                    stateSwapTimeStamp = Time.time + stateRegenRate;
                    break;
                case EnemyState.CloseChase:
                    currentState = EnemyState.Caught;

                    Debug.Log("You lose");
                    EventManager.currentManager.AddEvent(new GameOver());
                    break;
            }
        }
        else
        {
            Debug.LogWarning("The given EventData PlayerHitObstacle does not match the type of EventType.PlayerHitObstacle");
        }
    }

    private void OnPlayerDodged(EventData eventData)
    {
        if (eventData is PlayerDodged playerDodged)
        {
            if (playerDodged.dodgingRight)
            {
                nextAnimationToPlay = "DodgeRight";
                StartCoroutine(ExecuteAfterTime(delayTime));
            }
            else
            {
                nextAnimationToPlay = "DodgeLeft";
                StartCoroutine(ExecuteAfterTime(delayTime));
            }
        }
        else
        {
            Debug.LogWarning("The given EventData PlayerDodged does not match the type of EventType.PlayerDodged");
        }
    }

    private void OnPlayerSlided(EventData eventData)
    {
        if (eventData is PlayerSlided)
        {
            nextAnimationToPlay = "Slide";
            StartCoroutine(ExecuteAfterTime(delayTime));
        }
        else
        {
            Debug.LogWarning("The given EventData PlayerSlided does not match the type of EventType.PlayerSlided");
        }
    }

    private void OnPlayerJumped(EventData eventData)
    {
        if (eventData is PlayerJumped)
        {
            nextAnimationToPlay = "Jump";
            StartCoroutine(ExecuteAfterTime(delayTime));
        }
        else
        {
            Debug.LogWarning("The given EventData PlayerJumped does not match the type of EventType.PlayerJumped");
        }
    }

    private void OnPlayerUppercutted(EventData eventData)
    {
        if (eventData is PlayerUppercutted)
        {
            finisherStarted = true;
            animator.Play("Uppercut");
        }
        else
        {
            Debug.LogWarning("The given EventData PlayerJumped does not match the type of EventType.PlayerJumped");
        }

    }

    #endregion

    public enum EnemyState
    {
        NormalChase,
        CloseChase,
        Caught
    }
}

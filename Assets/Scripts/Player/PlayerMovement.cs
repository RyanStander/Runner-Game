using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private InputHanlder inputHanlder;
    private PlayerAnimatorManager playerAnimatorManager;

    private float speed, maxSpeed = 2;
    [SerializeField, Range(0, 1),Tooltip("The amount of speed the player picks up over time")] private float speedIncrease=0.1f;

    [Header("Lane data")]
    [SerializeField] private Lane currentLane=Lane.Middle;
    [SerializeField] private float transitionSpeed=0.005f;
    [SerializeField] private float midLaneXValue = 0;
    [SerializeField] private float rightLaneXValue=2;
    [SerializeField] private float leftLaneXValue=-2;

    [Header("Falling ralated Data")]
    private float fallDuration;
    [SerializeField] private float fallDurationToPerformLand = 0.5f;
    [SerializeField] private LayerMask EnvironmentLayer;
    [SerializeField] private Vector3 raycastOffset;
    [SerializeField] private float groundCheckRadius = 0.3f;
    private void Awake()
    {
        FindComponents();
    }

    internal void HandleMovement(bool isInteracting)
    {
        HandleFalling();
        //Use to avoid player from performing an action if they are already performing another action
        if (!isInteracting)
        {
            MoveForward();
            LeftRightMovement();
            JumpSlideMovement();
        }
    }

    private void MoveForward()
    {
        if (speed<maxSpeed)
            speed += speedIncrease;
        else if (speed>maxSpeed)
            speed = maxSpeed;

        //move player forward
        playerAnimatorManager.animator.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
        //slow player speed if something happens (slowed, runs into object)
    }

    private void LeftRightMovement()
    {
        //moving left
        if (inputHanlder.moveLeft)
        {
            //check if player can move left
            switch (currentLane)
            {
                case Lane.Left:
                    //No space to move left
                    break;
                case Lane.Middle:
                    playerAnimatorManager.PlayTargetAnimation("DodgeLeft");
                    EventManager.currentManager.AddEvent(new PlayerDodged(false));
                    currentLane = Lane.Left;
                    break;
                case Lane.Right:
                    playerAnimatorManager.PlayTargetAnimation("DodgeLeft");
                    EventManager.currentManager.AddEvent(new PlayerDodged(false));
                    currentLane = Lane.Middle;
                    break;
            }
        }

        //moving right
        if (inputHanlder.moveRight)
        {
            //check if player can move right
            switch (currentLane)
            {
                case Lane.Left:
                    playerAnimatorManager.PlayTargetAnimation("DodgeRight");
                    EventManager.currentManager.AddEvent(new PlayerDodged(true));
                    currentLane = Lane.Middle;
                    break;
                case Lane.Middle:
                    playerAnimatorManager.PlayTargetAnimation("DodgeRight");
                    EventManager.currentManager.AddEvent(new PlayerDodged(true));
                    currentLane = Lane.Right;
                    break;
                case Lane.Right:
                    //No space to move right
                    break;
            }
        }
    }

    internal void HandleLanePosition()
    {
        float newXValue = 0;
        //Set x to current lane
        switch (currentLane)
        {
            case Lane.Left:
                newXValue = leftLaneXValue;
                break;
            case Lane.Middle:
                newXValue = midLaneXValue;
                break;
            case Lane.Right:
                newXValue = rightLaneXValue;
                break;
        }

        Vector3 newPosition = new Vector3(newXValue, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, transitionSpeed);
    }

    private void JumpSlideMovement()
    {
        //jump
        if (inputHanlder.jumpInput)
        {
            playerAnimatorManager.PlayTargetAnimation("Jump");
            EventManager.currentManager.AddEvent(new PlayerJumped());
        }

        //slide
        if (inputHanlder.slideInput)
        {
            playerAnimatorManager.PlayTargetAnimation("Slide");
            EventManager.currentManager.AddEvent(new PlayerSlided());
        }
    }

    /// <summary>
    /// When player collides with an obstacle they will get slowed for a time
    /// </summary>
    internal void CollidedWithObstacle()
    {
        speed = 0;
        playerAnimatorManager.PlayTargetAnimation("Stumble");
    }

    #region Falling
    private void HandleFalling()
    {
        if (!IsGrounded())
        {
            //keeps velocity while falling
            //GetComponent<Rigidbody>().AddForce(new Vector3(previousVelocity.x * 10, 0, previousVelocity.z * 10));

            //count time of falling
            fallDuration += Time.deltaTime;

            //if player is currently doing another action, do not play fall animation,
            //this might need revision
            if (playerAnimatorManager.animator.GetBool("isInteracting"))
                return;

            //play fall animation
            playerAnimatorManager.PlayTargetAnimation("Falling", true);
        }
        else
        {
            //if player is falling for a long time, perform a land animation
            if (fallDuration > fallDurationToPerformLand)
            {
                //play land animation
                //playerAnimatorManager.PlayTargetAnimation("Land", true);
            }
            else if (fallDuration > 0)
            {
                //return to empty state
                //playerAnimatorManager.PlayTargetAnimation("Empty", true);

                fallDuration = 0;
            }
        }
    }

    private bool IsGrounded()
    {
        //Check with a sphere if the player is on the ground, based on outcome, will either be set to being grounded or not
        if (Physics.CheckSphere(transform.position - raycastOffset, groundCheckRadius, EnvironmentLayer))
            return true;
        else
            return false;
    }
    #endregion
    private void FindComponents()
    {
        inputHanlder = GetComponent<InputHanlder>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
    }

    private enum Lane
    {
        Left,
        Middle,
        Right
    }
}

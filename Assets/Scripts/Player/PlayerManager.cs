using UnityEngine;

#region RequiredComponents
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputHanlder))]
[RequireComponent(typeof(PlayerAnimatorManager))]
[RequireComponent(typeof(PlayerMovement))]
#endregion
public class PlayerManager : MonoBehaviour
{
    private InputHanlder inputHanlder;
    private PlayerMovement playerMovement;
    private PlayerAnimatorManager playerAnimatorManager;
    private CapsuleCollider capsuleCollider;

    private bool gameOver = false, gameStarted=false;

    //storing animator viarables
    private bool isInteracting;

    [Header("Collider Dimensions Default")]
    [SerializeField] private Vector3 capsuleCenterValues=new Vector3(0,0.95f,0);
    [SerializeField] private float capsuleRadius= 0.3f;
    [SerializeField] private float capsuleHeight=1.9f;
    [Header("Collider Dimensions Sliding")]
    [SerializeField] private Vector3 capsuleSlideCenterValues = new Vector3(0, 0.95f, 0);
    [SerializeField] private float capsuleSlideRadius = 0.3f;
    [SerializeField] private float capsuleSlideHeight = 1.9f;

    private void OnEnable()
    {
        EventManager.currentManager.Subscribe(EventType.StartGame, OnGameStart);
        EventManager.currentManager.Subscribe(EventType.GameOver, OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.currentManager.Unsubscribe(EventType.StartGame, OnGameStart);
        EventManager.currentManager.Unsubscribe(EventType.GameOver, OnGameOver);
    }

    private void Awake()
    {
        FindComponents();
    }

    private void Start()
    {
        SetupCapsuleCollider();
    }

    private void Update()
    {
        if (!gameStarted)
            return;

        GetPlayerAnimatorVariables();
        if (gameOver)
            return;

        playerMovement.HandleMovement(isInteracting);
    }

    private void FixedUpdate()
    {
        if (!gameStarted)
            return;

        if (gameOver)
        {
            if (!isInteracting)
            {
                playerAnimatorManager.PlayTargetAnimation("Uppercutted");
                EventManager.currentManager.AddEvent(new PlayerUppercutted());
            }
            return;
        }
        playerMovement.HandleLanePosition();
    }

    private void LateUpdate()
    {
        if (!gameStarted)
            return;

        inputHanlder.ResetInputs();
    }

    private void ChangeToSlideColliderValues()
    {
        if (capsuleCollider == null)
            return;
        capsuleCollider.center = capsuleSlideCenterValues;
        capsuleCollider.radius = capsuleSlideRadius;
        capsuleCollider.height = capsuleSlideHeight;
    }

    private void ChangeToDefaultColliderValues()
    {
        if (capsuleCollider == null)
            return;
        capsuleCollider.center = capsuleCenterValues;
        capsuleCollider.radius = capsuleRadius;
        capsuleCollider.height = capsuleHeight;
    }

    #region Setup
    private void SetupCapsuleCollider()
    {
        
        capsuleCollider.center = capsuleCenterValues;
        capsuleCollider.radius = capsuleRadius;
        capsuleCollider.height = capsuleHeight;
    }

    private void FindComponents()
    {
        inputHanlder = GetComponent<InputHanlder>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    #endregion
    private void GetPlayerAnimatorVariables()
    {
        isInteracting = playerAnimatorManager.animator.GetBool("isInteracting");
    }

    #region On Events

    private void OnGameStart(EventData eventData)
    {
        if (eventData is StartGame)
        {
            gameStarted = true;
        }
        else
        {
            Debug.LogWarning("The given EventData StartGame does not match the type of EventType.StartGame");
        }
    }

    private void OnGameOver(EventData eventData)
    {
        if (eventData is GameOver)
        {
            gameOver = true;
        }
        else
        {
            Debug.LogWarning("The given EventData GameOver does not match the type of EventType.GameOver");
        }
    }

    #endregion
}

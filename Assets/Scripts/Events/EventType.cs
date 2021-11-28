//Defines the different event types to be used in event data in enumeration form
public enum EventType 
{
    ReceiveDebug,
    IncreaseScore,
    ExitedObstacle,
    PlayerHitObstacle,

    StartGame,
    GameOver,

    //Events for the enemy
    PlayerDodged,
    PlayerJumped,
    PlayerSlided,
    PlayerUppercutted,
}

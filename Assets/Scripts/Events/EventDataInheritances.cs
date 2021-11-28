//Event that informs subscribers of a debug log
public class SendDebugLog : EventData
{
    public readonly string debuglog;

    public SendDebugLog(string givenLog) : base(EventType.ReceiveDebug)
    {
        debuglog = givenLog;
    }
}

public class IncreaseScore : EventData
{
    public readonly int scoreIncrease;

    public IncreaseScore(int scoreIncrease) : base(EventType.IncreaseScore)
    {
        this.scoreIncrease = scoreIncrease;
    }
}

public class ExitedObstacle : EventData
{
    public ExitedObstacle() : base(EventType.ExitedObstacle)
    {
    }
}

public class PlayerHitObstacle : EventData
{
    public PlayerHitObstacle() : base(EventType.PlayerHitObstacle)
    {

    }
}

public class StartGame : EventData
{
    public StartGame() : base(EventType.StartGame)
    {

    }
}

public class GameOver : EventData
{
    public GameOver() : base(EventType.GameOver)
    {

    }
}

public class PlayerSlided : EventData
{
    public PlayerSlided() : base(EventType.PlayerSlided)
    {

    }
}

public class PlayerJumped : EventData
{
    public PlayerJumped() : base(EventType.PlayerJumped)
    {

    }
}

public class PlayerDodged : EventData
{
    public readonly bool dodgingRight;
    public PlayerDodged(bool dodgingRight) : base(EventType.PlayerDodged)
    {
        this.dodgingRight = dodgingRight;
    }
}

public class PlayerUppercutted : EventData
{
    public PlayerUppercutted() : base(EventType.PlayerUppercutted)
    {

    }
}
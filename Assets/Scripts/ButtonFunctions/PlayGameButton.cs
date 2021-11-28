using UnityEngine;

public class PlayGameButton : MonoBehaviour
{
    public void StartGame()
    {
        EventManager.currentManager.AddEvent(new StartGame());
    }
}

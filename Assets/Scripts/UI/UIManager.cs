using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startUI,inGameUI,endUI;

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

    private void OnGameStart(EventData eventData)
    {
        if (eventData is StartGame)
        {
            startUI.SetActive(false);
            inGameUI.SetActive(true);
            endUI.SetActive(false);
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
            startUI.SetActive(false);
            inGameUI.SetActive(false);
            endUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("The given EventData GameOver does not match the type of EventType.GameOver");
        }
    }
}

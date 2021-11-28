using TMPro;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    private float totalScore;
    private bool gameStarted = false;
    private bool gameOver=false;

    [SerializeField] private float scoreGainMultiplier=1;
    [SerializeField] private TMP_Text scoreDisplayText;
    [SerializeField] private TMP_Text finalScoreDisplayText;

    private void OnEnable()
    {
        EventManager.currentManager.Subscribe(EventType.StartGame, OnGameStart);
        EventManager.currentManager.Subscribe(EventType.IncreaseScore, OnReceiveScoreIncrease);
        EventManager.currentManager.Subscribe(EventType.GameOver, OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.currentManager.Unsubscribe(EventType.StartGame, OnGameStart);
        EventManager.currentManager.Unsubscribe(EventType.IncreaseScore, OnReceiveScoreIncrease);
        EventManager.currentManager.Unsubscribe(EventType.GameOver, OnGameOver);
    }

    private void FixedUpdate()
    {
        if (!gameStarted)
            return;

        if (!gameOver)
            DurationScoreIncrease();
    }

    private void DurationScoreIncrease()
    {
        //increase players score as time goes on
        totalScore += Time.deltaTime * scoreGainMultiplier;

        //update the score text
        if (scoreDisplayText != null)
            scoreDisplayText.text = ((int)totalScore).ToString();
    }

    #region OnEvents

    private void OnReceiveScoreIncrease(EventData eventData)
    {
        if (eventData is IncreaseScore increaseScore)
        {
            if (!gameOver)
                totalScore += increaseScore.scoreIncrease;
        }
        else
        {
            Debug.LogWarning("The given EventData IncreaseScore does not match the type of EventType.IncreaseScore");
        }
    }

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
            finalScoreDisplayText.text = ((int)totalScore).ToString();
        }
        else
        {
            Debug.LogWarning("The given EventData GameOver does not match the type of EventType.GameOver");
        }
    }

    #endregion
}

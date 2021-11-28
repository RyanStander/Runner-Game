using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [SerializeField] private int scoreIncrease = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.currentManager.AddEvent(new IncreaseScore(scoreIncrease));

            Destroy(gameObject);
        }
    }
}

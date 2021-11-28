using UnityEngine;

public class ObstacleSpawnAndDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if colliding with player, send out event to create new obstacle and destroy the old one
        if (other.CompareTag("Player"))
        {
            EventManager.currentManager.AddEvent(new ExitedObstacle());
            Destroy(transform.root.gameObject);
        }
    }
}

using UnityEngine;

public class ObstacleDestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if colliding with the player
        if (collision.transform.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.transform.GetComponent<PlayerMovement>();

            if (playerMovement == null)
                return;

            playerMovement.CollidedWithObstacle();

            EventManager.currentManager.AddEvent(new PlayerHitObstacle());

            Destroy(gameObject);
        }
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "ObstacleSpawnData")]
public class ObstacleSpawnData : ScriptableObject
{

    [Tooltip("The x and z size of the chunk")]
    public Vector2 obstacleSize = new Vector2(10f, 10f);

    [Tooltip("The difficulty that the object represents")]
    public Difficulty assignedDifficulty;

    [Tooltip("The prefab spawned")]
    public GameObject levelObstacle;
}

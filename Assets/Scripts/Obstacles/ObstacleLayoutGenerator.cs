using System.Collections.Generic;
using UnityEngine;

public class ObstacleLayoutGenerator : MonoBehaviour
{

    [Tooltip("The list of objects to be spawned")]
    public ObstacleSpawnData[] obstacleSpawnDatas;
    [Tooltip("The first obstacle to spawn at the start")]
    public ObstacleSpawnData firstObstacle;

    //used to keep data of the previous obstacle
    private ObstacleSpawnData previousObstacle;

    [Tooltip("Where to orient when new pieces are spawned")]
    public Vector3 spawnOrigin;

    //Where new pieces are spawned
    private Vector3 spawnPosition;

    [Tooltip("How many obstacles are spawned initially")]
    public int obstaclesToSpawn = 10;

    Difficulty currentDifficulty = Difficulty.Easy;

    private void OnEnable()
    {
        EventManager.currentManager.Subscribe(EventType.ExitedObstacle, OnExitedObstacle);
    }

    private void OnDisable()
    {
        EventManager.currentManager.Unsubscribe(EventType.ExitedObstacle, OnExitedObstacle);
    }

    private void Start()
    {
        //Set the previous to be the first
        previousObstacle = firstObstacle;

        Instantiate(firstObstacle.levelObstacle, spawnOrigin, Quaternion.identity);

        for (int i = 0; i < obstaclesToSpawn; i++)
        {
            PickAndSpawnObstacle();
        }
    }

    private void Update()
    {
        //Used for debugging
        if (Input.GetKeyDown(KeyCode.T))
        {
            PickAndSpawnObstacle();
        }
    }

    private ObstacleSpawnData PickNextObstacle()
    {
        //create a list of allowed obstacles
        List<ObstacleSpawnData> allowedObstacleList = new List<ObstacleSpawnData>();
        //the next obstacle to check
        ObstacleSpawnData nextObstacle;

        //set the spawn position for the next obstacle to where it should spawn
        spawnPosition.z += previousObstacle.obstacleSize.y;

        //itterate through the data, look for objects that match the current difficulty and add them to the list
        for (int i = 0; i < obstacleSpawnDatas.Length; i++)
        {
            if (obstacleSpawnDatas[i].assignedDifficulty == currentDifficulty)
            {
                allowedObstacleList.Add(obstacleSpawnDatas[i]);
            }
        }

        //pick a random obstacle to spawn
        nextObstacle = allowedObstacleList[Random.Range(0, allowedObstacleList.Count)];

        return nextObstacle;
    }

    private void PickAndSpawnObstacle()
    {
        ObstacleSpawnData obstacleToSpawn = PickNextObstacle();

        //get the prefab of the choses obstacle
        GameObject objectFromObstacle = obstacleToSpawn.levelObstacle;
        previousObstacle = obstacleToSpawn;
        //create it
        Instantiate(objectFromObstacle, spawnPosition + spawnOrigin, Quaternion.identity);
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }

    #region On Events

    private void OnExitedObstacle(EventData eventData)
    {
        if (eventData is ExitedObstacle)
        {
            PickAndSpawnObstacle();
        }
        else
        {
            Debug.LogWarning("The given EventData ExitedObstacle does not match the type of EventType.ExitedObstacle");
        }

        #endregion
    }
}
public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Deathwish
}

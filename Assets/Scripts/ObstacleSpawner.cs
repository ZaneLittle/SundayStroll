using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float x;
    private Dictionary<float, Transform> obstacles;

    public Transform parent;
    public int inverseSpawnRate;    // Denominator of spawn probability
    public float buffer;            // Min time between spawns
    
     private IEnumerator spawn()
     {
        int obstacleNum;
        Transform obstacle;
        KeyValuePair<float, Transform> prefab;

        while (true)
        {
            if (GameplayManager.getGameplay())
            {
                obstacleNum = Random.Range(0, inverseSpawnRate + 3);
                if (obstacleNum < obstacles.Count)
                {
                    prefab =  obstacles.ElementAt(obstacleNum);
                    obstacle = Instantiate
                    (
                        prefab.Value,
                        new Vector3(x, prefab.Key, 0),
                        Quaternion.identity
                    );
                    obstacle.parent = parent;
                    yield return new WaitForSeconds(buffer);
                }
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
     }

    private void Start()
    {
        x = 11.0f;
        inverseSpawnRate = 10;
        buffer = 3.0f;
        // Retrieve obstacles
        obstacles = new Dictionary<float, Transform>();
        obstacles.Add
        (
            -2.3f,
            (Transform)Resources.Load("prefabs/obstacles/GenericObstacle", typeof(Transform))
        );
        obstacles.Add
        (
            -3.65f,
            (Transform)Resources.Load("prefabs/obstacles/GenericObstacle", typeof(Transform))
        );
        obstacles.Add
        (
            -4.65f,
            (Transform)Resources.Load("prefabs/obstacles/HoleObstacle", typeof(Transform))
        );

        StartCoroutine(spawn());
    }
}

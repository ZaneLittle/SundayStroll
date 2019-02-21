using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float x;
    private float[] y;

    public Transform parent;
    public Transform obstaclePrefab;
    public int inverseSpawnRate;    // Denominator of spawn probability
    public float buffer;            // Min time between spawns
    
     private IEnumerator spawn()
     {
        while (true)
        {
            if (GameplayManager.getGameplay())
            {
                int obstacleNum = Random.Range(0, inverseSpawnRate + 3);
                if (obstacleNum < 3)
                {
                    Vector3 position = new Vector3(x, y[obstacleNum], 0);
                    Transform obstacle = Instantiate
                    (
                        obstaclePrefab,
                        position,
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
        y = new float[3] {
            -3.65f, // Head height obstacle
            -2.3f,  // Ground height obstacle
            -4.9f   // Hole obstacle
        };
        inverseSpawnRate = 10;
        buffer = 3.0f;

        StartCoroutine(spawn());
    }
}

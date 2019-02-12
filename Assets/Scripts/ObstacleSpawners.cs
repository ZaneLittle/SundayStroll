using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawners : MonoBehaviour
{
    private float x = 11.0f;
    private float headY = -3.65f;    // Height for the obstacle at head height
    private float groundY = -2.3f;   // Height for ground obstacle
    private float holeY = -5.0f;     // Height for hole obstacle

    public Transform parent;
    public Transform obstaclePrefab;
    public int inverseDifficulty = 500;

    /**
     * Spawns an obstacle and returns the index of the obstacle type:
     * 0 = no obstacle spawned
     * 1 = head height obstacle
     * 2 = ground height obstacle
     * 3 = hole obstacle
     */
    int spawn()
    {
        Vector3 position;
        int obstacleNum = Random.Range(1, inverseDifficulty + 4);
        switch (obstacleNum)
        {
            case 1:
                position = new Vector3(x, headY, 0);
                break;
            case 2:
                position = new Vector3(x, groundY, 0);
                break;
            case 3:
                position = new Vector3(x, holeY, 0);
                break;
            default:
                return 0; // No obstacle spawned
        }
        Transform obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
        obstacle.parent = parent;
        return obstacleNum;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: only spawn overy x seconds
        spawn();
    }
}

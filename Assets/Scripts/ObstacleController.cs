using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float value;        // Value assigned to the obstacle being 'cleared'
    private float boundry;      // X value at which the obstacle is considered 'cleard'

    private void Start()
    {
        value = 10.0f;
        boundry = -10.0f;
    }

    private void Update()
    {
        float xMove = -GameplayManager.getSpeed();
        if (transform.position.x < boundry)
        {
            GameplayManager.increaseScore(value);
            Destroy(gameObject);
        }
        else
        {
            transform.position += new Vector3(xMove, 0, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float speed;    // Movement in the X plane
    private float value;    // Value assigned to the obstacle being 'cleared'
    private float boundry;  // X value at which the obstacle is considered 'cleard'

    private void Start()
    {
        speed = -0.05f;
        value = 10.0f;
        boundry = -10.0f;
    }

    private void Update()
    {
        if (transform.position.x < boundry)
        {
            //ScoreController.instance.incrementScore(value);
            ScoreManager.score += value;
            Destroy(gameObject);
        }
        else
        {
            transform.position += new Vector3(speed, 0, 0);
        }
    }
}

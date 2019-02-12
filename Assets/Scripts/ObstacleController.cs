using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = -0.05f; // Movement in the negative X plane

    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
    }
}

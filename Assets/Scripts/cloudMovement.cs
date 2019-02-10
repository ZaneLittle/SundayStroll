using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{
	private float speed;

	// Start is called before the first frame update
	void Start()
	{
		//Give the cloud a random speed
		speed = Random.Range(0.0005f, 0.005f);
		//Give it a random direction
		speed *= (Random.Range(0, 2) * 2)-1;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += new Vector3(speed, 0, 0);

		//If the cloud is off the screen
		//If the cloud is on the left side of the screen
		if(transform.position.x < -13.5)
		{
			//Add 30 to it
			transform.position += new Vector3(26, 0, 0);
		}
		else if(transform.position.x > 13.5)
		{
			transform.position += new Vector3(-26, 0, 0);
		}
	}
}

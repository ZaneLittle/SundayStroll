using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
	public ParticleSystem ps;
	private bool hit;

	// Start is called before the first frame update
	void Start()
	{
		hit = false;
	}

	// Update is called once per frame
	void Update()
	{
		
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Obstacle" && !hit)
		{
			hit = true;
			
			Vector3 pos = other.gameObject.transform.position;
			//Delete the object
			Destroy(other.gameObject);

			//Spawn particles
			Instantiate(ps, pos, Quaternion.identity);

			//Player was hit
			Debug.Log("Player was hit. Restart the game");
			
			//Reset the game. Do this after a timer or after particle disappears
			//TODO Reset Scene
		}
	}
}

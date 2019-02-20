using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
	private bool hit;

	public ParticleSystem ps;

    private void Start()
	{
		hit = false;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Obstacle" && !hit)
		{
			hit = true;
			Debug.Log("Player was hit.");
            Vector3 pos = other.gameObject.transform.position;
			
            // Delete the obstacle
			Destroy(other.gameObject);

			// Spawn particles
			Instantiate(ps, pos, Quaternion.identity);

            // TODO: initiate death animation

            StartCoroutine(GameplayManager.endGame());
            //GameplayManager.endGame();
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
	private bool hit;

	public ParticleSystem ps;
    public Collider2D groundCollider;

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
            Vector3 pos = gameObject.transform.position;
			
            // Delete the obstacle
			Destroy(other.gameObject);

			// Spawn particles
			Instantiate(ps, pos, Quaternion.identity);

            // TODO: initiate death animation

            StartCoroutine(GameplayManager.endGame());
        }
        else if (other.gameObject.tag == "HoleObstacle" && !hit)
        {
            hit = true;
            Debug.Log("Player fell in a hole.");
            // Vector3 pos = gameObject.transform.position;

            // TODO: may need to be refactored to be smoother
            // but ya know what? its good for now.
            // Move player into region of hole
            Vector3 pos = new Vector3(
                (transform.position.x + other.transform.position.x)/2,
                transform.position.y,
                0
            );
            transform.position = pos;

            // Allow player to fall
            groundCollider.enabled = false;
            
            // TODO: initiate falling animation

            StartCoroutine(GameplayManager.endGame());
        }
    }
}

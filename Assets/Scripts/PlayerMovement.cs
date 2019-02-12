using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private bool canJump;
	public int jumpForce;
	public float moveSpeed;

	// Start is called before the first frame update
	void Start()
	{
		canJump = true;
	}

	// Update is called once per frame
	void Update()
	{
		//If up was presed
		if(Input.GetKey("up"))
		{
			//Jump
			if(canJump)
			{
				canJump = false;
				//Stopping the vertical velocty
				Vector3 v = GetComponent<Rigidbody2D>().velocity;
				v.y = 0f;
				GetComponent<Rigidbody2D>().velocity = v;

				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			}
		}

		//Adding left and right movement
		if(Input.GetKey("right"))
		{
			//Adding constraints to the movement
			if(transform.position.x < 8.5)
			{
				transform.position += (new Vector3(0.1f, 0, 0) * moveSpeed);
			}
		}
		if(Input.GetKey("left"))
		{
			//Adding constraints to the movement
			if(transform.position.x > -8.5)
			{
				transform.position += (new Vector3(-0.1f, 0, 0) * moveSpeed);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Ground")
		{
			canJump = true;
		}
	}
}

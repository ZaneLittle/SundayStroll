using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private bool onGround;
	public int jumpForce;
	public float moveSpeed;
	public float duckMult;
	private Vector3 defaultScale;

	// Start is called before the first frame update
	void Start()
	{
		onGround = true;
		defaultScale = transform.localScale;
	}

	// Update is called once per frame
	void Update()
	{
		//If up was presed
		if(Input.GetKey("up"))
		{
			//Jump
			if(onGround)
			{
				onGround = false;

				//Stopping the vertical velocty
				Vector3 v = GetComponent<Rigidbody2D>().velocity;
				v.y = 0f;
				GetComponent<Rigidbody2D>().velocity = v;

				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			}
		}

		//If theyre ducking and on the ground
		if(Input.GetKey("down") && onGround)
		{
			//Shrink them
			transform.localScale = new Vector3(defaultScale.x, defaultScale.y*duckMult, defaultScale.z);
		}
		else
		{
			//Otherwise, return to normal scale
			transform.localScale = defaultScale;
		}

		//Adding left and right movement
		if(Input.GetKey("right"))
		{
			//Adding constraints to the movement
			if(transform.position.x < 8)
			{
				transform.position += (new Vector3(0.1f, 0, 0) * moveSpeed);
			}
		}
		if(Input.GetKey("left"))
		{
			//Adding constraints to the movement
			if(transform.position.x > -8)
			{
				transform.position += (new Vector3(-0.1f, 0, 0) * moveSpeed);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Ground")
		{
			onGround = true;
		}
	}
}

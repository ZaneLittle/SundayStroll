using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
	private float speed;
	public int layer;

	void Start()
	{
		Parallax p = this.gameObject.GetComponentInParent<Parallax>();
		
		speed = (p.speed - (layer * p.speed/10.0f)*p.relateSpeed);
	}

	void Update()
	{
		transform.position = new Vector3(transform.position.x-speed, transform.position.y, transform.position.z);
		if(transform.position.x < -8.85f*2)
		{
			transform.position = new Vector3(8.85f*2, transform.position.y, transform.position.z);
		}
	}
}

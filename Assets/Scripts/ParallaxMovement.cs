using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
	private float speed;
	public int layer;

    private void setSpeed()
    {
        Parallax p = this.gameObject.GetComponentInParent<Parallax>();

        speed = (
            GameplayManager.getSpeed() - (
                layer * GameplayManager.getSpeed() / 10.0f
            ) * p.relateSpeed);
    }

	private void Start()
	{
        setSpeed();
	}

	private void Update()
	{
        setSpeed();
		transform.position = new Vector3(transform.position.x-speed, transform.position.y, transform.position.z);
		if(transform.position.x < -8.85f*2)
		{
			transform.position = new Vector3(8.85f*2, transform.position.y, transform.position.z);
		}
	}
}

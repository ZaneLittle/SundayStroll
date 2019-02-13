using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public List<GameObject> layers;
	public float speed;
	public float relateSpeed;

	void Start()
	{
		//Create 3 spriteObjects for each layer
		for(int i = 0; i < layers.Count; i++)
		{
			Vector3 pos = new Vector3(0, layers[i].transform.position.y, 0);
			GameObject ob = Instantiate(layers[i], pos, Quaternion.identity);
			ob.transform.parent = this.transform;

			pos.x = 8.85f * 2;
			ob = Instantiate(layers[i], pos, Quaternion.identity);
			ob.transform.parent = this.transform;
		}
	}
}

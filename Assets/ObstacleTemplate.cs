using UnityEngine;
using System.Collections;

public class ObstacleTemplate : MonoBehaviour {
	//public float fallSpeed;
	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody2D>().velocity = new Vector2(0,fallSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D>().position.y <= -7) {
			Destroy(gameObject);
		}

	}
}

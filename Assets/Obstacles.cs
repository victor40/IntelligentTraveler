using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {
	public float timer;
	public float ctime;
	public GameObject obstacleTemplate;
	public Vector2 startPosition;
	public GameObject obstacle;
	public float fallSpeed;
	public float size;

	// Use this for initialization
	void Start () {
		//startPosition = obstacle.transform.position;
		ctime = timer;
	}
	
	// Update is called once per frame
	void Update (){ 
		ctime += -Time.deltaTime;
		if (ctime <= 0) {
			startPosition.x = Random.Range(-3,3);
			size = Random.Range (1,6);
			obstacle = Instantiate (obstacleTemplate,startPosition,Quaternion.identity) as GameObject;
			obstacle.transform.localScale = new Vector3(2*startPosition.x, 2, 2);
			obstacle.GetComponent<Rigidbody2D>().freezeRotation = true;
			obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-fallSpeed);
			ctime = timer;
		}

	
	}
}

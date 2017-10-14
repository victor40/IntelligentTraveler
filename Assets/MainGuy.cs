using UnityEngine;
using System.Collections;

public class MainGuy : MonoBehaviour {
	public float jumpSpeed;
	public float moveSpeed;
	public float range;
	public int side;
	public GameObject leftWall;
	public GameObject rightWall;
	public GameObject obstacle;
	public float gameThreshold;
	private Rigidbody2D rb2d;
	public bool jumping;
	public Animator anim;
	public float winTime;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = new Vector2(-jumpSpeed,0);
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!(rb2d.IsTouching (leftWall.GetComponent<BoxCollider2D> ())
			|| rb2d.IsTouching (rightWall.GetComponent<BoxCollider2D> ()) 
			)) {
			anim.SetBool("jumping", true);
		}

		if(rb2d.IsTouching (rightWall.GetComponent<BoxCollider2D> ())){
			transform.eulerAngles = new Vector3(transform.localRotation.x,0,90);
			rb2d.velocity = new Vector2(0,0);
			anim.SetBool("jumping", false);
		}
		else if(rb2d.IsTouching (leftWall.GetComponent<BoxCollider2D> ())){
			transform.eulerAngles = new Vector3(transform.localRotation.x,180,90);
			rb2d.velocity = new Vector2(0,0);
			anim.SetBool("jumping", false);
		}
		if (Input.GetKey (KeyCode.LeftArrow) && rb2d.IsTouching (rightWall.GetComponent<BoxCollider2D> ())) {
			
			rb2d.velocity = new Vector2(-jumpSpeed,0);
			anim.SetBool("jumping", true); 
		}
		else if (Input.GetKey (KeyCode.RightArrow)&& rb2d.IsTouching (leftWall.GetComponent<BoxCollider2D> ())) {
			rb2d.velocity = new Vector2(jumpSpeed,0);
			anim.SetBool("jumping", true);
		}
		if (rb2d.IsTouching (leftWall.GetComponent<BoxCollider2D> ())
		 || rb2d.IsTouching (rightWall.GetComponent<BoxCollider2D> ()) 
		 || rb2d.IsTouching (obstacle.GetComponent<BoxCollider2D> ())) {
			moveSpeed = range * Input.GetAxis ("Vertical");
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, moveSpeed);
		//if (rb2d.position.y >= gameThreshold) {
		//}

		if (rb2d.position.y <= -gameThreshold || rb2d.position.y >= gameThreshold) {
			Destroy(gameObject);
			Application.LoadLevel ("GameOver");

		}
		winTime -= Time.deltaTime;
		if (winTime <= 0) {
			Application.LoadLevel ("Win");
		}
	
	}
}

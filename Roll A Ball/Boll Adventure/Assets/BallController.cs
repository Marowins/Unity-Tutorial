using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 250f;
	public Transform SpawnPoint;

	Vector3 movement;

	bool isJumping;
	Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		Move ();
		if (Input.GetButtonDown ("Jump"))
			isJumping = true;
	}

	void Move(){
		float x = Input.GetAxisRaw ("Horizontal");
		float z = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (x, 0f, z) * speed;
		if (isJumping) {
			isJumping = false;
			if (movement.y <= 0.5) {
				movement.y = jumpForce;
			}
		}
			
		rb.AddForce (movement);
	}

	void OnTriggerEnter(Collider other){
		string otherTag = other.gameObject.tag;
		if (otherTag == "DeadLine")
			transform.position = SpawnPoint.position;
		else if (otherTag == "Score")
			other.gameObject.SetActive (false);
		else if (otherTag == "Death")
			Destroy (this.gameObject);
		else if (otherTag == "Clear")
			Debug.Log ("Score");
	}
		
}

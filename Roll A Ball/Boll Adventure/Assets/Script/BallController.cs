using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 10f;
	public Vector3 SpawnPoint = new Vector3(-8, 2, -8);

	Vector3 movement;
	Rigidbody rb;

	float x, z;
	bool isJumping;

	//편의상 만든 변수들
	public Transform one;
	public Transform two;
	public Transform three;
	public Transform four;
	public Transform five;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		
		x = Input.GetAxisRaw ("Horizontal");
		z = Input.GetAxisRaw ("Vertical");

		if (Input.GetButtonDown ("Jump"))
			isJumping = true;

		if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Keypad1))
			transform.position = one.position;
		else if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Keypad2))
			transform.position = two.position;
		else if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Keypad3))
			transform.position = three.position;
		else if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Keypad4))
			transform.position = four.position;
		else if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Keypad5))
			transform.position = five.position;
	}

	void FixedUpdate(){
		Move ();
		Jump ();
	}

	void Move(){
		movement.Set (x, 0, z);
		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition (transform.position + movement);
	}

	void Jump(){
		if (!isJumping)
			return;
		rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		isJumping = false;
	}

	void OnTriggerEnter(Collider other){
		string otherTag = other.gameObject.tag;
		if (otherTag == "Score") {
			other.gameObject.SetActive (false);
			GameManager.instance.score += 1;
		} else if (otherTag == "Death") {
			Destroy (this.gameObject);
			GameManager.instance.state.text = "Game Over!";
		} else if (otherTag == "Clear") {
			Destroy (this.gameObject);
			GameManager.instance.state.text = "Game Clear!";
		} else if (otherTag == "DeadLine")
			transform.position = SpawnPoint;
	}
		
}

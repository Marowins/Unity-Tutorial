using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
	public Text WinText;
	public Text CountText;

	public int count = 0;
	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		WinText.text = "";
	}

	void Update(){
		SetCountText ();
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (h, 0f, v);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Score")) {
			other.gameObject.SetActive (false);
			count+=1;
		}
	}

	void SetCountText() {
		if (count >= 8)
			WinText.text = "You Win!";
		CountText.text = "count : " + count;
	}

}
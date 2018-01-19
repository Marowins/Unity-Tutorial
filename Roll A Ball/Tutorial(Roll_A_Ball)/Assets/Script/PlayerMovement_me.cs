using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_me : MonoBehaviour {

	public float speed = 4f;

	float h;
	float v;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		h = Input.GetAxisRaw ("Horizontal") * speed;
		v = Input.GetAxisRaw ("Vertical") * speed;

		Move (h, v);
	}

	void Move(float h,float v){
		rb.AddForce (h, 0f, v);
	}
}

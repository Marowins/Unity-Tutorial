using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLMove : MonoBehaviour {

	public float speed = 5;
	public Vector3 Left;

	bool tictoc;

	Vector3 Right;
	//Rigidbody rb;

	void Start () {
		Right = transform.position;
		Left = new Vector3 (-8.3f, 0f, -4.5f);
		//rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		Vector3 CurrentPoint = transform.position;
		if (CurrentPoint.x <= Left.x)
			tictoc = false;
		else if( CurrentPoint.x >= Right.x)
			tictoc = true;

		if(tictoc)
			transform.Translate (new Vector3 (-speed, 0, 0)*Time.deltaTime);
		else if(!tictoc)
			transform.Translate (new Vector3 (speed, 0, 0)*Time.deltaTime);
	}

	/*void FixedUpdate(){
		if(tictoc)
			rb.AddForce(new Vector3(-speed, 0, 0));
		else if(!tictoc)
			rb.AddForce(new Vector3(speed, 0, 0));	
	}*/

}
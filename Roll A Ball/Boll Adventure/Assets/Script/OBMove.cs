using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBMove : MonoBehaviour {

	public float speed = 5;
	public Vector3 Right;

	bool tictoc;

	Vector3 Left;
	//Rigidbody rb;

	void Start () {
		Left = transform.position;
		Right = new Vector3 (6.5f, 0.25f, -4.5f);
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
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLRotate : MonoBehaviour {

	public float speed = 250;

	void Update () {
		transform.Rotate (new Vector3 (0, speed, 0) * Time.deltaTime);
	}
}

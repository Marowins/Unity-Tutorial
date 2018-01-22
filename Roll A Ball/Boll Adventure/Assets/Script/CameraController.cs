using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Player;
	Vector3 offset;

	void Awake(){
		offset = transform.position - Player.position;
	}
		
	void LateUpdate(){
		transform.position = Player.position + offset;
	}

}
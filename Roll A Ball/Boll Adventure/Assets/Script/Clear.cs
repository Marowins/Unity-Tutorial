using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour {

	void Update(){
		int score = GameManager.instance.score;
		transform.position = new Vector3 (20 - score, 0, 20 - score);
	}

}

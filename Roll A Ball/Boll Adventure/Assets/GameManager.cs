using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Text collected;
	public Text state;

	public int score = 0;

	void Awake() {
		instance = this;
		state.text = "";
	}

	void Update(){
		collected.text = score + " / 5";
	}
		
}

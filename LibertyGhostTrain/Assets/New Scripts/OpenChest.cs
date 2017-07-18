using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenChest : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll) {
		//Set to the win game screen

		if (coll.gameObject.tag == "Player") {
			SceneManager.LoadScene ("GameWon");
		}
	}
}

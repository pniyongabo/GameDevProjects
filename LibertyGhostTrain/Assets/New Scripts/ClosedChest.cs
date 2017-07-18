using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedChest : MonoBehaviour {

	public GameObject openChest;

	private GameObject tempOpenChest;

	// Use this for initialization
	void Start () {
		//openChest = GameObject.Find ("Treasure_Chest_Gold_New");

		tempOpenChest = Instantiate (openChest);
		tempOpenChest.transform.position = transform.position;
		tempOpenChest.SetActive (false);

		//print (openChest.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			print ("Collided with player");
			this.gameObject.SetActive (false);

			tempOpenChest.SetActive (true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		print (col.gameObject.name);
		if(col.gameObject.tag == "block")
		{
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "wall") {
			Destroy (gameObject);
		}

	}
}

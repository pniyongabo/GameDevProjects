using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - .05f);
        if (transform.position.y <= -11)
            transform.position = new Vector3(transform.position.x, 0);
	}
}

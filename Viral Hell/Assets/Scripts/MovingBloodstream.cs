using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBloodstream : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - .02f);
        if (transform.position.y <= -10)
            transform.position = new Vector3(transform.position.x, 0);
    }
}

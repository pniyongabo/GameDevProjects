using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleScript : MonoBehaviour {

    public float stretchspeed;
    public float maxlength;

	// Use this for initialization
	void Start () {
        this.transform.localScale = new Vector3(1, .1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.localScale.y < maxlength)
        {
            transform.localScale += new Vector3(0, stretchspeed);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombeeMvt : MonoBehaviour {
	GameObject target;
	public float speed;

	// Use this for initialization
	void Start () {
		//speed = 0.5f;
		target = GameObject.Find("Beehive");
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		//print (target.transform.position);
		Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, step);
		transform.position = pos;
	}
}

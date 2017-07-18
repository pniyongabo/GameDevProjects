using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriticBombController : MonoBehaviour {

	private float speed = 8.0f;
	private Vector3 position;
	private bool isProjectile;



	public float MoveSpeed = 5.0f;

	public float frequency = 20.0f;  // Speed of sine movement
	public float magnitude = 0.5f;   // Size of sine movement
	private Vector3 axis;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		GameObject playerSprite = GameObject.Find ("VirusPlayer");
		if (playerSprite != null) {
			position = playerSprite.transform.position;
		} else {
			position = new Vector3(0,0,0);
		}
		isProjectile = false;
		axis = transform.right;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isProjectile) {
			transform.position = Vector3.MoveTowards (transform.position, position, Time.deltaTime * speed);
		} else {
			//move ();
		}
	}

//	void move() {
//		pos -= transform.up * Time.deltaTime * MoveSpeed;
//		transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;
//	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    Vector3 moveDirection;
    float speed = 50f;
    GameObject plane;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        plane = GameObject.Find("Plane");
        moveDirection = plane.transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -100);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(0, 0, -100);
    }
}

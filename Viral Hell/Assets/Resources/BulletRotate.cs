using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : MonoBehaviour {

    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        if (Random.Range(0, 1) == 0)
            rotationSpeed = -rotationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}

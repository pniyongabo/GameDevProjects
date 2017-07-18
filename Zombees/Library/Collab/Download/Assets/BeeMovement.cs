using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {

	public float force;
	private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W)) {
			rigid.AddForce (transform.up * force, ForceMode2D.Impulse);
			rigid.velocity = Vector2.ClampMagnitude (rigid.velocity, 5f);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.position += new Vector3 (-0.1f, 0f, 0f);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (0.1f, 0f, 0f);
		}


	}
}

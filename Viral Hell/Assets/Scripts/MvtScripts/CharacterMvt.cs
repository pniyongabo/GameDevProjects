using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvt : MonoBehaviour {

	public float maxSpeed;
	public float currentSpeed;

	// Use this for initialization
	void Start () {
        maxSpeed = .08f;
		currentSpeed = maxSpeed;
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            */
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, currentSpeed, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-currentSpeed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -currentSpeed, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(currentSpeed, 0f, 0f);
        }
        /*
        transform.position += move * currentSpeed * Time.deltaTime;
        */

        if (gameObject.GetComponent<CharacterSpriteController>().CellSprite.transform.localScale.x >= 0f)
        {
            if (transform.position.x > 3.5) transform.position = new Vector3(3.5f, transform.position.y);
            if (transform.position.x < -3.5) transform.position = new Vector3(-3.5f, transform.position.y);
            if (transform.position.y > 4.6) transform.position = new Vector3(transform.position.x, 4.5f);
            if (transform.position.y < -4.35) transform.position = new Vector3(transform.position.x, -4.35f);
        }
        else
        {
            if (transform.position.x > 4) transform.position = new Vector3(4f, transform.position.y);
            if (transform.position.x < -4) transform.position = new Vector3(-4f, transform.position.y);
            if (transform.position.y > 5) transform.position = new Vector3(transform.position.x, 5f);
            if (transform.position.y < -6) transform.position = new Vector3(transform.position.x, -6f);
        }

        
		if (currentSpeed < maxSpeed) {
			currentSpeed += 0.001f;
		}
        
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "DendriticBomb") {
            currentSpeed -= (.75f * currentSpeed);
            //currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
			Destroy (col.gameObject);
		}
	}
}


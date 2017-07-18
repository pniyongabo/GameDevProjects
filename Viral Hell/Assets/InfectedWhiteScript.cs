using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedWhiteScript : MonoBehaviour {

	private GameObject playerSprite;

	public float health;

	// Use this for initialization
	void Start () {
		playerSprite = GameObject.Find ("VirusPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, playerSprite.transform.position, 0.1f);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			health -= 1f;
		}

		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void setHealth(float newHealth) {
		health = newHealth;
	}
}

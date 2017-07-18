using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerCloneController : MonoBehaviour {

	private Vector3 newPos;
	private bool moveTowardsNewPos;

	private GameObject playerSprite;

	private bool findPositionCoroutineStarted;

	private float fireSpeed = 1f;

	private int health = 12;

	public GameObject winCanvas;

	// Use this for initialization
	void Start () {
		moveTowardsNewPos = false;
		findPositionCoroutineStarted = false;
		playerSprite = GameObject.Find ("VirusPlayer");

		StartCoroutine (createBullets ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!findPositionCoroutineStarted) {
			StartCoroutine (findPosition ());
		}

		transform.position = Vector3.MoveTowards (transform.position, newPos, 0.1f);

		if (playerSprite != null) {
			Vector3 vectorToTarget = playerSprite.transform.position - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
			Quaternion newRot = Quaternion.AngleAxis (angle, transform.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRot, Time.deltaTime * 1f);
		}
	}


	IEnumerator findPosition() {
		while (true) {
			newPos = new Vector3 (Random.Range (-3.5f, 3.5f), Random.Range (-3f, 4f));
			moveTowardsNewPos = true;
			findPositionCoroutineStarted = true;


			yield return new WaitForSeconds (4f);
		}
	}

	IEnumerator createBullets() {
		while (true) {
			GameObject bullet = Instantiate (Resources.Load ("CancerBullet"), transform.position, transform.rotation) as GameObject;
			yield return new WaitForSeconds (fireSpeed);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			health -= 1;
			Destroy (col.gameObject);
		}

		if (health <= 0) {
			Destroy (this.gameObject);
		}

		if (winCanvas.activeSelf == true) {
			Destroy (this.gameObject);
		}
	}
}

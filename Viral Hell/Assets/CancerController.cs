using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerController : MonoBehaviour {

	private GameObject playerSprite;
	private GameObject spawner;

	private float maxHealth;
	private float health;
	private Vector3 startingPos;

	private GameObject wbc;
	private float findInterval;
	private bool moveTowardsWBC;

	private Vector3 newPos;
	private bool moveTowardsNewPos;
	private bool findPositionCoroutineStarted;
	private bool hasClone;

	public GameObject winCanvas;




	// Use this for initialization
	void Start () {
		playerSprite = GameObject.Find ("VirusPlayer");
		spawner = GameObject.Find ("Spawner");

		maxHealth = 150f;
		health = maxHealth;
		startingPos = transform.position;

		findInterval = 2f;
		moveTowardsWBC = false;

		moveTowardsNewPos = false;
		findPositionCoroutineStarted = false;
		hasClone = false;
		StartCoroutine (findWhiteBloodCells ());
	}
	
	// Update is called once per frame
	void Update () {
		if (health > maxHealth * 0.60) {
			if (wbc != null) {
				phase1Move ();
			}
		} else {
			spawner.SetActive (false);
			phase2Move ();
		}
	}



	void phase1Move() {
		if (moveTowardsWBC) {
			transform.position = Vector3.MoveTowards (transform.position, wbc.transform.position, 0.4f);
			if (transform.position.x == wbc.transform.position.x) {
				moveTowardsWBC = false;

				Vector3 tempPos = wbc.transform.position;
				Quaternion tempRot = wbc.transform.rotation;
				Vector3 tempScale = wbc.transform.localScale;
				Destroy (wbc);
				GameObject infected = Instantiate (Resources.Load ("InfectedWhite"), tempPos, tempRot) as GameObject;
				infected.transform.localScale = tempScale;
				infected.GetComponent<InfectedWhiteScript> ().setHealth (4f * tempScale.x);
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, startingPos, 0.4f);
		}
	}

	void phase2Move() {
		if (!findPositionCoroutineStarted) {
			StartCoroutine (findPosition ());
		}

		if (moveTowardsNewPos) {
			transform.position = Vector3.MoveTowards (transform.position, newPos, 1f);
			if (transform.position == newPos) {
				moveTowardsNewPos = false;
				if (!hasClone) {
					GameObject newCancerCell = Instantiate (Resources.Load ("CancerSpriteClone"), 
						                          findRandomPosition (Random.Range (1, 4), transform.position), transform.rotation) as GameObject;
					hasClone = true;
				}
			}
		}
		if (playerSprite != null) {
			Vector3 vectorToTarget = playerSprite.transform.position - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
			Quaternion newRot = Quaternion.AngleAxis (angle, transform.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRot, Time.deltaTime * 1f);
		}
			
	}

	IEnumerator findWhiteBloodCells() {
		while (true) {
			wbc = GameObject.Find ("WhiteBloodCell(Clone)");
			moveTowardsWBC = true;
			yield return new WaitForSeconds (findInterval);
		}
	}

	IEnumerator findPosition() {
		while (true) {
			newPos = new Vector3 (Random.Range (-3.5f, 3.5f), Random.Range (-3f, 4f));
			moveTowardsNewPos = true;
			findPositionCoroutineStarted = true;
			hasClone = false;
			yield return new WaitForSeconds (4f);
		}
	}

	Vector3 findRandomPosition(int rand, Vector3 pos) {
		Vector3 returnVector;
		if (rand == 1) {
			returnVector = new Vector3 (pos.x, pos.y + 1f, 0f);
		} else if (rand == 2) {
			returnVector = new Vector3 (pos.x + 1, pos.y, 0f);
		} else if (rand == 3) {
			returnVector = new Vector3 (pos.x, pos.y - 1f, 0f);
		} else {
			returnVector = new Vector3 (pos.x - 1f, pos.y, 0f);
		}
		return returnVector;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			health -= 1f;
			Destroy (col.gameObject);
		}

		if (health <= 0f) {
			winCanvas.SetActive (true);
			playerSprite.GetComponent<BoxCollider2D> ().enabled = false;
			Destroy (this.gameObject);

		}
	}

	public float getLifePercentage() {
		return (health/maxHealth) * 100f;
	}



		
		
}

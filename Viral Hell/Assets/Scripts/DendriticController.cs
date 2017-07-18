using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DendriticController : MonoBehaviour {

	public float maxHealth = 200f;
	private float currentHealth;

	private bool moveRight = true;
	public float speed = 0.6f;

	private GameObject dendritic;
	private float rotationSpeed;
	private float spawnSpeed;

    public float bulletspeed;
   
	public GameObject winCanvas;

	List<GameObject> firePoints = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "DendriticNormal") {
			//maxHealth = maxHealth/2;
		}
		currentHealth = maxHealth;
		dendritic = transform.Find("Dendritic").gameObject;
		rotationSpeed = dendritic.GetComponent<rotationMovement>().rotationSpeed;

		foreach (Transform child in dendritic.transform) {
			firePoints.Add (child.gameObject);
			spawnSpeed = child.gameObject.GetComponent<SpawnScript> ().spawnspeed;
            child.gameObject.GetComponent<SpawnScript>().dendriticspeed = bulletspeed;

        }


	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth > maxHealth * 0.75f) {
			phase1Move ();
		} else if (currentHealth > maxHealth * 0.25f) {
			phase1Move ();
			GetComponent<SpawnBombs> ().enabled = true;
		} else {
			phase1Move ();
			phase3Move ();
		}

	}

	void phase1Move() {
		if (moveRight) {
			transform.Translate (Vector3.right * Time.deltaTime * speed);
			if (transform.position.x > 1.5f) {
				moveRight = false;
			}
		} else {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
			if (transform.position.x < -1.5f) {
				moveRight = true;
			}
		}
	}

	void phase3Move() {
        speed = 1;
		if (rotationSpeed <= 125.0f) {
			rotationSpeed += 1.0f;
			dendritic.GetComponent<rotationMovement> ().rotationSpeed = rotationSpeed;
		}

		if (spawnSpeed >= 0.2f) {
			spawnSpeed -= 0.02f;
			foreach (GameObject firePoint in firePoints) {
				firePoint.GetComponent<SpawnScript> ().spawnspeed = spawnSpeed;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			currentHealth -= 1f;
			Destroy (col.gameObject);
		}

		if (currentHealth <= 0f) {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<rotationMovement>().enabled = false;
            GetComponent<SpawnBombs>().spawnrate = 100;
            foreach(GameObject g in firePoints)
            {
                g.SetActive(false);
            }
            winCanvas.SetActive (true);
            this.enabled = false;
		}
	}

	public float getLifePercentage() {
		return (currentHealth / maxHealth) * 100f;
	}




}

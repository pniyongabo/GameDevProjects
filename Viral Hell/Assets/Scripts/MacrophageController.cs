using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacrophageController : MonoBehaviour {

	public float maxHealth = 200f;
	private float health;
	private bool moveRight = true;
	private float speed = 0.25f;
	private Vector3 startingPos;
    public float bulletspeed;
    public float bulletspawnspeed;


	public GameObject playerSprite;
    public GameObject wincanvas;
    public GameObject inner;
    public GameObject firepoints;
    public GameObject music;
    public GameObject spawner;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "MacrophageNormal") {
            //we can just change the health in the public variable for normal and hard
			//maxHealth = maxHealth/2;
		}
		startingPos = transform.position;
		health = maxHealth;
		GetComponent<rotationMovement> ().enabled = false;
        
        foreach (SpawnScript c in firepoints.GetComponentsInChildren<SpawnScript>())
            {
            c.macrophagespeed = bulletspeed;
            c.spawnspeed = bulletspawnspeed;
        }

	}
	
	// Update is called once per frame
	void Update () {
		if (health > maxHealth * 0.75f) {
			phase1Move ();
		} else if (health > maxHealth * 0.45f) {
			phase2Move ();
		} else { if (playerSprite != null) {
				transform.position = Vector3.MoveTowards (transform.position, playerSprite.transform.position, Time.deltaTime * 0.2f);
				if (transform.position.y < 2f) {
                    transform.position = new Vector3(transform.position.x, 2f);
				}
			}
        }
		
	}
		

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.tag == "PlayerBullet") {
			health -= 1;
            inner.GetComponent<GrowAndShrink>().approachSpeed += .0001f;
            transform.localScale += new Vector3(.02f, .02f);
			Destroy (c.gameObject);
			StartCoroutine (hitEffect());
		}

		if (health <= 0) {
            inner.SetActive(false);
            enabled = false;
            wincanvas.SetActive(true);
            firepoints.SetActive(false);
            gameObject.GetComponent<rotationMovement>().rotationSpeed = 0;
            playerSprite.GetComponent<SpawnScript>().isfiring = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            spawner.SetActive(false);
            playerSprite.GetComponent<CharacterSpriteController>().health = 100;
            //music.SetActive(false);
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

	void phase2Move() {
		if (transform.position != startingPos) {
			transform.position = Vector3.MoveTowards (transform.position, startingPos, Time.deltaTime * speed);
        
		} else {
			GetComponent<rotationMovement> ().enabled = true;
			foreach (Transform child in transform) {
				//if child.gameObject.GetComponent<SpawnScript>().
				//child.gameObject.GetComponent<SpawnScript> ().spawnspeed = .6f;
			}
		}
	}

	IEnumerator hitEffect() {
        /*
		Behaviour h = (Behaviour)GetComponent ("Halo");
		h.enabled = true;
        h.enabled = false;
        */
        yield return new WaitForSeconds (0.10f);
		
	}

	public float getLifePercentage() {
		return (health / maxHealth) * 100f;
	}
}

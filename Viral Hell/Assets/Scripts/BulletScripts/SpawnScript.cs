using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public bool isfiring;
    public float spawnspeed;
    public float macrophagespeed;
    public float dendriticspeed;
    public float playerspeed;

	private IEnumerator coroutine;

	private AudioClip clip;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("createBullets", 0.5f, spawnspeed);
		StartCoroutine (createBullets());
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position, transform.up * 10, Color.red );
		//print (transform.forward);
	}

	IEnumerator createBullets() {
		while (true) {
			yield return new WaitForSeconds (.01f);
			if(isfiring) {
				if (this.gameObject.tag == "Player") {
					clip = Resources.Load<AudioClip> ("SoundEffect/PlayerShootSound");
					GameObject bullet = Instantiate (Resources.Load ("cellBullet"), transform.position + new Vector3 (0, .6f), transform.rotation) as GameObject;
					bullet.GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity;
					GameObject bullet2 = Instantiate (Resources.Load ("cellBullet"), transform.position + new Vector3 (.3f, .6f), transform.rotation) as GameObject;
					bullet2.GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity;
					GameObject bullet3 = Instantiate (Resources.Load ("cellBullet"), transform.position - new Vector3 (.3f, -.6f), transform.rotation) as GameObject;
					bullet3.GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity;
					this.gameObject.GetComponent<AudioSource> ().PlayOneShot (clip);
                }

                if (this.gameObject.tag == "Macrophage") {
					clip = Resources.Load<AudioClip> ("SoundEffect/MacrophageShootSound");
					GameObject bullet = Instantiate (Resources.Load ("Macrophage Bullets"), transform.position, transform.rotation) as GameObject;
					bullet.GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody> ().velocity;
                    bullet.GetComponent<BulletClass>().speed = macrophagespeed;
					this.gameObject.GetComponent<AudioSource> ().PlayOneShot (clip);
				}

				if (this.gameObject.tag == "DendriticFire") {
					GameObject bullet = Instantiate (Resources.Load ("DendriticBullet"), transform.position, transform.rotation) as GameObject;
                    clip = Resources.Load<AudioClip>("ExtraSoundz/dendriticshoot");
                    bullet.GetComponent<AudioSource>().Play();
                    bullet.GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody> ().velocity;
                    bullet.GetComponent<BulletClass>().speed = dendriticspeed;
                }
			}

			yield return new WaitForSeconds (spawnspeed);
		}
	}
}

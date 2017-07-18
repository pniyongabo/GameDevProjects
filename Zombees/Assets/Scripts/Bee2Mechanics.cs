using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee2Mechanics : MonoBehaviour {

	public int beeHealth;
	public GameObject honeyBullet;
    public GameObject flyingBee;
    public GameObject stingingBee;
	//public GameObject life;
	public GameObject variableStorage;

	private bool attackMode;

	// Use this for initialization
	void Start () {
		variableStorage = GameObject.FindWithTag ("Storage");
		attackMode = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			GameObject bullet = Instantiate (honeyBullet, transform.position, transform.rotation) as GameObject;
			if (this.GetComponent<Bee2Movement>().getCurrentDirection().Equals('A')) {
				bullet.GetComponent<HoneyBulletScript> ().isRightDirection = false;
			} else {
				bullet.GetComponent<HoneyBulletScript> ().isRightDirection = true;
			}
		}
		attackMode = false;
        if (GetComponent<Rigidbody2D>().velocity.y < -6)
        {
            stingingBee.SetActive(true);
            flyingBee.SetActive(false);
			attackMode = true;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > -6)
        {
            stingingBee.SetActive(false);
            flyingBee.SetActive(true);
        }
    }

	void OnCollisionEnter2D(Collision2D c) {
        /*
		if (c.gameObject.tag == "Zombee" && !attackMode) {
			beeHealth -= 1;
            if(beeHealth < 1)
            {
                transform.rotation = Quaternion.Euler(180, 0, 0);
                GetComponentInChildren<Animator>().StopPlayback();
            }


			//life.GetComponent<LiveScript> ().reduceLive ();
		}
        */
	}
		



}

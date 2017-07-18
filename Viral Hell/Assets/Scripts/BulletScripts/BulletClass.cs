using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletClass : MonoBehaviour {

	public float speed;
	private float delay;
	// Update is called once per frame
	void Start(){
		delay = 10.0f;
	}

	void Update () {
        //speed = 
		move ();
		WaitAndDestroy ();
	}

	public virtual void move() {
		if (this.gameObject.tag == "PlayerBullet") {
			transform.position += transform.up * Time.deltaTime * speed;
		} else if (this.gameObject.tag == "MacrophageBullet" || this.gameObject.tag == "DendriticBullet") {
			transform.position -= transform.up * Time.deltaTime * speed;
		}
	}

	public void setSpeed(float newSpeed) {
		speed = newSpeed;
	}

	public void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
		
	void WaitAndDestroy(){
		//Yield WaitForSecons(delay);
		if (this.gameObject != null){
			Destroy (this.gameObject, delay);
		}
	}
		
		


}

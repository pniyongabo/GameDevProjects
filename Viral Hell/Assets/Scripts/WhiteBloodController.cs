using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodController : MonoBehaviour {

	private float speed = 2f;
	private float delay = 10.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime * speed);
		WaitAndDestroy ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
            transform.localScale += new Vector3(.3f, .3f);
			//Destroy (this.gameObject);
		}
	}

	void WaitAndDestroy(){
		//Yield WaitForSecons(delay);
		if (this.gameObject != null){
			Destroy (this.gameObject, delay);
		}
	}

}

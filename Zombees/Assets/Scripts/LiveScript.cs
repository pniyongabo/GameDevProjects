using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveScript : MonoBehaviour {

	private int lives;
	private int counter;
	private int shakeSpeed;

	//GameObject life1;
	//GameObject life2;
	//public GameObject life3;

	// Use this for initialization
	void Start () {
		lives = transform.childCount;
		counter = 0;
        //DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		pos.x  = pos.x+  0.1f * Mathf.Sin (Time.time * shakeSpeed);

		transform.position = pos;
		//transform.position = new Vector3(.1f * Mathf.Sin(Time.time * shakeSpeed),0f);
	}

	public void reduceLive() {
		if (counter < lives) {
			print (counter);
			Destroy (transform.GetChild (0).gameObject);
			counter += 1;
			StartCoroutine (shakeLives());
		}

        //testing out no bee health
        /*
		if (counter == 3) {
			SceneManager.LoadScene ("gameOver");
		}
        */
	}

	IEnumerator shakeLives()
	{
		shakeSpeed = 20;
		yield return new WaitForSeconds(1);
		shakeSpeed = 0;
		//transform.position = new Vector3(0, 0);
	}
}

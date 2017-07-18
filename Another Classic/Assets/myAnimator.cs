using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myAnimator : MonoBehaviour {

	private Animator fightAnimator;

	// Use this for initialization
	void Start () {
		fightAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("punch")){
			fightAnimator.SetBool("isPunching", true);
			Invoke("StopAction", 0.1f);
		}
		if (Input.GetButtonDown("elbow")){
			fightAnimator.SetBool("isElbowing", true);
			Invoke("StopAction", 0.1f);
		}
		if (Input.GetButtonDown("kick")){
			fightAnimator.SetBool("isKicking", true);
			Invoke("StopAction", 0.1f);
		}
	}

	void StopAction(){
		fightAnimator.SetBool ("isPunching",false);
		fightAnimator.SetBool ("isElbowing",false);
		fightAnimator.SetBool ("isKicking",false);
	}
}

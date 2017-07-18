using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChacterController : MonoBehaviour {

	float timer;
	public Text timerText;






	// Use this for initialization
	void Start () {
		timer = 60f;
	}
	
	// Update is called once per frame
	void Update () {
//		if (PlayerPrefs.GetInt ("Skill") < 0) {
//			PlayerPrefs.SetInt ("Skill", 0);
//			SceneManager.LoadScene ("GameOver");
//		}
		if (timer >= 0) {
			timer -= Time.deltaTime;
			timerText.text = float2timer (timer);
		} else {
			SceneManager.LoadScene ("GameOver");
		}



	}

	string float2timer(float time){

		float mins = Mathf.Floor(time / 60); string minutes = mins.ToString();
		float secs = Mathf.RoundToInt(time%60); string seconds = secs.ToString();

		if(mins < 10f) { 
			minutes = "0" + mins.ToString(); 
		} 
		if(secs < 10f) { 
			seconds = "0" + secs.ToString(); 
		} 

	
		return  minutes + ":" + seconds;
	}
		
}

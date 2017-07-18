using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitialPause : MonoBehaviour {

    public GameObject text;
    public GameObject music;
    public GameObject canvas;

    public float slowdown;

	// Use this for initialization
	void Start () {
        Time.timeScale = slowdown;
        StartCoroutine(countdown());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator countdown()
    {
        print("countdown");
        yield return new WaitForSeconds(slowdown);
        text.GetComponent<TextMeshProUGUI>().text = "4";
        yield return new WaitForSeconds(slowdown);
        text.GetComponent<TextMeshProUGUI>().text = "3";
        yield return new WaitForSeconds(slowdown);
        text.GetComponent<TextMeshProUGUI>().text = "2";
        yield return new WaitForSeconds(slowdown);
        text.GetComponent<TextMeshProUGUI>().text = "1";
        yield return new WaitForSeconds(slowdown);
        text.SetActive(false);
        music.SetActive(true);
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

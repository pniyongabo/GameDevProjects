using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashRed : MonoBehaviour {

    private Color normalcolor;

	// Use this for initialization
	void Start () {
        normalcolor = GetComponent<SpriteRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D()
    {
        Debug.Log("collided?");
        GetComponent<SpriteRenderer>().material.color = Color.red;
        StartCoroutine(flashwait());
    }

    private IEnumerator flashwait()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().material.color = normalcolor;
    }
}

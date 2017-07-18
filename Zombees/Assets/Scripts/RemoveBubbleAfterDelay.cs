using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBubbleAfterDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(RemoveSelf());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator RemoveSelf()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderGen : MonoBehaviour {
	public GameObject borders;
	public int size;

	// Use this for initialization
	void Start () {
		size = 5;
		for (int k = 0; k < size; k++) { 
			Vector3 position = new Vector3 (0 , 0, (k+1)*100);
			GameObject newBorders = (GameObject)Instantiate (borders, position, transform.rotation);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

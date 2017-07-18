using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroInnerFollow : MonoBehaviour {

    public GameObject macroouter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (macroouter.transform.position + new Vector3(0f, .2f));
        transform.rotation = new Quaternion(0, 0, 0, 0);
	}
}

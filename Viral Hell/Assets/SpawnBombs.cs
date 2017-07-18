using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBombs : MonoBehaviour {

    public float spawnrate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("tossBomb",0.5f, spawnrate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void tossBomb() {
		GameObject dendriticBomb = Instantiate (Resources.Load("DendriticBomb"), transform.position, transform.rotation) as GameObject;
	}
}

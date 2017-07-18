using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnWhiteScript : MonoBehaviour {

	List<GameObject> listOfSpawners = new List<GameObject>();
    public float spawnspeed;
    private GameObject prevspawnloc;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			listOfSpawners.Add (child.gameObject);
		}

        prevspawnloc = listOfSpawners[1];

		StartCoroutine (spawnWhiteBloodCells ());
			
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator spawnWhiteBloodCells() {
		while (true) {
			int index = Random.Range (0, listOfSpawners.Count);
			GameObject chosenSpawner = listOfSpawners [index];
			if (chosenSpawner == prevspawnloc) {
				index = Random.Range (0, listOfSpawners.Count);
				chosenSpawner = listOfSpawners [index];
			}
			GameObject wbc = Instantiate (Resources.Load ("WhiteBloodCell"), chosenSpawner.transform.position + new Vector3 (0, 0), transform.rotation) as GameObject;
			yield return new WaitForSeconds (spawnspeed);
		}
	}
		
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnitySteer;

public class GhostManager : MonoBehaviour {

	[SerializeField]
	GameObject ghostPrefab;

	[SerializeField]
	GameObject chestClosedPrefab;

	[SerializeField]
	GameObject chestOpenPrefab;

	public int _ghostNumb;

	public GameObject[] borderList;


	// Use this for initialization
	void Start () {

		borderList = GameObject.FindGameObjectsWithTag ("border");

		//Get the list of the rooms. With the position of the floor for each room. 
		//This will be the starting random position for the ghosts.
		for (int j = 0; j < borderList.Length; j++) {
			for (int i = 0; i < _ghostNumb; i++) {

				GameObject tempGhost = Instantiate (ghostPrefab) as GameObject;

				tempGhost.transform.position = new Vector3(borderList [j].transform.position.x, 
					tempGhost.transform.position.y, borderList[j].transform.position.z);
			}
		}

		int room = Random.Range (0, 2);

		GameObject room4 = GameObject.Find("borders4");

		GameObject room5 = GameObject.Find ("borders5");

		GameObject tempCloseChest = Instantiate (chestClosedPrefab) as GameObject;
//		GameObject tempOpenChest = Instantiate (chestOpenPrefab) as GameObject;

		if (room == 0) {
			Vector3 chests = new Vector3 (room4.transform.position.x, 1.98f, 
				room4.transform.position.z);

			tempCloseChest.transform.position = chests;
//			tempOpenChest.transform.position = chests;
		} else {
			Vector3 chests = new Vector3 (room5.transform.position.x, 1.98f, 
				room5.transform.position.z);

			tempCloseChest.transform.position = chests;
//			tempOpenChest.transform.position = chests;
		}
			

//		tempOpenChest.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

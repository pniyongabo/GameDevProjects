using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostRandGen : MonoBehaviour {

	public GameObject ghostBot;
	public int numGhostsPerDirection;
	private int numGhostsAlive = 0;
	float scaleY; //[-50, 50]
	float scaleZ; // fixed at 8 or range [4, 8] not sure
	float scaleX; // [-50, 50]



	// Use this for initialization
	void Start () {

		numGhostsPerDirection = 5;
		GenerateGhosts (numGhostsPerDirection);
		InvokeRepeating("GenerateMore", 1.0f, 1.0f);




	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

	}

	void PrintCoords(){
		//print(Camera.main.ScreenToWorldPoint (Input.mousePosition));
	}

	void GenerateGhosts(int n){
		float posX = transform.position.x;
		float posY = transform.position.y;
		float posZ = transform.position.z;
		for (int i = 0; i < n; i++) {  //WALL1
			Vector3 position = new Vector3(posX+Random.Range(-50.0f, 50.0f), posY+Random.Range(2.0f, 4.0f), posZ+Random.Range(-50.0f, -40.0f));
			GameObject ghost = (GameObject)Instantiate(ghostBot, position, Random.rotation); 
			numGhostsAlive++;
			//Instantiate(ghostBot, position, Quaternion.identity);
			//			ghost.GetComponent<AvoidSteer>().target = wolf;
			//			ghost.GetComponent<AvoidSteer>().dog = dog;
			//			ghost.GetComponent<AvoidOtherSteer>().dog = dog;
			//			ghost.GetComponent<AvoidOtherSteer>().target = wolf;
			//print ("DONE 1");
		}
		for (int k = 0; k < n; k++) {  // WALL4
			Vector3 position = new Vector3 (posX+Random.Range (40.0f, 50.0f), posY+Random.Range (2.0f, 4.0f), posZ+Random.Range (-50.0f, 50.0f));
			GameObject ghost = (GameObject)Instantiate (ghostBot, position, Random.rotation);
			//print ("DONE 4");
			numGhostsAlive++;
		}
		for (int k = 0; k < n; k++) {  // WALL2
			Vector3 position = new Vector3 (posX+Random.Range (-50.0f, -40.0f), posY+Random.Range (2.0f, 4.0f), posZ+Random.Range (-50.0f, 50.0f));
			GameObject ghost = (GameObject)Instantiate (ghostBot, position, Quaternion.Euler (0, 0, Random.Range (0.0f, 360.0f)));
			//numGhostsAlive++;
			print ("DONE 2");
		}

		for (int k = 0; k < n; k++) { // WALL3
			Vector3 position = new Vector3 (posX+Random.Range (-50.0f, 50.0f), posY+Random.Range (2.0f, 4.0f), posZ+Random.Range (40.0f, 50.0f));
			GameObject ghost = (GameObject)Instantiate (ghostBot, position, Quaternion.Euler (0, 0, Random.Range (0.0f, 360.0f)));
			//numGhostsAlive++;
			print ("DONE 3");
		}
	}

	void GenerateMore(){
		if (numGhostsAlive < numGhostsPerDirection * 3) {
			GenerateGhosts (numGhostsPerDirection/4);  // the average number of ghosts should stay the same
			//print ("DONE whatever");
		}
	}


}

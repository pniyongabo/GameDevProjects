using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubesGenerator : MonoBehaviour {

	public float sizeOfCube = 1f;
	public Material blockMaterial;
	public Material tigerMaterial;
	// Use this for initialization
	void Awake () {
		int randTigerX  = Random.Range(-14, 14);
		int randTigerY  = Random.Range(-14, -9);
		GameObject tiger = GameObject.CreatePrimitive(PrimitiveType.Cube);
		tiger.transform.position = new Vector3((float)randTigerX, (float)randTigerY, 0);

		tiger.GetComponent<Renderer>().material = tigerMaterial;
		tiger.tag = "tiger";

		for (int x = -14; x <= 14; x++)
		{
			for (int y = -14; y <= 10; y++)
			{
				float rand = Random.Range(0.0f, 1.0f);
				float offset = Random.Range (-0.2f, 0.2f);
				//Random rand = new Random();
				if (rand >= 0.25f && (x != randTigerX || y != randTigerY)) 
				{
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.tag = "block";
					cube.GetComponent<Renderer> ().material = blockMaterial;
					cube.transform.position = new Vector3((float)x, (float)y, offset);
					
				}
			}
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

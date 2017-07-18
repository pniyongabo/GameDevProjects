using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpacechip : MonoBehaviour {
	public float speed = 15f;
	public GameObject bombGenerator;

	public float radius = 5.0F;
	public float power = 10.0F;

	// Use this for initialization


	
	// Update is called once per frame
	void Update () {
		transform.Translate  (new Vector3 (
			Input.GetAxis("Horizontal") * speed,
			Input.GetAxis("Vertical") * speed,
			0
		) * Time.deltaTime);




		if (Input.GetKeyDown (KeyCode.Space)) {
			//Vector3 loc = transform.position;
			//loc.z -= 5f;
			Instantiate (bombGenerator, transform.position, Quaternion.identity);
			//GameObject bomb = Instantiate(bombGenerator, loc, Quaternion.identity) as GameObject;

			//Vector3 pos = bomb.transform.position;
			//pos.x += speed * Time.deltaTime;
			//bomb.transform.position = pos;

			//pos.x += 10f;

			//bomb.GetComponent<Rigidbody>().AddExplosionForce(power, pos, radius, 3.0F);;

			//bomb.GetComponent<Rigidbody>().AddForce(transform.forward * speed * 2);
			//print("space arrow key is held down");


		
		}


	}

	void OnCollisionEnter (Collision col)

	{
		print (col.gameObject.name);
//		if(col.gameObject.name == "prop_powerCube")
//		{
//			Destroy(col.gameObject);
//		}
	}
}

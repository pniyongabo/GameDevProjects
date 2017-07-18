using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 15f;
	public GameObject ProjectilePrefab;

	public float radius = 5.0F;
	public float power = 10.0F;
	public float fuel = 100f;
	public GameObject fuelMeter;
	public GameObject sprite;
//	private Rigidbody rigidbody = GetComponent<Rigidbody>();
	// Use this for initialization
//	void Awake(){
//		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
//		rb.AddForce (Vector3.down * 10000f);
//	}

	void start() {
		Vector3 dir = new Vector3 (0, -1000, 0);
		sprite.transform.LookAt (dir * 1000);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 ft = fuelMeter.transform.localScale;
		ft.y = fuel / 100;
		fuelMeter.transform.localScale = ft;


		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		Vector3 dir = new Vector3 (x * speed, y * speed, 0);
		sprite.transform.LookAt (dir * 1000);

		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddForce (Vector3.up * 1f);

		if (fuel > 0) {
			rb.AddForce(dir);
		}
		rb.velocity *= 0.99f;
		if (x != 0 || y != 0) {
			fuel = Mathf.Max(0f, fuel - 0.09f);
		}

		if (fuel == 0) {
			SceneManager.LoadScene("_gameover_");
		}




		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos = gameObject.transform.position;
			Vector3 cursor = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 direction = cursor - pos;
			direction.z = 0;
			GameObject projectile = (GameObject)Instantiate (ProjectilePrefab, pos, Quaternion.identity);
			projectile.GetComponent<Rigidbody> ().velocity = direction * 10f;
		}

//		if (Input.GetKeyDown (KeyCode.Space)) {
//			//Vector3 loc = transform.position;
//			//loc.z -= 5f;
//			Instantiate (bombGenerator, transform.position, Quaternion.identity);
//			//GameObject bomb = Instantiate(bombGenerator, loc, Quaternion.identity) as GameObject;
//
//			//Vector3 pos = bomb.transform.position;
//			//pos.x += speed * Time.deltaTime;
//			//bomb.transform.position = pos;
//
//			//pos.x += 10f;
//
//			//bomb.GetComponent<Rigidbody>().AddExplosionForce(power, pos, radius, 3.0F);;
//
//			//bomb.GetComponent<Rigidbody>().AddForce(transform.forward * speed * 2);
//			//print("space arrow key is held down");
//
//
//		
//		}


	}

	void OnCollisionEnter (Collision col)

	{
		if (col.gameObject.tag == "tiger") {
			SceneManager.LoadScene("_gamewon_");
		}
	}
}

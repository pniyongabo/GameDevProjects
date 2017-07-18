using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalKillerController : MonoBehaviour
{

	public float maxHealth = 200f;
	private float health;
	private bool moveRight = true;
	private float speed = 0.25f;
	private Vector3 startingPos;
	public float bulletspeed;
	public float bulletspawnspeed;
	public GameObject NKtentacle;
	public float mvtTime = 4f;

	private int goToCenter;


	public GameObject playerSprite;
	public GameObject wincanvas;
	public GameObject inner;
	public GameObject firepoints;
	public GameObject music;
	public GameObject spawner;

	// Use this for initialization
	void Start()
	{
		startingPos = transform.position;
		health = maxHealth;
		goToCenter = 1;
		StartCoroutine(moveNow(mvtTime));
	}

	// Update is called once per frame
	void Update()
	{
		if (health > maxHealth * 0.75f)
		{
			phase1Move();
		}
		else if (health > maxHealth * 0.45f)
		{
			phase2Move();
		}
		else {
			if (playerSprite != null)
			{
				transform.position = Vector3.MoveTowards(transform.position, playerSprite.transform.position, Time.deltaTime * 0.2f);
				if (transform.position.y < 2f)
				{
					transform.position = new Vector3(transform.position.x, 2f);
				}
			}
		}

	}

	//IEnumerator TentacleShooting
	public void ShootTentacletoPlayer()
	{
		GameObject tentacle = Instantiate(NKtentacle, transform.position, Quaternion.identity);
		tentacle.transform.up = playerSprite.transform.position - transform.position;
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "PlayerBullet")
		{
			health -= 1;
			Destroy(c.gameObject);
			StartCoroutine(hitEffect());
		}

		if (health <= 0)
		{
			inner.SetActive(false);
			enabled = false;
			wincanvas.SetActive(true);
			firepoints.SetActive(false);
			gameObject.GetComponent<rotationMovement>().rotationSpeed = 0;
			playerSprite.GetComponent<SpawnScript>().isfiring = false;
			GetComponent<PolygonCollider2D>().enabled = false;
			music.SetActive(false);
		}
	}


	IEnumerator moveNow(float timeInSecs){
		yield return new WaitForSeconds(timeInSecs);
		moveToOpp ();
		ShootTentacletoPlayer ();
		if (timeInSecs > 1) {
			StartCoroutine(moveNow (timeInSecs - 0.1f));
		} else {
			StartCoroutine(moveNow (timeInSecs));
		}
	}

	void moveToOpp(){
		print (goToCenter);
		if (goToCenter % 3 == 0 || goToCenter % 2 == 0) {  // once every 3 times
			Vector3 pos = new Vector3 (Random.Range (-4, 4), Random.Range (3.5f, 4.5f), 0);
			transform.position = pos;
		} else {
			Vector3 pos = new Vector3 (Random.Range (-4, 4), -Random.Range (4f, 4.5f), 0);
			transform.position = pos;
		}
		goToCenter += 1;
	}

	void phase1Move()
	{
		//ShootTentacle(playerSprite.transform.localPosition);
	}

	void phase2Move()
	{

	}

	IEnumerator hitEffect()
	{
		yield return new WaitForSeconds(0.10f);

	}

	public float getLifePercentage()
	{
		return (health / maxHealth *100);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostScript : MonoBehaviour {

	public float CircleRadius = 1;
	public float TurnChance = 0.05f;
	public float MaxRadius = 5;

	public float Mass = 15;
	public float MaxSpeed = 3;
	public float MaxForce = 15;

	private Vector3 velocity;
	private Vector3 wanderForce;
	private Vector3 target;

	private Vector3 targetObjPos;

	public GameObject targetObj;
	public float minDist;
	public float minFleeDist;
	public float speed;
	public float rotationSpeed;

	private float tempY;

	private bool isNear;
	private bool fleeing;

	// Use this for initialization
	void Start () {
		velocity = Random.onUnitSphere;
		wanderForce = GetRandomWanderForce();

		tempY = transform.position.y;
		fleeing = false;
	}
	
	// Update is called once per frame
	void Update () {
		print (fleeing);
		targetObjPos = new Vector3 (targetObj.transform.position.x, tempY, targetObj.transform.position.z);

		Collider[] colls = Physics.OverlapSphere (transform.position, minDist);
		int i = 0;
		//wander
		foreach (Collider coll in colls) {
			if (coll.tag == "Player") {
				i++;
			}
		}

		if (i > 0) {
			isNear = true;
		} else {
			isNear = false;
		}

		if (fleeing) {
//			print ("here");
//			Flee ();
		} else {
			if (isNear) {
				//seek
				Seek();
			} else {
				//wander
				var desiredVelocity = GetWanderForce ();
				desiredVelocity = desiredVelocity.normalized * MaxSpeed;

				var steeringForce = desiredVelocity - new Vector3(velocity.x, 0, velocity.z);
				steeringForce = Vector3.ClampMagnitude (steeringForce, MaxForce);
				steeringForce /= Mass;

				velocity = Vector3.ClampMagnitude (new Vector3(velocity.x, 0, velocity.z) + steeringForce, MaxSpeed);
				transform.position += velocity * Time.deltaTime;
				transform.position = new Vector3 (transform.position.x, tempY, transform.position.z);
				transform.forward = velocity.normalized;
			}
		}
	}

	//wander
	private Vector3 GetWanderForce()
	{
		if (transform.position.magnitude > MaxRadius)
		{
			//var directionToCenter = (target - transform.position).normalized;
			// + directionToCenter
			Vector3 newDir = new Vector3(Random.RandomRange(40, -40), tempY, Random.RandomRange(40, -40));

			var randDir = (newDir - transform.position).normalized;
			wanderForce = velocity.normalized + randDir;
		}
		else if (Random.value < TurnChance)
		{
			wanderForce = GetRandomWanderForce();
		}

		return wanderForce;
	}

	private Vector3 GetRandomWanderForce()
	{
		var circleCenter = velocity.normalized;
		var randomPoint = Random.onUnitSphere;

		var displacement = new Vector3(randomPoint.x, tempY, randomPoint.z) * CircleRadius;
		displacement = Quaternion.LookRotation(new Vector3(velocity.x, 0, velocity.z)) * displacement;

		var wanderForce = circleCenter + displacement;
		return wanderForce;
	}

	//seek
	private void Seek() {
		Vector3 desired = (targetObjPos - transform.position).normalized;
		GetComponent<Rigidbody>().AddForce(desired * speed - 
			new Vector3(GetComponent<Rigidbody>().velocity.x, tempY, GetComponent<Rigidbody>().velocity.z));

		Transform tempTrans = transform;
		tempTrans.LookAt (targetObj.transform.position);

		float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, new Vector3(tempTrans.position.x, transform.rotation.y, transform.rotation.z));
		//transform.rotation.Set (transform.rotation.x, -tempRot, 0, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation,
			q, Time.deltaTime * rotationSpeed);

		//transform.rotation.Set (transform.rotation.x, -tempRot, 0, 0);

	}

	//flee
	private void Flee() {
		Vector3 desired = (targetObjPos - transform.position);

		//new Vector3(GetComponent<Rigidbody>().velocity.x, tempY, GetComponent<Rigidbody>().velocity.z)

		float actual = desired.magnitude - minFleeDist;
		GetComponent<Rigidbody> ().AddForce (desired.normalized *
			speed - GetComponent<Rigidbody>().velocity);

		Transform tempTrans = transform;
		tempTrans.LookAt (-targetObj.transform.position);

		float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, new Vector3(tempTrans.position.x, transform.rotation.y, transform.rotation.z));
		//transform.rotation.Set (transform.rotation.x, -tempRot, 0, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation,
			q, Time.deltaTime * rotationSpeed);
	}

//	void OnDrawGizmos() {
//		Gizmos.color = Color.yellow;
//		Vector3 direction = GetComponent<Rigidbody> ().velocity;
//		Gizmos.DrawRay (transform.position, direction);
//
//		Gizmos.DrawWireSphere (transform.position, minDist);
//	}


	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Flashlight") {
			fleeing = true;
			print ("fleeing");
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.tag == "Flashlight") {
			fleeing = false;
			print ("not fleeing");
		}
	}
}

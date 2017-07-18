using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySteer.Behaviors;
using UnitySteer.Tools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (AutonomousVehicle))]

public class GhostSteer : MonoBehaviour {

	public enum PlayerState {
		Wander,
		Pursue,
		Flee
	}

	private PlayerState _state = PlayerState.Wander;

	public float pursuitDis;
	int health;
	public Text healthText;
	AudioSource bang;

	public AutonomousVehicle Veh { get; set; }
	public SteerForPursuit ForPursuit { get; private set; }
	public SteerForNeighborGroup ForNeighbors { get; private set; }
	public SteerForWander ForWander { get; private set; }
	public SteerForEvasion ForEvasion { get; private set; }
	public Radar Rad { get; private set; }
	public RandomizeStartPosition Rand { get; private set; }

	public float OriginalSpeed { get; private set; }
	public float OriginalTurnTime { get; private set; }

	private List<DetectableObject> detectVehicles;

	public PlayerState State
	{
		get { return _state; }
		set { SetState(value); }
	}

	public bool isNear;
	public bool fleeing;

	//public int HealthDec;
	//public Text skillGT;
	float _healthDecDelay = 5f;

	private Vector3 posi;

	// Use this for initialization
	private void Awake() {
		fleeing = false;

		healthText = GameObject.Find ("HealthNum").GetComponent<Text> ();

		print ("Before" + posi);

        ForPursuit = GetComponent<SteerForPursuit>();
        ForNeighbors = GetComponent<SteerForNeighborGroup>();
        ForWander = GetComponent<SteerForWander>();
        ForEvasion = GetComponent<SteerForEvasion>();
		Veh = GetComponent<AutonomousVehicle>();
		Rad = GetComponent<Radar> ();
		Rand = GetComponent<RandomizeStartPosition> ();
		Rand.Radius = new Vector3 (50, 1, 50);

		transform.position = transform.position + posi;

		print ("After" + transform.position);

		OriginalSpeed = Veh.MaxSpeed;
		OriginalTurnTime = Veh.TurnTime;

		health = 7;
		bang = GetComponent<AudioSource> ();

		PlayerPrefs.SetInt ("Health", health);

		healthText.text = PlayerPrefs.GetInt ("Health").ToString();
    }
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			//print ("health");
			SceneManager.LoadScene ("GameOver");
		}

		Collider[] colls = Physics.OverlapSphere (transform.position, pursuitDis);
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
			this.State = PlayerState.Flee;
			ForEvasion.Menace = GameObject.FindGameObjectWithTag ("Flashlight").GetComponent<PassiveVehicle> ();
			print(GameObject.FindGameObjectWithTag ("Flashlight").name);
			print ("Flee");
		} else {
			if (isNear) {
				this.State = PlayerState.Pursue;
				ForPursuit.Quarry = GameObject.FindGameObjectWithTag ("Player").GetComponent<DetectableObject> ();
				print("near");
			} else {
				this.State = PlayerState.Wander;
				print("wander");
			}
		}
			

	}

	private void SetState(PlayerState state)
	{
		Veh.MaxSpeed = OriginalSpeed;
		Veh.TurnTime = OriginalTurnTime;
		_state = state;
		switch (_state)
		{
		case PlayerState.Wander:
			break;
		case PlayerState.Pursue:
			Veh.MaxSpeed *= 1.75f;
			Veh.TurnTime *= 0.95f;
			break;
		case PlayerState.Flee:
			Veh.MaxSpeed *= 2f;
			break;
		}
		ForPursuit.enabled = State == PlayerState.Pursue;
		ForWander.enabled = State == PlayerState.Wander;
		ForNeighbors.enabled = State != PlayerState.Flee;
		ForEvasion.enabled = State == PlayerState.Flee;

	}

//	void OnTriggerEnter(Collider coll) {
//		if (coll.tag == "Flashlight") {
//			fleeing = true;
//			//Destroy(gameObject);
//		}
//
//		if (coll.tag == "Player") {
//			StartCoroutine(HealthDecEnumerator());
//		}
//	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Flashlight") {
			
			fleeing = true;
		}

		if (coll.tag == "Player") {
			print (this.gameObject.transform.position);
			StartCoroutine(HealthDecEnumerator());
		}


	}

	void OnTriggerExit(Collider coll) {
		if (coll.tag == "Flashlight") {
			fleeing = false;
		}
	}
		
	private void OnEnable() {
		
	}

	private void OnDisable() {
		
	}

	IEnumerator HealthDecEnumerator() {
		health  = PlayerPrefs.GetInt ("Health") -1 ;
		PlayerPrefs.SetInt ("Health", health);
		bang.Play ();
		healthText.text = health + "";
		//int tempH = PlayerPrefs.GetInt ("Skill");
		//PlayerPrefs.SetInt ("Skill", tempH - HealthDec);
		//skillGT.text = PlayerPrefs.GetInt ("Skill").ToString ();
		//print (skillGT.text);
		yield return new WaitForSeconds (_healthDecDelay);
	}

	public void SetPosition(Vector3 pos) {

		posi = pos;
	}
}

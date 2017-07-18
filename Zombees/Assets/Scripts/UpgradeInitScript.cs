using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class UpgradeInitScript : MonoBehaviour {

	string[] upgradeTypes = {"Increase Honey Strength", "Increase Hive Life","Increase Drop Strength", "Increase Bee Speed"};

	Dictionary<string,GameObject> upgradeMap = new Dictionary<string,GameObject>();
	Dictionary<string, System.Action> upgradeFunc = new Dictionary<string, System.Action>();

	public Button button1;
	public Button button2;
	public Button button3;

	private GameObject storage;
	private UnityAction action1;
	private UnityAction action2;
	private UnityAction action3;

	// Use this for initialization
	void Start () {
		shuffleList (upgradeTypes);
		upgradeMap.Add ("Increase Honey Strength", Resources.Load<GameObject> ("HoneyBulletPrefab"));
		upgradeFunc.Add ("Increase Honey Strength", addHoneySlow);
		upgradeMap.Add ("Increase Hive Life", Resources.Load<GameObject> ("Beehive"));
		upgradeFunc.Add ("Increase Hive Life", addBeeHiveLife);
		upgradeMap.Add ("Increase Drop Strength", Resources.Load<GameObject> ("StingingBee"));
		upgradeFunc.Add ("Increase Drop Strength", decBounceFactor);
		upgradeMap.Add ("Increase Bee Speed", Resources.Load<GameObject> ("BeePlayer"));
		upgradeFunc.Add("Increase Bee Speed", addBeeSpeed);
//		spriteUpgrade.Add (Resources.Load<GameObject> ("HoneyBulletPrefab"));
//		spriteUpgrade.Add (Resources.Load<GameObject> ("BeeLife"));
//		spriteUpgrade.Add (Resources.Load<GameObject> ("Beehive"));

		button1.GetComponentInChildren<Text>().text = upgradeTypes [0];
		button2.GetComponentInChildren<Text>().text = upgradeTypes [1];
		button3.GetComponentInChildren<Text>().text = upgradeTypes [2];

		Vector3 pos1 = new Vector3 (-3.9f,1, -1);
		Instantiate (upgradeMap[upgradeTypes[0]], pos1, Quaternion.identity);

		Vector3 pos2 = new Vector3 (0, 1, -1);
		Instantiate (upgradeMap[upgradeTypes[1]], pos2, Quaternion.identity);

		Vector3 pos3 = new Vector3 (3.9f, 1, -1);
		Instantiate (upgradeMap[upgradeTypes[2]], pos3, Quaternion.identity);

		storage = GameObject.FindWithTag ("Storage");

//		button1.onClick.AddListener (addHoneySlow);
//		button2.onClick.AddListener (addBeeHiveLife);
//		button3.onClick.AddListener (decBounceFactor);
//		button1.onClick.AddListener (upgradeMap [upgradeTypes [0]]);
//		button1.onClick.AddListener (upgradeMap [upgradeTypes [1]]);
//		button1.onClick.AddListener (upgradeMap [upgradeTypes [2]]);
		action1 = new UnityAction(upgradeFunc[upgradeTypes[0]]);
		action2 = new UnityAction(upgradeFunc[upgradeTypes[1]]);
		action3 = new UnityAction(upgradeFunc[upgradeTypes[2]]);

		button1.onClick.AddListener (action1);
		button2.onClick.AddListener (action2);
		button3.onClick.AddListener (action3);

	}

	void shuffleList(string[] l) {
		for (int i = 0; i < l.Length; i++) {
			string temp = l [i];
			int random = Random.Range (i, l.Length);
			l [i] = l [random];
			l [random] = temp;
		}
	}



	void loadScene() {
		storage.GetComponent<StorageScript> ().increaseLevel ();
        if (storage.GetComponent<StorageScript>().returnmode())
        {
            SceneManager.LoadScene("1PlayerModeWave" + storage.GetComponent<StorageScript>().getLevel());
        }
        else if (!storage.GetComponent<StorageScript>().returnmode())
        {
            SceneManager.LoadScene("2PlayerModeWave" + storage.GetComponent<StorageScript>().getLevel());
        }
    }

	void addHoneySlow() {
		storage.GetComponent<StorageScript> ().increaseHoneySlow ();
		loadScene ();
	}

	void addBeeHiveLife() {
		storage.GetComponent<StorageScript> ().increaseHiveHealth ();
		loadScene ();
	}

	void decBounceFactor() {
		storage.GetComponent<StorageScript> ().decreaseBounceFactor ();
		loadScene ();
	}

	void addBeeSpeed() {
		storage.GetComponent<StorageScript> ().increaseBeeSpeed ();
		loadScene ();
	}
}

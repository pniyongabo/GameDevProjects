﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ZoombeesGenerator : MonoBehaviour {

	public GameObject zombee1;
	public GameObject zombee2;

	//int widthPlay;
	//int heightPlay;

	float height;
	float width;
	public static int curNumZombees;
    public static int zombeesKilled;

    public int reqzombeesKilled;
	public int maxZombees;
	public int minZombees;
	public int numZombeesPerIter;

    private int hivehealth;
    public int shakespeed;

    public GameObject healthtext;
    public GameObject killedtext;

    public GameObject hivesprites;
    public GameObject tenhealthhive;
    public GameObject sevenhealthhive;
    public GameObject fourhealthhive;
    public GameObject onehealthhive;

	private GameObject storage;
   

	// Use this for initialization
	void Start () {
        //DONT DESTROY ON SCENE CHANGE
        //DontDestroyOnLoad(gameObject);
		//widthPlay = Screen.width;
		//heightPlay = Screen.height;

		storage = GameObject.FindWithTag ("Storage");
		height = Camera.main.orthographicSize * 2.0f;
		width = height * Screen.width / Screen.height;

		curNumZombees = 0;
		//maxZombees = 20;
		//minZombees = 15;
		numZombeesPerIter = maxZombees-minZombees;
		reqzombeesKilled = 10;

		if (SceneManager.GetActiveScene ().name == "1PlayerMode") {
			reqzombeesKilled = 10; //10
			generateZombees (maxZombees);
		} else if (SceneManager.GetActiveScene ().name == "1PlayerModeWave2") {
			reqzombeesKilled = 25; //25
            maxZombees = 2;
            minZombees = 1;
			generateZombees (maxZombees);
		} else if (SceneManager.GetActiveScene ().name == "1PlayerModeWave3") {
            reqzombeesKilled = 40; //40
            maxZombees = 3;
            minZombees = 2;
            generateZombees (maxZombees);
		}
        else if (SceneManager.GetActiveScene().name == "1PlayerModeWave4")
        {
            reqzombeesKilled = 60; //60
            maxZombees = 4;
            minZombees = 3;
            generateZombees(maxZombees);
        }
        else if (SceneManager.GetActiveScene().name == "1PlayerModeWave5")
        {
            reqzombeesKilled = 100; //100
            maxZombees = 6;
            minZombees = 4;
            generateZombees(maxZombees);
        }
        else if (SceneManager.GetActiveScene().name == "2PlayerMode")
        {
            reqzombeesKilled = 15; //25
            maxZombees = 2;
            minZombees = 1;
            generateZombees(maxZombees);
        }
        else if (SceneManager.GetActiveScene().name == "2PlayerModeWave2")
        {
            reqzombeesKilled = 40; //100
            maxZombees = 3;
            minZombees = 2;
            generateZombees(maxZombees);
        }
        else if (SceneManager.GetActiveScene().name == "2PlayerModeWave3")
        {
            reqzombeesKilled = 60; //60
            maxZombees = 4;
            minZombees = 3;
            generateZombees(maxZombees);
        }
        else if (SceneManager.GetActiveScene().name == "2PlayerModeWave4")
        {
            reqzombeesKilled = 100; //60
            maxZombees = 6;
            minZombees = 4;
            generateZombees(maxZombees);
        }
        else if (SceneManager.GetActiveScene().name == "2PlayerModeWave5")
        {
            reqzombeesKilled = 200; //60
            maxZombees = 7;
            minZombees = 5;
            generateZombees(maxZombees);
        }
        print (storage.GetComponent<StorageScript> ().getHiveHealth ());
		hivehealth = storage.GetComponent<StorageScript> ().getHiveHealth ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        hivesprites.transform.position = new Vector3(.1f * Mathf.Sin(Time.time * shakespeed),0f);

        while (curNumZombees < maxZombees)
        {
			generateZombees(maxZombees-curNumZombees);

		}

        healthtext.GetComponent<TextMeshPro>().SetText("" + hivehealth);
        killedtext.GetComponent<TextMeshPro>().SetText("" + zombeesKilled + "/" + reqzombeesKilled);

        if (zombeesKilled >= reqzombeesKilled)
        {
            zombeesKilled = 0;
			SceneManager.LoadScene ("UpgradeScene");
            //NextWave();
        }
    }
		

//    void NextWave()
//    {
//        if(SceneManager.GetActiveScene().name == "1PlayerMode")
//        {
//            SceneManager.LoadScene("1PlayerModeW2");
//            reqzombeesKilled = 5;
//            maxZombees = 3;
//            numZombeesPerIter = 2;
//        }
//        if (SceneManager.GetActiveScene().name == "1PlayerModeW2")
//        {
//            SceneManager.LoadScene("1PlayerModeW3");
//            reqzombeesKilled = 15;
//            maxZombees = 5;
//            numZombeesPerIter = 3;
//        }
//        if (SceneManager.GetActiveScene().name == "1PlayerModeW3")
//        {
//            SceneManager.LoadScene("1PlayerModeW4");
//        }
//        if (SceneManager.GetActiveScene().name == "1PlayerModeW4")
//        {
//            SceneManager.LoadScene("1PlayerModeW5");
//        }
//        if (SceneManager.GetActiveScene().name == "1PlayerModeW5")
//        {
//            SceneManager.LoadScene("1PlayerModeVictory");
//        }
//    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //When zombees impact destroy them and hive takes damage
        if (col.gameObject.tag == "Zombee")
        {
            curNumZombees--;
            hivehealth--;
            if(hivehealth == 7)
            {
                tenhealthhive.SetActive(false);
                sevenhealthhive.SetActive(true);
            }
            if (hivehealth == 4)
            {
                sevenhealthhive.SetActive(false);
                fourhealthhive.SetActive(true);
            }
            if (hivehealth == 1)
            {
                fourhealthhive.SetActive(false);
                onehealthhive.SetActive(true);
            }

			if (hivehealth == 0) {
                hivehealth = 10;
                zombeesKilled = 0;
				SceneManager.LoadScene ("gameOver");
			}

            Debug.Log("Hivehealth = " + hivehealth);
            StartCoroutine(shakehive());
            Destroy(col.gameObject);
        }
    }
	void generateZombees(int n){
		for (int i=0; i< n; i++){
			GameObject zombee;
			if (Random.value <= 0.5)
            {
				zombee = Instantiate (zombee1, getRandomLeftPos (), transform.rotation);
			}
            else
            {
				zombee = Instantiate (zombee2, getRandomRightPos (), Quaternion.Euler(0, 180, 0));
			}
			//zombee.AddComponent<ZombeeMvt>();
			//zombee.GetComponent<ZombeeMvt> ().target = this.gameObject;
			curNumZombees++;
		}
	}

    IEnumerator shakehive()
    {
        shakespeed = 20;
        yield return new WaitForSeconds(1);
        shakespeed = 0;
        transform.position = new Vector3(0, 0);
    }

	Vector3 getRandomLeftPos(){
		Vector3 pos = transform.position;
		Vector3 left = new Vector3 (pos.x-width/2,Random.Range(-height/2, height/2) + 1, pos.z+0);
		return left;
	}

	Vector3 getRandomRightPos(){
		Vector3 pos = transform.position;
		Vector3 right = new Vector3 (pos.x+width/2,Random.Range(-height/2, height/2) + 1, pos.z+0);
		return right;
	}
}

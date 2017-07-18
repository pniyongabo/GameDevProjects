using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorageScript : MonoBehaviour {

	private int beeHealth;
	private float honeySlow;
	private int hiveHealth;
	private float bounceFactor;
	private float beeSpeed;
    public static bool oneplayerornot;

	private int level;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		beeHealth = 3;
		honeySlow = 0.065f;
		hiveHealth = 10;
		level = 1;
		bounceFactor = 0.18f;
		beeSpeed = 0.125f;
        if (SceneManager.GetActiveScene().name == "1PlayerMode")
        {
            oneplayerornot = true;
        }
        if (SceneManager.GetActiveScene().name == "2PlayerMode")
        {
            oneplayerornot = false;
        }
	}

    void Update ()
    {
        if (SceneManager.GetActiveScene().name == "gameOver")
        {
            beeHealth = 3;
            honeySlow = 0.065f;
            hiveHealth = 10;
            level = 1;
            bounceFactor = 0.18f;
            beeSpeed = 0.125f;
        }
    }

    public bool returnmode()
    {
        return oneplayerornot;
    }
	public void increaseBeeSpeed() {
		beeSpeed += 0.05f;
	}

	public float getBeeSpeed() {
		return beeSpeed;
	}
	
	public void increaseBeeHealth() {
		beeHealth += 1;
	}

	public void increaseHoneySlow() {
		honeySlow += 0.1f;
	}

	public void increaseHiveHealth() {
		hiveHealth += 2;
	}

	public int getBeeHealth() {
		return beeHealth;
	}

	public float getHoneySlow() {
		return honeySlow;
	}

	public int getHiveHealth() {
		return hiveHealth;
	}

	public int getLevel() {
		return level;
	}

	public void increaseLevel() {
		level += 1;
	}

	public void decreaseBounceFactor() {
		bounceFactor -= 0.06f;
	}

	public float getBounceFactor() {
		return bounceFactor;
	}
}

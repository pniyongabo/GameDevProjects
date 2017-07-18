using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneMgr : MonoBehaviour {

	public Button StartButton;
    public Button StartButton2P;
	public Button QuitButton;
	public Button InfoButton;
	public Button howToButton;
    public Button toMenuButton;
	public Button creditsButton;

	public GameObject hive;

	void Awake(){
		StartButton.onClick.AddListener(LoadGame);
        StartButton2P.onClick.AddListener(LoadGame2P);
        QuitButton.onClick.AddListener(HandleQuit);
		InfoButton.onClick.AddListener (LoadHowTo);
        toMenuButton.onClick.AddListener(toMenu);
		creditsButton.onClick.AddListener (toCredits);
		//print ("hello 22");

//		if (SceneManager.GetActiveScene ().name == "gameOver") {
//			InfoButton.enabled = false;
//		} else {
//			QuitButton.enabled = true;
//		}
		//InfoButton.onClick.AddListener(LoadInfo);
		hive = GameObject.FindWithTag("Hive");
		if (hive != null) {
			print ("hi");
		}
		Destroy (hive);
	}


	void LoadGame()
	{
		SceneManager.LoadScene("1PlayerMode");
		//print ("hello LoadGame");
	}

    void LoadGame2P()
    {
        SceneManager.LoadScene("2PlayerMode");
    }

	//	void LoadEnd()
	//	{
	//		SceneManager.LoadScene("GameOver");
	//	}

	void HandleQuit()
	{
		Application.Quit();
		//print ("hello Quit");
	}

	void LoadHowTo()
	{
		SceneManager.LoadScene("how2play");
		//print ("hello Info");
	}

    void toMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	void toCredits()
	{
		SceneManager.LoadScene("credits");
	}
}


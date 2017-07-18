using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneMgr : MonoBehaviour {

	public Button StartButton;
	public Button QuitButton;
	public Button InfoButton;

	void Start () {
		//print ("hello 1");
	}


	void Awake(){
		StartButton.onClick.AddListener(LoadGame);
		QuitButton.onClick.AddListener(HandleQuit);
		//print ("hello 22");

		if (SceneManager.GetActiveScene ().name == "gameOver") {
			InfoButton.enabled = false;
		} else {
			QuitButton.enabled = true;
		}
		InfoButton.onClick.AddListener(LoadInfo);

		//print ("hello 23");
	}


	void LoadGame()
	{
		
		SceneManager.LoadScene("_Scene_0");
		//print ("hello LoadGame");
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

	void LoadInfo()
	{
		SceneManager.LoadScene("gameInfo");
		//print ("hello Info");
	}


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public Button StartButton;
	public Button QuitButton;
	//public Button WelcomeHowTo;
	//public Button WelcomeQuit;


	// Use this for initialization
	void Start () {

	}
	void Awake(){

		StartButton.onClick.AddListener(loadGame);
		//WelcomeHowTo.onClick.AddListener(loadHowTo);
//		if (GameObject.Find(QuitButton.name) != null) {
//			QuitButton.onClick.AddListener(HandleQuit);
//		}
		QuitButton.onClick.AddListener(HandleQuit);
	}


	// Update is called once per frame
//	void Update () {
//
//	}

	void loadGame()
	{
		SceneManager.LoadScene("_scene_1");
	}
//	void loadHowTo()
//	{
//		SceneManager.LoadScene("HowTo");
//	}

	void HandleQuit()
	{
		Application.Quit();
	}

//	void loadStart()
//	{
//		SceneManager.LoadScene("GameStart");
//	}
}


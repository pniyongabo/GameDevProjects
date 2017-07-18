using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour {

	public Button StartButton;
	public Button QuitButton;

	void Start () {
	}

	
	void Awake(){
		StartButton.onClick.AddListener(LoadGame);
		QuitButton.onClick.AddListener(HandleQuit);

		if (SceneManager.GetActiveScene ().name == "MainMenu") {
			QuitButton.enabled = true;
		} else {
			QuitButton.enabled = true;
		}
	}
		

	void LoadGame()
	{
		SceneManager.LoadScene("_scene_0");
	}
//	void LoadEnd()
//	{
//		SceneManager.LoadScene("GameOver");
//	}

	void HandleQuit()
	{
		Application.Quit();
	}

}

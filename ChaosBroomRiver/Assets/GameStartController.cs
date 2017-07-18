using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour {

    public Button WelcomeStart;
	public Button WelcomeHowTo;
    public Button WelcomeQuit;


	// Use this for initialization
	void Start () {
		
	}
	void Awake(){

		WelcomeStart.onClick.AddListener(loadGame);
		WelcomeHowTo.onClick.AddListener(loadHowTo);
		WelcomeQuit.onClick.AddListener(HandleQuit);
	}
    
	
	// Update is called once per frame
	void Update () {

	}

    void loadGame()
    {
        SceneManager.LoadScene("ChaosBroomRiver");
    }
    void loadHowTo()
    {
        SceneManager.LoadScene("HowTo");
    }

    void HandleQuit()
    {
        Application.Quit();
    }

    void loadStart()
    {
        SceneManager.LoadScene("GameStart");
    }
}

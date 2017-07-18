using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToController : MonoBehaviour {

    public Button HowTo_Play;
	public Button HowTo_Back;
	public Button HowTo_Quit;

	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		HowTo_Play.onClick.AddListener(loadGame);
		HowTo_Back.onClick.AddListener(loadStart);
		HowTo_Quit.onClick.AddListener(HandleQuit);
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

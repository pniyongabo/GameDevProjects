using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	public Text currentScore;
	public Text highScore;
	public Button Restart;

	// Use this for initialization
	void Start () {



	}
	void Awake(){
		Restart.onClick.AddListener(loadGame);
		currentScore.text = "Score: " + PlayerController.score;
		highScore.text = "HighScore: " + PlayerController.highScore;
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

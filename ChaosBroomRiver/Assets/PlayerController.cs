using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;
    float speed = 50f;
    GameObject player;
    Rigidbody rb;
    Vector3 start = Vector3.zero;


    //public static GameObject[] coins;  // planning to use this for a line renderer between all coins !!

    public Text livesText;
    public int lives;
	public static int highScore; 

    public Text scoreText;
    public static int score;

    public Text timeText;
    private int time;

	//HighScore high = new HighScore();

    void Awake()
    {
		if (PlayerPrefs.HasKey ("HighScoreOfGame")) {
			highScore = PlayerPrefs.GetInt ("HighScoreOfGame");
			// print ("highscore " + highScore);
		} 
		else {
			highScore = 0; 
			PlayerPrefs.SetInt ("HighScoreOfGame", highScore);
		}
        player = GameObject.Find("Player");
        moveDirection = player.transform.TransformDirection(start);
        rb = GetComponent<Rigidbody>();
        time = 60;  // we have 110 coins currently
        lives = 3;
        score = 0;
        SetScore();
        setLives();
        InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);
		//coins = GameObject.FindGameObjectsWithTag("Coin");  // array containing all coins
		//print ("There are " + coins.Length.ToString() + " coins in the game");
    }

    void decreaseTimeRemaining()
    {
        time -= 1;
        setTime();
    }


    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;
		//print ("highscore " + highScore);
        //rb.AddForce(0, 0, 10);        
        controller.Move(moveDirection * Time.deltaTime);
		if (score > PlayerPrefs.GetInt("HighScoreOfGame"))
		{
			highScore = score;
			PlayerPrefs.SetInt("HighScoreOfGame", highScore);
		}
        //PlayerPrefs.SetInt("HighScoreOfGame", score);
		if (time <= 0 || player.transform.position.y < -5 || lives <= 0) {

			PlayerPrefs.SetInt ("HighScoreOfGame", highScore);
			SceneManager.LoadScene ("GameOver");
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScore();
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            setLives();
        }
    }

    void SetScore()
    {
        
        scoreText.text = "Score: " + score.ToString();
	
    }

    void setLives()
    {

        livesText.text = "Lives: " + lives.ToString();

    }

    void setTime()
    {
        timeText.text = "Time: " + time.ToString();
		//GetScore.highscoretext.text = "High Score: " + GetScore.highscore.ToString();
    }
}

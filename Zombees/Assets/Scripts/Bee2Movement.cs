using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee2Movement : MonoBehaviour {

	public float force;
    private float speed;
    public float forcefallstrength;
	private Rigidbody2D rigid;
	private char currentDirection;
	private Vector3 screenDimension;
    public GameObject flyupArrows;

	public GameObject storage;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		currentDirection = 'D';
		screenDimension = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
        //might preserve location when switching waves
        //print (screenDimension.x);
		//print (screenDimension.y);
		storage = GameObject.FindWithTag("Storage");
		speed = storage.GetComponent<StorageScript> ().getBeeSpeed ();
        if (SceneManager.GetActiveScene().name == "how2play")
        {
            speed = .125f;
            Debug.Log("asdjaif");
        }
	}
	
	// Update is called once per frame
	void Update () {
		//if (GetComponent<BeeMechanics> ().beeHealth > 0) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
                if (transform.position.y < 6 && transform.position.y > 0)
                {
                    rigid.AddForce(transform.up * force, ForceMode2D.Impulse);
                    rigid.velocity = Vector2.ClampMagnitude(rigid.velocity, 6f);
                }

                if (transform.position.y < 0)
                {
                    rigid.AddForce(transform.up * force * 1.5f, ForceMode2D.Impulse);
                    rigid.velocity = Vector2.ClampMagnitude(rigid.velocity, 6.5f);
                }
            }
			if (Input.GetKey (KeyCode.LeftArrow)) {

                //limits movement to edge of screen
                if (transform.position.x > -10)
                {
                    transform.position += new Vector3(-speed, 0f, 0f);
                    currentDirection = 'A';
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
			}

			if (Input.GetKey (KeyCode.RightArrow)) {

                //limits movement to edge of screen
                if (transform.position.x < 10)
                {
                    transform.position += new Vector3(speed, 0f, 0f);
                    currentDirection = 'D';
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
			}

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rigid.AddForce(transform.up * -forcefallstrength, ForceMode2D.Force);
                //currentDirection = 'D';
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if(transform.position.y < - 5)
            {
                flyupArrows.SetActive(true);
            }

            if(transform.position.y >  -4)
            {
                flyupArrows.SetActive(false);
            }
	}

    void FixedUpdate()
    {
        float y = transform.position.y;
        float x = transform.position.x;
        //y = Mathf.Clamp(y, screenDimension.y * -1f, screenDimension.y * 0.90f);
        //x = Mathf.Clamp(x, screenDimension.x * -1f * 0.95f, screenDimension.x * 0.95f);
        transform.position = new Vector3(x, y, 0);
    }

	public char getCurrentDirection() {
		return currentDirection;
	}
}

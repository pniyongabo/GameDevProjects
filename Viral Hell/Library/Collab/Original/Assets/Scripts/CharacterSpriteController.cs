using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSpriteController : MonoBehaviour {

    public GameObject VirusSprite;
    public GameObject CellSprite;
    public bool shrinkingcell;
    public bool growingcell;
    public GameObject gameovercanvas;

	public int health;

	List<GameObject> lives = new List<GameObject>();

	// Use this for initialization
	void Start () {
		health = 5; // if you change this, check the lives (sprites) of the virus objects

		foreach (Transform tran in transform)
		{
			if (tran.gameObject.tag == "Dot") {
				lives.Add (tran.gameObject);
			}
		}
		//print (lives.Count);
	}
	
	// Update is called once per frame
	void Update () {

        VirusSprite.transform.Rotate(Vector3.forward * Time.deltaTime * 20f);
        if(shrinkingcell && !(CellSprite.transform.localScale.x < 0))
        {
            CellSprite.transform.localScale -= new Vector3(.5f, .5f);
            if (CellSprite.transform.localScale.x < 0) shrinkingcell = false;
        }
        
        if (growingcell && !(CellSprite.transform.localScale.x > 10))
        {
            CellSprite.transform.localScale += new Vector3(.5f, .5f);
            if (CellSprite.transform.localScale.x > 10) growingcell = false;
        }

        if(health <= 0)
        {
            Camera.main.orthographicSize = 5f;
        }
    }

    public void zoomSpritesIn()
    {
        shrinkingcell = true;
        //CellSprite.SetActive(false);
        GetComponent<SpawnScript>().isfiring = false;
    }
    
    public void zoomSpritesOut()
    {
        growingcell = true;
        CellSprite.SetActive(true);
        GetComponent<SpawnScript>().isfiring = true;
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "MacrophageBullet" || col.gameObject.tag == "WhiteBloodCell" || col.gameObject.tag == "InfectedWhite"
			|| col.gameObject.tag == ("DendriticBullet")  || col.gameObject.tag == ("Tentacle")) {
			if (health >= 2 && lives.Count >=1) {
				lives [health - 2].GetComponent<SpriteRenderer> ().enabled = false;
			}
				
			if (SceneManager.GetActiveScene().name == "scene3") {
				health -= 2;
			} else {
				health -= 1;
			}

			StartCoroutine (hitEffect ());
			if (col.gameObject.tag == "MacrophageBullet" || col.gameObject.tag == "WhiteBloodCell" || col.gameObject.tag == "InfectedWhite") {
				Destroy (col.gameObject);
			}
				

		}

		if (health <= 0) {
            Camera.main.orthographicSize = 5f;
            Camera.main.transform.position = new Vector3(0, 0, -10f);
            Camera.main.GetComponent<ZoomPlayer>().zoomingout = true;
			Destroy (this.gameObject);
            gameovercanvas.SetActive(true);
			//SceneManager.LoadScene("gameover");
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "Macrophage" || col.gameObject.tag == "Dendritic" || col.gameObject.tag == "NaturalKiller") {
			Destroy (this.gameObject);
			gameovercanvas.SetActive(true);
		}

	}


	IEnumerator hitEffect() {
        yield return new WaitForSeconds(0.10f);
        /*
		Behaviour h = (Behaviour)GetComponent ("Halo");
		h.enabled = true;
		yield return new WaitForSeconds (0.10f);
		h.enabled = false;
        */
    }
}

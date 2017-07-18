using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingAttack : MonoBehaviour {

    public GameObject ParentBee;
	public float bounceFactor;

	public GameObject storage;

	// Use this for initialization
	void Start () {
		storage = GameObject.FindWithTag ("Storage");
		bounceFactor = storage.GetComponent<StorageScript> ().getBounceFactor ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        print("stinghit");
        if (col.gameObject.tag == "Zombee")
        {
            print("zombee!!");
            //Destroy(col.gameObject);
            col.gameObject.GetComponent<Animator>().Stop();
            //adds extra force if bouncing off dead bee
            if(col.gameObject.GetComponent<ZombeeMvt>().speed == 0)
            {
                ParentBee.GetComponent<Rigidbody2D>().AddForce(transform.up * bounceFactor, ForceMode2D.Impulse);
            }
            col.gameObject.GetComponent<ZombeeMvt>().speed = 0;
            col.gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);
            //col.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
            ParentBee.GetComponent<Rigidbody2D>().AddForce(transform.up * bounceFactor, ForceMode2D.Impulse);
            ZoombeesGenerator.curNumZombees -= 1;
            ZoombeesGenerator.zombeesKilled++;
            /*
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            */
        }
    }
}

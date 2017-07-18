using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombeeMvt : MonoBehaviour {
	GameObject target;
	public float speed;

	// Use this for initialization
	void Start () { 
		target = GameObject.Find("Beehive");
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		//print (target.transform.position);
		Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, step);
		transform.position = pos;

       if(transform.position.y < -4)
        {
            gameObject.transform.rotation = Quaternion.Euler(180, 0, 0);
            gameObject.GetComponent<Animator>().Stop();
            //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            if (speed != 0)
            {
                ZoombeesGenerator.curNumZombees--;
                ZoombeesGenerator.zombeesKilled++;
            }
            speed = 0;
        }
	}

    public void DecreaseSpeed(float speeddecrease)
    {
        if (speed > .3)
        {
            speed -= speeddecrease;
            Mathf.Clamp(speed, 0.4f, 1f);
        }

        if (speed < .3)
            speed = .3f;
    }

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Zombees") {
			Destroy (this);
		}
	}
}

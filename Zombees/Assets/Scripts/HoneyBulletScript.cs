using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBulletScript : MonoBehaviour {

	public bool isRightDirection;
	private Camera camera;

	private float cameraHeight;
	private float cameraWidth;

    public float speed;
    private float slowamount;
    public float knockdownamount;

	private GameObject storage;

	// Use this for initialization
	void Start () {
		storage = GameObject.FindWithTag ("Storage");
		camera = Camera.main;
		cameraHeight = 2f * camera.orthographicSize;
		cameraWidth = cameraHeight * camera.aspect;
		slowamount = storage.GetComponent<StorageScript> ().getHoneySlow ();
    }
	
	// Update is called once per frame
	void Update () {
		if (isRightDirection) {
			transform.position += new Vector3(speed, 0f, 0f);
		} else {
			transform.position -= new Vector3(speed, 0f, 0f);
		}
	}
	
    //makes Zombees fall downward when hit by honey
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Zombee")
        {
            col.gameObject.transform.position = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y - knockdownamount);
            col.gameObject.GetComponent<ZombeeMvt>().DecreaseSpeed(slowamount);
			Destroy(this.gameObject);
            /*
            gameObject.transform.parent = col.gameObject.transform;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            speed = 0;
            */

        }

    }


}

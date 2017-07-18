using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPlayer : MonoBehaviour {

    public bool zoomingin;
    public bool zoomingout;
    public bool trackingplayer;
    public GameObject playertarget;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Camera.main.orthographicSize <= 1.8f)
        {
            if (Camera.main.transform.position.y < -4.5 && playertarget.transform.position.y < -4.5)
            {
                Camera.main.transform.position = new Vector3(playertarget.transform.position.x, -4.51f, -10);
                trackingplayer = false;
            }
            else 
            {
                trackingplayer = true;
            }
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Camera.main.orthographicSize >= 5f)
                zoomingin = true;
            else if (Camera.main.orthographicSize <= 1.8f)
                zoomingout = true;

        }

		if(trackingplayer && !zoomingin) 
		{
			if (playertarget != null) {
				transform.position = new Vector3 (playertarget.transform.position.x, playertarget.transform.position.y, -10f);
			}
		}

		if(zoomingin && playertarget != null)
        {
            playertarget.GetComponent<CharacterSpriteController>().zoomSpritesIn();
            if (Camera.main.orthographicSize <= 1.8f)
            {
                zoomingin = false;
            }
            //Debug.Log("" + Camera.main.orthographicSize);
			Vector3 startVec = transform.position;
			Vector3 endVec = new Vector3 (playertarget.transform.position.x, playertarget.transform.position.y, -10f);
			transform.position = Vector3.Lerp (startVec, endVec, 0.1f);

           Camera.main.orthographicSize -= .08f;
			trackingplayer = true;
        }

		if(zoomingout && playertarget != null)
        {
            playertarget.GetComponent<CharacterSpriteController>().zoomSpritesOut();
            trackingplayer = false;
            //Debug.Log("" + Camera.main.orthographicSize);
			Vector3 startVec = transform.position;
			Vector3 endVec = new Vector3 (0f, 0f, -10f);
			transform.position = Vector3.Lerp (startVec, endVec, 0.1f);
            Camera.main.orthographicSize += .06f;
            if (Camera.main.orthographicSize >= 5f)
            {
                zoomingout = false;
            }
        }
	}
}

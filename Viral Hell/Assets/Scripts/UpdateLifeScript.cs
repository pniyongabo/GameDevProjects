using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateLifeScript : MonoBehaviour {

	public TextMeshPro tmp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag == "Macrophage") {
			tmp.SetText (Mathf.Clamp (GetComponent<MacrophageController> ().getLifePercentage (), 0f, 100f).ToString ("F1"));
		} else if (gameObject.tag == "Dendritic") {
			tmp.SetText (Mathf.Clamp (GetComponent<DendriticController> ().getLifePercentage (), 0f, 100f).ToString ("F1"));
		} else if (gameObject.tag == "NaturalKiller") {
			tmp.SetText (Mathf.Clamp (GetComponent<NaturalKillerController> ().getLifePercentage (), 0f, 100f).ToString ("F1"));
		} else if (gameObject.tag == "Cancer") {
			tmp.SetText (Mathf.Clamp (GetComponent<CancerController> ().getLifePercentage (), 0f, 100f).ToString ("F1"));
		}
	}
}

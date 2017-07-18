using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVscroll : MonoBehaviour {
	float secsPerScroll  = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer>();
		Material mat = mr.materials[0];
		//mat.GetTextureOffset("_MainTex");
		Vector2 offset = mat.mainTextureOffset;
		offset.x += Time.deltaTime / secsPerScroll;
		mat.mainTextureOffset = offset;
	}
}

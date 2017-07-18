﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVfollow : MonoBehaviour {

	public float parallax = 2f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer>();
		Material mat = mr.materials[0];
		//mat.GetTextureOffset("_MainTex");
		Vector2 offset = mat.mainTextureOffset;
		offset.x = transform.position.x / transform.localScale.x / parallax;
		offset.y = transform.position.y / transform.localScale.y / parallax;
		mat.mainTextureOffset = offset;
	}
}

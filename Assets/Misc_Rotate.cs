﻿using UnityEngine;
using System.Collections;

public class Misc_Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 50.0f * Time.deltaTime);
	}
}
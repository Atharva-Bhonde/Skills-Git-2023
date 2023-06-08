﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimation : MonoBehaviour {

	Animator MyAnimator;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			MyAnimator.SetBool ("walk", true);
		} else if (Input.GetKey (KeyCode.Space)) {
			MyAnimator.Play ("Jump");
		} else if (Input.GetKey (KeyCode.DownArrow)) {
		}
		else if (MyAnimator.GetBool ("dead") == false) 
		{
			MyAnimator.SetBool ("idle", true);
			MyAnimator.SetBool ("walk", false);
			MyAnimator.SetBool ("run", false);
		}

		else 
		{
			MyAnimator.SetBool ("walk", false);
		}


	}
}

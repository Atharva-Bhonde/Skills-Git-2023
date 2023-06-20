﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject alter;
	bool Spawned;
	Vector3 SpawnedPosition;
	// Use this for initialization
	void Start () {
		Spawned = false;
		SpawnedPosition = new Vector3 (14.478f, 4.748f, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnAlter(){
		if (Spawned == false) {
			Instantiate (alter, SpawnedPosition, Quaternion.identity);
			Spawned = true;
			Debug.Log ("Alter Spawned");
		}
	}
}

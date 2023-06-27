using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip coin;
	private AudioSource source;
	public AudioClip life;
	public AudioClip bomb;
	// Use this for initialization
	void Start () {
		source = GameObject.FindObjectOfType<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("bing!");
		source.PlayOneShot (coin, 1);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "extraLife") {
			source.PlayOneShot (life, 1);
		} 
		else if (other.gameObject.tag == "vulnerable") {
			source.PlayOneShot (bomb, 1);
		}
	}
}

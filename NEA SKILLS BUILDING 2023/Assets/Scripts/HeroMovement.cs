using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HeroMovement : MonoBehaviour {
	Rigidbody2D rb;
	float speed;
	public int lives;
	bool vulnerable;

	// Use this for initialization
	void Start () {
		speed = 5.1f;
		rb = GetComponent<Rigidbody2D>();
		lives = 2;
		vulnerable = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rb.AddForce (Vector2.up * 300);
		}
	}
	void resetPosition(){
		Debug.Log ("SPIKED!");
		transform.SetPositionAndRotation (new Vector3 (-5.43f, 0.86f, 0), Quaternion.identity);
		setLives ();
	}

	public void setLives(){
		lives -= 1;
		if (lives < 0 || vulnerable == true) {
			Debug.Log ("End of Game");
			SceneManager.LoadScene ("Lost");	
		}
	}

	private void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "extraLife") {
			lives += 1;
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "vulnerable"){
			Destroy (other.gameObject);
			vulnerable = true;
			Debug.Log ("vulnerable = true!");
			StartCoroutine ("VulnerableDebuff");
		}

	}
	IEnumerator VulnerableDebuff(){
		yield return new WaitForSeconds (5f);
		vulnerable = false;
		Debug.Log ("vulnerable = false!");
	}
}

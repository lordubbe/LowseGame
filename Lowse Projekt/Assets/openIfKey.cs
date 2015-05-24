using UnityEngine;
using System.Collections;

public class openIfKey : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame


	void OnCollisionStay2D(Collision2D col){
		if (col.transform.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.E) && player.GetComponent<playerItems>().hasKey) {
				Destroy (gameObject);
			}
		}
	}
}

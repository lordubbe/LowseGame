using UnityEngine;
using System.Collections;

public class SquirrelAI : MonoBehaviour {

	Rigidbody2D rb;
	GameObject player;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = (transform.position - player.transform.position).normalized * 10f;
	}
}

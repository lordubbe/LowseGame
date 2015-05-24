using UnityEngine;
using System.Collections;

public class DogAI : MonoBehaviour {

	public bool patrolling = true;
	public float dogSpeed;
	private Vector3 spawnPoint, walkPoint;
	private Rigidbody2D rb;
	public float patrolLength;
	public GameObject aggroCircle;	

	public enum State{
		patrolling, angry, chasing
	};
	public State dogState = State.patrolling;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spawnPoint = transform.position;
		StartCoroutine ("patrol");
	}
	
	// Update is called once per frame
	void Update () {

		if (patrolling) {
			dogState = State.patrolling;
		}


		if (patrolling) {
			if (new Vector2 (walkPoint.x - transform.position.x, walkPoint.y - transform.position.y).magnitude < 0.1f) {
				rb.velocity = Vector2.Lerp (rb.velocity, Vector2.zero, 0.8f);
			} else if (Vector3.Distance (transform.position, spawnPoint) < patrolLength - 2f) {
				rb.velocity = new Vector2 (walkPoint.x - transform.position.x, walkPoint.y - transform.position.y).normalized * dogSpeed;
			} 
		} else {
			if(aggroCircle.GetComponent<chaseObjectWithinAggroCircle>().chaseTarget == null){
				StartCoroutine ("patrol");
			}
		}
	}

	IEnumerator patrol(){
			while(patrolling){
				walkPoint = new Vector3(spawnPoint.x+Random.Range (-6f,6f), spawnPoint.y+Random.Range (-6f,6f), 0);
				yield return new WaitForSeconds (3);
			}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Player") {
			//damage player
			int heartCount = GameObject.Find("GameManager").GetComponent<GameManager>().playerHearts;
			if(heartCount >= 1){
				Destroy(GameObject.Find("GameManager").GetComponent<GameManager>().heartObjects[heartCount-1]);
				GameObject.Find("GameManager").GetComponent<GameManager>().playerHearts--;
			}

		} else if (col.transform.tag == "Cat") {
			//i dunno lol
		}
	}

}

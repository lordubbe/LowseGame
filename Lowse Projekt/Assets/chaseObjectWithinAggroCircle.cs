using UnityEngine;
using System.Collections;

public class chaseObjectWithinAggroCircle : MonoBehaviour {
	public GameObject dog;
	public GameObject dogGraphics;

	public float chaseSpeed;
	Rigidbody2D rb;
	bool isPatrolling;
	bool chase = false;
	public GameObject chaseTarget;
	Vector2 desiredPos;
	// Use this for initialization
	void Start () {
		rb = dog.GetComponent<Rigidbody2D> ();
		chaseTarget = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (chase) {
			if(new Vector2 (desiredPos.x - transform.position.x, desiredPos.y - transform.position.y).magnitude < 0.25f){
				rb.velocity = Vector2.Lerp (rb.velocity, Vector2.zero, 0.8f);
				dog.GetComponent<DogAI> ().dogState = DogAI.State.angry;
			}else{
			rb.velocity = new Vector2 (desiredPos.x - transform.position.x, desiredPos.y - transform.position.y).normalized * chaseSpeed;
			}
			
		} else if (!chase) {
			rb.velocity = Vector2.Lerp (rb.velocity, Vector2.zero, 0.8f);
		}
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player" || col.transform.tag == "Cat") {
			chaseTarget = col.gameObject;
			dog.GetComponent<DogAI> ().patrolling = false;
			GetComponent<CircleCollider2D> ().radius = 35f;

			//start attack move
			StartCoroutine("chaseTheTarget");
		}
	}

	void OnTriggerExit2D(Collider2D col){
		chase = false;	
		chaseTarget = null;
		dog.GetComponent<DogAI> ().patrolling = true;

		GetComponent<CircleCollider2D> ().radius = 18f;
	}

	IEnumerator chaseTheTarget(){
		while (chaseTarget != null) {
			dog.GetComponent<DogAI> ().dogState = DogAI.State.angry;
			yield return new WaitForSeconds (1f);
			dog.GetComponent<DogAI> ().dogState = DogAI.State.chasing;
			if (chaseTarget != null) {
				desiredPos = chaseTarget.transform.position + (chaseTarget.transform.position-transform.position).normalized*8f;
			} else {
				chase = false;
				yield return 0;
			}
			chase = true;
			yield return new WaitForSeconds (2f);
			chase = false;
		}
	}





}

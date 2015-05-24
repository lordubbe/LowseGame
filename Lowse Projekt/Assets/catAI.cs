using UnityEngine;
using System.Collections;

public class catAI : MonoBehaviour {

	public Sprite idleAnim_1, idleAnim_2, interested;
	public bool isIdle = true;
	public bool goToPlayer = false;
	private GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		StartCoroutine ("animate");
		StartCoroutine ("ai");
	}
	
	// Update is called once per frame

	void FixedUpdate(){
		if(goToPlayer  && player.GetComponent<playerSack>().isHoldingSack){
			transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
		}
	}


	IEnumerator ai(){
		while (true) {

			if(player.GetComponent<playerItems>().hasYarn && Vector3.Distance(player.transform.position, transform.position)<10){
				StopCoroutine("isIdle");
				goToPlayer = true;
			}



			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator animate(){
		while (isIdle) {
			GetComponent<SpriteRenderer>().sprite = idleAnim_1;
			yield return new WaitForSeconds(0.5f);
			GetComponent<SpriteRenderer>().sprite = idleAnim_2;
			yield return new WaitForSeconds(0.5f);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Player") {
			if(goToPlayer && player.GetComponent<playerSack>().isHoldingSack){
				player.GetComponent<playerItems>().hasCat = true;

				Destroy (gameObject);
			}
		}
	}

}

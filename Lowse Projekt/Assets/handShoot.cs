using UnityEngine;
using System.Collections;

public class handShoot : MonoBehaviour {

	public bool shoot = false;
	public Vector2 shootDir;
	public GameObject origPlace;
	private Vector3 destination;
	private bool animate;

	// Update is called once per frame
	void FixedUpdate () {
		if (shoot) {
			StartCoroutine("shootHand");
			shoot = false;
		}

		destination = transform.position+new Vector3 (shootDir.x, shootDir.y, 0);

		if (animate) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			transform.parent = null;
			GetComponent<Rigidbody2D>().AddForce((GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity)+shootDir*30f, ForceMode2D.Impulse);

		} else {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			transform.position = Vector3.Lerp (transform.position, origPlace.transform.position, 0.3f);
		}
	}

	IEnumerator shootHand(){
		animate = true;
		GetComponent<handStatus> ().canShoot = false;
		yield return new WaitForSeconds(0.2f);
		animate = false;
		StartCoroutine ("waitAndEnableShoot", 0.2f);

	}
	IEnumerator waitAndEnableShoot(float seconds){
		yield return new WaitForSeconds (seconds);
		GetComponent<handStatus> ().canShoot = true;
		transform.parent = origPlace.transform;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Animal") {
			if(animate){
				//kill the thing!
				col.GetComponent<AnimalHealth>().dead = true;
			}
		}
	}
}

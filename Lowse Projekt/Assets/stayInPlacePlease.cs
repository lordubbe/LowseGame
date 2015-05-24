using UnityEngine;
using System.Collections;

public class stayInPlacePlease : MonoBehaviour {
	public GameObject tree;
	Vector2 origPlace;
	public int numOfShakes;
	void Start(){
		origPlace = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector2.Lerp (transform.position, origPlace, 0.5f);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Player") {
			numOfShakes--;
			if(numOfShakes <=0){
				tree.GetComponent<treeAI>().dropSquirrel();
			}
		}
	}
}

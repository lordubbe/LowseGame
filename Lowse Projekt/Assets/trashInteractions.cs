using UnityEngine;
using System.Collections;

public class trashInteractions : MonoBehaviour {

	public Sprite trashClosed, trashEmpty, trashOpenYarn;
	public int numOfInteractions = 0;
	public bool hasYarn;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = trashClosed;
	}
	

	void OnTriggerStay2D(Collider2D col){
		if (col.transform.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) {
				numOfInteractions++;

				switch (numOfInteractions) {
				case 1:
					if (hasYarn) {
						GetComponent<SpriteRenderer> ().sprite = trashOpenYarn;
					} else {
						GetComponent<SpriteRenderer> ().sprite = trashEmpty;
					}
					break;
				case 2:
					if (hasYarn) {
						GetComponent<SpriteRenderer> ().sprite = trashEmpty;
						GameObject.FindWithTag("Player").GetComponent<playerItems>().hasYarn = true;
					}
					break;
				default:
					break;
				}


			}
		}

	}



}

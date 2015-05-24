using UnityEngine;
using System.Collections;

public class pickUpKey : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			col.GetComponent<playerItems>().hasKey = true;
			Destroy(this.gameObject);
		}
	}


}

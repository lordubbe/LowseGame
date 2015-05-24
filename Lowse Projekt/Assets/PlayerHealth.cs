using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int heartCount;
	public bool dead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (heartCount <= 0) {
			dead = true;
		}

		if (dead) {
			//then do something
		}
	}
}

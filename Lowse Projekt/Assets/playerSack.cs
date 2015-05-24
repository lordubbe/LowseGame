using UnityEngine;
using System.Collections;

public class playerSack : MonoBehaviour {

	public bool isHoldingSack = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			print ("sack: "+isHoldingSack);
			if(isHoldingSack){
				isHoldingSack = false;
			}else{
				isHoldingSack = true;
			}
		}
	}
}

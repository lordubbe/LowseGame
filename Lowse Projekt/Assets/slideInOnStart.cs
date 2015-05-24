using UnityEngine;
using System.Collections;

public class slideInOnStart : MonoBehaviour {

	Vector3 desiredPos;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		desiredPos = transform.localScale;
		transform.localScale = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale = Vector3.Lerp (transform.localScale, desiredPos, 0.06f);
	}
}

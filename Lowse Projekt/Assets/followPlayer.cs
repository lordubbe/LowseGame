using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public GameObject player;
	public float lerpTime;

	private Vector3 playerPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		transform.position = Vector3.Lerp (transform.position, new Vector3(playerPos.x, playerPos.y, -1), lerpTime/100);
	}
}

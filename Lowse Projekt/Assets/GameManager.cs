using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

public class GameManager : MonoBehaviour {
	public int playerHearts;
	public GameObject[] heartObjects;
	private GameObject player;
	public GameObject heartObj;
	public Sprite heartSprite;
	public GameObject heartSpawn;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		playerHearts = player.GetComponent<PlayerHealth>().heartCount;
		heartObjects = new GameObject[playerHearts];


		for (int i=0; i<playerHearts; i++) {
			heartObjects[i] = Instantiate(heartObj, new Vector3(heartSpawn.transform.position.x + (5*i), heartSpawn.transform.position.y	, 1), Quaternion.identity) as GameObject;
			heartObjects[i].transform.parent = Camera.main.transform;
			heartObjects[i].AddComponent<SpriteRenderer>();
			heartObjects[i].GetComponent<SpriteRenderer>().sprite = heartSprite;
			heartObjects[i].GetComponent<SpriteRenderer>().sortingOrder = 10000;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {



	
	}
}

using UnityEngine;
using System.Collections;

public class treeAI : MonoBehaviour {
	Vector2 origPlace;
	public bool hasSquirrel;
	private bool hadSquirrel;
	public GameObject squirrelObj;
	public Sprite squirrelAnim1, squirrelAnim2, fallSprite,normalSprite;
	public GameObject liveSquirrel;
	// Use this for initialization
	void Start(){
		if (hasSquirrel) {
			origPlace = transform.position;
			squirrelObj.SetActive (true);
			StartCoroutine("animateSquirrel");
		} else {
			squirrelObj.SetActive (false);
		}
	}
	// Update is called once per frame

	public void dropSquirrel(){
		if (hasSquirrel) {
			squirrelObj.SetActive (false);
			GameObject sq = Instantiate(liveSquirrel, squirrelObj.transform.position, Quaternion.identity) as GameObject;
			sq.GetComponent<SpriteRenderer>().sortingOrder = 100;
			StartCoroutine("squirrelFall", sq);
			hasSquirrel = false;
		}
	}

	IEnumerator animateSquirrel(){
		while (hasSquirrel) {
			squirrelObj.GetComponent<SpriteRenderer>().sprite = squirrelAnim1;
			yield return new WaitForSeconds(0.5f);
			squirrelObj.GetComponent<SpriteRenderer>().sprite = squirrelAnim2;
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator squirrelFall(GameObject sq){
		sq.GetComponent<Rigidbody2D>().gravityScale = 4f;
		sq.GetComponent<SpriteRenderer> ().sprite = fallSprite;
		yield return new WaitForSeconds(0.7f);
		sq.GetComponent<SpriteRenderer> ().sprite = normalSprite;
		sq.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		sq.GetComponent<Rigidbody2D>().gravityScale = 0f;
		sq.GetComponent<SquirrelAI> ().enabled = true;
			yield return 0;
	}
}

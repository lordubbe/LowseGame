using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private float xVel;
	private float yVel;

	public Sprite upSprite, downSprite, sideSprite;
	public Sprite upSackSprite, downSackSprite, sideSackSprite;
	public GameObject graphics;
	Vector3 moveVector;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		xVel = Input.GetAxis ("Horizontal");
		yVel = Input.GetAxis ("Vertical");

	

		if (Mathf.Abs(xVel) > Mathf.Abs(yVel)) {
			if (xVel < 0) {//walking left
				if(!GetComponent<playerSack> ().isHoldingSack){
					graphics.GetComponent<SpriteRenderer>().sprite = sideSprite;
				}else{
					graphics.GetComponent<SpriteRenderer>().sprite = sideSackSprite;
				}
				transform.localScale = new Vector3 (1, 1, 1);
			} else if (xVel > 0) {//walking right
				if(!GetComponent<playerSack> ().isHoldingSack){
					graphics.GetComponent<SpriteRenderer>().sprite = sideSprite;
				}else{
					graphics.GetComponent<SpriteRenderer>().sprite = sideSackSprite;
				}
				transform.localScale = new Vector3 (-1, 1, 1);
			} 
		} else if (Mathf.Abs(xVel) < Mathf.Abs(yVel)) {
			if (yVel > 0) {//walking up
				if(!GetComponent<playerSack> ().isHoldingSack){
					graphics.GetComponent<SpriteRenderer>().sprite = upSprite;
				}else{
					graphics.GetComponent<SpriteRenderer>().sprite = upSackSprite;
				}

			} else if (yVel < 0) {//walking down
				if(!GetComponent<playerSack> ().isHoldingSack){
					graphics.GetComponent<SpriteRenderer>().sprite = downSprite;
				}else{
					graphics.GetComponent<SpriteRenderer>().sprite = downSackSprite;

				}
			}
		}

		if (GetComponent<playerSack> ().isHoldingSack) {
			if(graphics.GetComponent<SpriteRenderer>().sprite == downSprite){
				graphics.GetComponent<SpriteRenderer>().sprite = downSackSprite;

			}else if(graphics.GetComponent<SpriteRenderer>().sprite == upSprite){
				graphics.GetComponent<SpriteRenderer>().sprite = upSackSprite;

			}else if(graphics.GetComponent<SpriteRenderer>().sprite == sideSprite){
				graphics.GetComponent<SpriteRenderer>().sprite = sideSackSprite;

			}
		}

		moveVector = new Vector3 (xVel * speed, yVel * speed, 0);

		GetComponent<Rigidbody2D> ().velocity = moveVector;


	}
}

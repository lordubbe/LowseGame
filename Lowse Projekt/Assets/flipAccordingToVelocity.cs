using UnityEngine;
using System.Collections;

public class flipAccordingToVelocity : MonoBehaviour {
	Rigidbody2D rb;
	public GameObject dogGraphics;

	public Sprite upSprite, downSprite, sideSprite;
	public Sprite upAngry, downAngry, sideAngry;
	public Sprite upChase, downChase, sideChase;

	
	
	public enum moveDir{ 
		left, right, up, down
	};
	moveDir dir;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {


		switch (dir) {
		case moveDir.down://DOWN-------------------------------------------
			if(GetComponent<DogAI>().dogState == DogAI.State.patrolling){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = downSprite;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.angry){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = downAngry;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.chasing){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = downChase;
			}
			break;
		case moveDir.up://UP---------------------------------------------
			if(GetComponent<DogAI>().dogState == DogAI.State.patrolling){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = upSprite;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.angry){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = upAngry;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.chasing){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = upChase;
			}
			break;
		case moveDir.left://LEFT-------------------------------------------
			if(GetComponent<DogAI>().dogState == DogAI.State.patrolling){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = sideSprite;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.angry){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = sideAngry;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.chasing){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = sideChase;
			}
			transform.localScale = new Vector3 (1, 1, 1);	
			break;
		case moveDir.right://RIGHT-------------------------------------------
			if(GetComponent<DogAI>().dogState == DogAI.State.patrolling){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = sideSprite;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.angry){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = sideAngry;
			}else if(GetComponent<DogAI>().dogState == DogAI.State.chasing){
				dogGraphics.GetComponent<SpriteRenderer> ().sprite = sideChase;
			}
			transform.localScale = new Vector3 (-1, 1, 1);
			break;
			
		}



		if (Mathf.Abs (rb.velocity.x) > Mathf.Abs (rb.velocity.y)) {//if moving more to the side than up or down
			if (rb.velocity.x > 0) {//going right
				dir = moveDir.right;
			} else if (rb.velocity.x < 0) {//going left
				dir = moveDir.left;

			} 
		} else{
			if (rb.velocity.y > 0) {//going up
				dir = moveDir.up;
			} else if (rb.velocity.y < 0) {//going down
				dir = moveDir.down;
			}
		}






	}
}

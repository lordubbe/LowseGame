using UnityEngine;
using System.Collections;

public class shootHands : MonoBehaviour {

	public GameObject leftHand, rightHand;
	public GameObject leftHandPlace, rightHandPlace;
	public float handReach;
	public float handSpeed;
	public float handAwayTime;
	private Vector2 shootDir;

	public Sprite leftHandSprite, rightHandSprite, upHandSprite, downHandSprite;

	private GameObject currentHand;
	private int handIndex;


	void Start(){
		leftHand.GetComponent<handShoot> ().origPlace = leftHandPlace;
		rightHand.GetComponent<handShoot> ().origPlace = rightHandPlace;

	}

	void Update(){

		if (GetComponent<playerSack> ().isHoldingSack) {
			leftHand.SetActive (false);
			rightHand.SetActive (false);
		} else {
			if(!rightHand.activeInHierarchy){
				rightHand.SetActive(true);
			}
			if(!leftHand.activeInHierarchy){
				leftHand.SetActive(true);
			}
		}


		if (handIndex > 1) {
			handIndex = 0;
		}
		if (handIndex == 0) {
			currentHand = leftHand;
		} else {
			currentHand = rightHand;
		}


		if (!GetComponent<playerSack> ().isHoldingSack) {

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				shootDir = new Vector2 (-1, 0);
				if (currentHand.GetComponent<handStatus> ().canShoot) {
					handIndex++;
					currentHand.GetComponent<handShoot> ().shoot = true;
					currentHand.GetComponent<handShoot> ().shootDir = shootDir;
					currentHand.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = leftHandSprite;
				}
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				shootDir = new Vector2 (1, 0);
				if (currentHand.GetComponent<handStatus> ().canShoot) {
					handIndex++;
					currentHand.GetComponent<handShoot> ().shoot = true;
					currentHand.GetComponent<handShoot> ().shootDir = shootDir;
					currentHand.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = rightHandSprite;
				}		
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				shootDir = new Vector2 (0, 1);
				if (currentHand.GetComponent<handStatus> ().canShoot) {
					handIndex++;
					currentHand.GetComponent<handShoot> ().shoot = true;
					currentHand.GetComponent<handShoot> ().shootDir = shootDir;
					currentHand.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = upHandSprite;
				}		
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				shootDir = new Vector2 (0, -1);
				if (currentHand.GetComponent<handStatus> ().canShoot) {
					handIndex++;
					currentHand.GetComponent<handShoot> ().shoot = true;
					currentHand.GetComponent<handShoot> ().shootDir = shootDir;
					currentHand.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = downHandSprite;
				}		
			}

		}

	}
	
}

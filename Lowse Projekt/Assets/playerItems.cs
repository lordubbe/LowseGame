using UnityEngine;
using System.Collections;

public class playerItems : MonoBehaviour {

	public bool hasYarn = false;
	public bool hasKey = false;
	public bool hasCat = false;
	public GameObject yarnIcon;
	public GameObject keyIcon;
	public ParticleSystem pickUpKeyParticles;

	public GameObject catSack;

	// Update is called once per frame
	void Update () {
		if (hasYarn) {
			if(!yarnIcon.activeInHierarchy){
				yarnIcon.SetActive(true);
				ParticleSystem parts = Instantiate(pickUpKeyParticles, yarnIcon.transform.position-new Vector3(0,0,-0.1f), Quaternion.identity) as ParticleSystem;
				parts.transform.parent= Camera.main.transform;
			}
		} else {
			yarnIcon.SetActive(false);
		}

		if (hasKey) {
			if(!keyIcon.activeInHierarchy){
				keyIcon.SetActive(true);
				ParticleSystem parts = Instantiate(pickUpKeyParticles, keyIcon.transform.position-new Vector3(0,0,-0.1f), Quaternion.identity) as ParticleSystem;
				parts.transform.parent= Camera.main.transform;
			}
		} else {
			keyIcon.SetActive(false);
		}

		if (hasCat) {
			catSack.SetActive (true);
		} else {
			catSack.SetActive(false);
		}
	}
}

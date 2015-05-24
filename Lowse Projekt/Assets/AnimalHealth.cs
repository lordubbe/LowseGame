using UnityEngine;
using System.Collections;

public class AnimalHealth : MonoBehaviour {
	public ParticleSystem deathParticles;
	public GameObject deathSprite;
	public bool dead = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			destroy();
		}
	}

	void destroy(){
		Instantiate (deathSprite, transform.position, Quaternion.identity);
		Instantiate (deathParticles, transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
}

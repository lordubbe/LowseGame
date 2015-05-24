using UnityEngine;
using System.Collections;

public class fadeOutAndDisappear : MonoBehaviour {


	void FixedUpdate () {
		transform.position += new Vector3 (0, 0.1f, 0);
		if (transform.childCount > 0) {
			transform.GetChild (0).GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, 0.01f);
			
			if (transform.GetChild (0).GetComponent<SpriteRenderer> ().color.a <= 0) {
				Destroy (this.gameObject);
			}
		} else if(GetComponent<SpriteRenderer> ().color != null) {
			GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, 0.01f);

			if (GetComponent<SpriteRenderer> ().color.a <= 0) {
				Destroy (this.gameObject);
			}

		}

	}
}

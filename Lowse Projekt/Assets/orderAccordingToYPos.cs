using UnityEngine;
using System.Collections;

public class orderAccordingToYPos : MonoBehaviour {

	public SpriteRenderer renderer;
	public int order;
	public int orderBias = 0;

	// Update is called once per frame
	void Update () {
		order = (int)transform.position.y;
		renderer.sortingOrder = Mathf.Abs (order+orderBias);
	}
}

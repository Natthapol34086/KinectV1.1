using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	Vector3 forceR = new Vector3 (-4, 0.0f,0.0f);
	Vector3 forceL = new Vector3 (4, 0.0f,0.0f);
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			print ("press space");
			transform.position += forceL;
		} 
		if (Input.GetKeyDown (KeyCode.RightArrow)){
			transform.position += forceR;
		}

	}
}

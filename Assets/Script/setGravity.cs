using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGravity : MonoBehaviour {

    public Vector3 v1;
	// Use this for initialization
	void Start () {

        Physics.gravity = v1;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 shootFront = new Vector3(0, 30, -80);
        collision.rigidbody.AddForce(shootFront);

    }

    // Update is called once per frame
    void Update () {
		
	}
}

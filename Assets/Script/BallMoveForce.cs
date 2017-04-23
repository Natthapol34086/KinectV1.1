using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveForce : MonoBehaviour {
    float time = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponent<ShootBall1>().enabled)
        {
            time += Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            if (time <= .75f)
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 10;
            else
                gameObject.GetComponent<BallMoveForce>().enabled = false;

        }
            
    }
}

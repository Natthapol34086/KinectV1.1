using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall1 : MonoBehaviour {
    public GameObject head;
    public GameObject hand;
    public GameObject racket;
    private Transform racketTrans;
    public float speed;
    private bool t = false;
    // Use this for initialization
    void Start () {
        racketTrans = racket.transform;
        
	}
	// Update is called once per frame
	void Update () {
        gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, 0);
        Rigidbody tmp = gameObject.GetComponent<Rigidbody>();
        float headY = head.transform.position.y;
        if(hand != null)
            gameObject.transform.position = hand.transform.position;
        if (hand.transform.position.y >= headY)//Throw up 
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<BallMoveForce>().enabled = true;
            gameObject.GetComponent<ShootBall1>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBall : MonoBehaviour {

    public GameObject ball;
    public GameObject cdt;
    public GameObject ground;
    private double timeLeft;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (ball.transform.position.y < 0 )
        {
            ball.GetComponent<Rigidbody>().useGravity = false;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<ShootBall>().enabled = false;
            ball.transform.position = new Vector3(0, 1, 0);
            
            //GameObject.Find("Count down Text").SetActive(true);
            cdt.GetComponent<Countdown_Timer>().timeLeft = 5.0f;
            cdt.GetComponent<Countdown_Timer>().enabled = true;

            cdt.GetComponent<Countdown_Timer>().check = true;
            cdt.GetComponent<Countdown_Timer>().transform.position = new Vector3(312.5f, 142.5f, 0.0f);

        }
    }
}

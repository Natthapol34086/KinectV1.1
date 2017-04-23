using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {
    public GameObject head;
    public GameObject racket;
    private Rigidbody rb;
    private Vector3 headP;
    private Vector3 racketP;
    [Range(1f, 10000f)]
    public float speed;
	// Use this for initialization
	void Start () {
        
    }


    // Update is called once per frame
    void Update () {

        if (head == null || racket == null)
            return;
        headP = head.transform.position;
        racketP = racket.transform.position;
        if (racketP.y >= headP.y && gameObject.transform.position.y > headP.y)
        {
            //gameObject.GetComponent<Rigidbody>().Sleep();
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed);
        }
            

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class forCollision : MonoBehaviour {
    int score;
    public Text text;
	// Use this for initialization
	void Start () {
        score = -1;
        upScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Vector3 shootBack = new Vector3(0, 20, 250);
            collision.rigidbody.AddForce(shootBack);
            upScore();
        }
    }

    void upScore()
    {
        score++;
        text.text = "YOUR SCORE IS : " + score.ToString();
    }
}

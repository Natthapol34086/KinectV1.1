using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown_Timer : MonoBehaviour {
    public Text time_countdown;
    public float timeLeft = 5.0f;
    public bool check = true;
    // Use this for initialization
    void Start () {
        time_countdown = GetComponent<Text>();
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        time_countdown.text = "Time Left:" + Mathf.Round(timeLeft);
        //print(time_countdown);

       
        if (timeLeft < 0 && check)
        {
            gameObject.transform.position = new Vector3(0, 1000, 0);
            Vector3 shoot = new Vector3(0, 0f, 40);
            GameObject.Find("Ball").GetComponent<Rigidbody>().useGravity = true;
            GameObject.Find("Ball").GetComponent<ShootBall>().enabled = true;
            GameObject.Find("Ball").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("Ball").GetComponent<Rigidbody>().AddForce(shoot * GameObject.Find("Ball").GetComponent<ShootBall>().speed);
            //gameObject.SetActive(false);
            check = false;
        }

    }
}

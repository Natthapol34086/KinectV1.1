using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Windows.Kinect;

public class forPlayer : MonoBehaviour {
    private GameObject RightHand;
    private GameObject RightWrist;
    private GameObject RightElbow;
    public Countdown_Timer t;
    public Text text;
    private int set;
    private int score;
    // Use this for initialization
    void Start () {
        score = 0;
        upScore();
	}



    void upScore()
    {
        text.text = "YOUR SCORE = " + score.ToString();
    }

    // Update is called once per frame
    void Update () {

        if (RightHand == null)
        {
            RightHand = GameObject.Find("HandRight");
            RightWrist = GameObject.Find("WristRight");
            RightElbow = GameObject.Find("ElbowRight");
        }
        else
        {
            
            gameObject.transform.position = new Vector3(RightElbow.transform.position.x,
                                                           RightElbow.transform.position.y,
                                                            RightElbow.transform.position.z);
            GameObject.Find("pan_1_pivot1").transform.position = new Vector3(RightHand.transform.position.x,
                                                           RightHand.transform.position.y,
                                                            RightHand.transform.position.z);
            
            Vector3 dir = (RightWrist.transform.position-RightElbow.transform.position).normalized;
          
            
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),Time.deltaTime*10);
            
            t.GetComponent<Countdown_Timer>().enabled = true;
            
            
        }

    }
       
}

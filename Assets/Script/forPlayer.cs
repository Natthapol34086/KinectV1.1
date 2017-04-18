using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Windows.Kinect;

public class forPlayer : MonoBehaviour {
    public GameObject RightHand;
    public GameObject RightWrist;
    public GameObject RightElbow;
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

        if (RightWrist == null || RightElbow == null )
        {
            return;
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
            if(GameObject.FindGameObjectWithTag("bodyTag") != null)
                t.GetComponent<Countdown_Timer>().enabled = true;
            
            
        }

    }
       
}

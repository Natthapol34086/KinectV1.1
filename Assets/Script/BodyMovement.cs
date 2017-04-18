using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyMovement: MonoBehaviour {
    public Text textDistance;
    public GameObject body;
    private GameObject SpineBase;
    private double distance;
    private Vector3 lastPosition;

    // Use this for initialization
    void Start () {
        distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (SpineBase == null)
        {
            SpineBase = GameObject.FindGameObjectWithTag("bodyTag").transform.GetChild(0).gameObject;
            lastPosition = SpineBase.transform.position;
        }
        else
        {
            gameObject.transform.position = SpineBase.transform.localPosition;
            distance += (int)(Vector3.Distance(gameObject.transform.position, lastPosition)*10)/100f;
            lastPosition = gameObject.transform.position;

        }
        textDistance.text = distance.ToString() + " m";
    }
}

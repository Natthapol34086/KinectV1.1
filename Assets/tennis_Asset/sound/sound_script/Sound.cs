using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	// Use this for initialization

	public GameObject ball ;
	public GameObject player;
	public AudioClip sound;
	private float player_pos ;
	private float ball_pos ;
	private bool onPlay = true;

	
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		player_pos = player.transform.position.x;
		ball_pos = ball.transform.position.x;
		print (player_pos+" "+ball_pos);
		if (player_pos > ball_pos - 1f && player_pos < ball_pos + 1f && onPlay) {
			//audio.PlayOneShot (sound);
			onPlay = false;
			print ("aaaaa");
		}
		if( player_pos - ball_pos > 3f || player_pos - ball_pos < -3f )
		{
			onPlay = true;
		}


	
	}
}

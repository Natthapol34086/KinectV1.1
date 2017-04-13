using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour {

	private Animator animator;
	public GameObject ball;
    public float mulF;
    private Rigidbody rb ;
	private	 float flip ;
	private bool inWalk1 = true;
	private bool inWalk2 = true;
	private bool inStay = true;
    bool isServe = true;
    bool isBackPlayer = false;
    bool isBackBot = false;




    const int countOfDamageAnimations = 3;
	int lastDamageAnimation = -1;

	void Awake () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}
	public void Stay () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0f);
	}
	
	public void Walk () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 0.6f);
	}
	
	public void Run () {
		animator.SetBool("Aiming", false);
		animator.SetFloat ("Speed", 2f);
	}
	
	public void Attack () {
		Aiming ();
		animator.SetTrigger ("Attack");
	}
	
	public void Death () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death"))
			animator.Play("Idle", 0);
		else
			animator.SetTrigger ("Death");
	}
	
	public void Damage () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death")) return;
		int id = Random.Range(0, countOfDamageAnimations);
		if (countOfDamageAnimations > 1)
			while (id == lastDamageAnimation)
				id = Random.Range(0, countOfDamageAnimations);
		lastDamageAnimation = id;
		animator.SetInteger ("DamageID", id);
		animator.SetTrigger ("Damage");
	}
	public void Jump () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", false);
		animator.SetTrigger ("Jump");
	}
	
	public void Aiming () {
		animator.SetBool ("Squat", false);
		animator.SetFloat ("Speed", 0f);
		animator.SetBool("Aiming", true);
	}
	
	public void Sitting () {
		animator.SetBool ("Squat", !animator.GetBool("Squat"));
		animator.SetBool("Aiming", false);
	}


	void Update(){

		//float num = Input.GetAxis ("Horizontal");
		//print (gameObject.transform.position.x);
		//print (num);
		//ball.transform.position.x = 15;
		float player_position = gameObject.transform.position.x;
		float ball_position = ball.transform.position.x;
       
		Vector3 forceR = new Vector3 (-0.01f, 0.0f,0.0f);
		Vector3 forceL = new Vector3 (0.01f, 0.0f,0.0f);
		Quaternion rolL = new Quaternion (0, 0.7f, 0, 0.7f);
		Quaternion rolR = new Quaternion (0, -0.7f, 0, 0.7f);
		Quaternion rolS = new Quaternion (0, 0, 0, 0);
        
        float yPos = 30f;
        float xPos = ball.transform.position.x;
        float random;
        if(xPos <0) { random = Random.Range(0,25); }
        else if(xPos>=0) { random = Random.Range(-25,0); }

        //Vector3 mainForce = new Vector3(ball.transform.position.x * mulF, yPosotion * mulF, 3.0f);
        
        if (ball.transform.position.z >= 123  )
        {
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (!isBackBot)
            {
                Vector3 forceBack = new Vector3(random * mulF, (yPos - ball.transform.position.y) * mulF, - (Mathf.Abs(xPos)+50) * mulF);
                ball.GetComponent<Rigidbody>().AddForce(forceBack);
                isBackBot = true;
            }
            isBackPlayer = false;
            isServe = false;
        }
        if (ball.transform.position.z <= -69 )
        {

            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (!isBackPlayer)
            {
                Vector3 forceBack = new Vector3(random * mulF, (yPos - ball.transform.position.y) * mulF, (Mathf.Abs(xPos) + 50) * mulF);
                ball.GetComponent<Rigidbody>().AddForce(forceBack);
                isBackPlayer = true;
            }
            isBackBot = false;
            isServe = false;

        }

        if (player_position > ball_position-1f && player_position < ball_position+1f) {
			if( inStay){
				flip = Time.time ;
			}
			
			if (Time.time - flip <= 0.4f){
				print(Time.time - flip);
				Stay();
				inStay = false;
			}
			else{
			//animator.applyRootMotion = false;
			Stay();
			transform.rotation = rolS;
			
			}


		}
		else if (player_position > ball_position) {
			transform.rotation = rolR;
			inStay = true;
			inWalk2 =true;
			if( inWalk1){
				flip = Time.time ;
				//animator.applyRootMotion = true;
			}

			if (Time.time - flip <= 0.01f){
				print(Time.time - flip);
				Walk();
				inWalk1 = false;
			}
			else{
				Run();
			}


			//transform.position += forceR;
		} else if (player_position < ball_position) {
			transform.rotation = rolL;
			inWalk1 =true;
			inStay = true;
			if( inWalk2){
				flip = Time.time ;
				//animator.applyRootMotion = true;
			}
			
			if (Time.time - flip <= 0.01f){
				print(Time.time - flip);
				Walk();
				inWalk2 = false;
			}
			else{
				Run();
			}
			//transform.position += forceL;

		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//print(animator.GetFloat("Speed"));
			Jump ();
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			print(animator.GetFloat("Speed"));
			animator.SetTrigger("Jump");
		}
	}

}

using UnityEngine;
using System.Collections;

public class AI_Movement : MonoBehaviour {


	public enum mode{wander, follow, stand};
	public mode currentMode;
	public GameObject tuva;
	bool justTurned;

	public float walkingSpeed;
	SpriteRenderer sprite;
	Animator anim;

	enum states { idle, right, left};
	states nextState;


	//GameObject[] wanderPattern;

	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		currentMode = mode.wander;
		nextState = states.idle;
	}
	

	void FixedUpdate () {


		Move(nextState);

		if(currentMode == mode.wander && justTurned == false){
			justTurned = true;
			int stateIndex = (int)nextState;
			int randomIndex = stateIndex;
			while(stateIndex == randomIndex){
				randomIndex = Random.Range(0,3);
			}
			nextState = (states)randomIndex;
			StartCoroutine(TurnNow());
		}else if(currentMode == mode.follow){
			
		}
	}
	IEnumerator TurnNow(){
		float r = Random.Range(0.0f, 2.0f);
		yield return new WaitForSeconds(r);
		justTurned = false;
	}
	void Move(states currentState)
	{
		switch (currentState)
		{
		case states.idle:
			anim.SetBool("Walk", false);
			break;

		case states.right:
			sprite.flipX = true;
			anim.SetBool("Walk", true);
			transform.Translate(Vector3.right * Time.deltaTime * walkingSpeed);
			break;

		case states.left:
			sprite.flipX = false;
			anim.SetBool("Walk", true);
			transform.Translate(-Vector3.right * Time.deltaTime * walkingSpeed);
			break;
		}
	}
}

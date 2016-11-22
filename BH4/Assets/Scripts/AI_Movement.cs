using UnityEngine;
using System.Collections;

public class AI_Movement : MonoBehaviour {

	Animator animator;
	public enum mode{wander, follow, stand};
	public mode currentMode;
	public float moveSpeed;
	//GameObject[] wanderPattern;

	void Start () {
		currentMode = mode.wander;
		animator = GetComponent<Animator>();
	}
	

	void FixedUpdate () {
		if(currentMode == mode.wander){
			transform.Translate(Vector3.right * Time.fixedDeltaTime * moveSpeed);
		}
	}
}

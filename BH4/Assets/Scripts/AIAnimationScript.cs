using UnityEngine;
using System.Collections;

public class AIAnimationScript : MonoBehaviour {

    float walkingSpeed;
    SpriteRenderer sprite;
    Animator anim;
    enum states { idle, right, left};

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        states nextState = states.idle;
        Move(nextState);	
	}


    void Move(states currentState)
    {
        switch (currentState)
        {
            case states.idle:
                //anim.SetBool("Walk", false);
                break;

            case states.right:
                sprite.flipX = false;
               // anim.SetBool("Walk", true);
                transform.Translate(Vector3.right * Time.deltaTime * walkingSpeed);
                break;

            case states.left:
                sprite.flipX = true;
               // anim.SetBool("Walk", true);
                transform.Translate(-Vector3.right * Time.deltaTime * walkingSpeed);
                break;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Movement_player : MonoBehaviour
{

	Animator anim;
    Rigidbody2D rigi;
    SpriteRenderer sprite;
    //BoxCollider2D collider;
	public float runSpeed = 1.2f;
	public float groundSpeed = 0.03f;
	public float frontGroundSpeed = 1f;
    public float jumpSpeed = 3f;
    public float fallSpeed = 5f;
	Vector3 localJumpDir;
    bool canJump;
    bool jumping;
    bool grounded;
    Vector3 jumpDirection;
    Vector3 jumpStart;
    enum States { Idle, Right, Left, Jump, Fall};
	public GameObject groundObject;
	public GameObject frontGroundObject;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        //collider = GetComponent<BoxCollider2D>();
        grounded = false;
        canJump = false;
        jumping = false;
    }
	
	// Update is called once per frame.
	void FixedUpdate () 
	{
        States movement = States.Idle;

        if (jumping)
        {
            movement = States.Jump;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                movement = States.Right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                movement = States.Left;
            }
            else
            {
                movement = States.Idle;
            }

            if (Input.GetKey(KeyCode.E) && canJump)
            {
                jump();
                movement = States.Jump;
            }
            if (rigi.velocity.y < -3)
            {
                movement = States.Fall;
                grounded = false;
            }
            else if (!grounded && rigi.velocity.y > -1)
            {
                movement = States.Idle;
                grounded = true;
            }
        }
        MoveCases (movement);
        //Debug.Log(movement);
    }
    //Vilken animation ska spelas
    void MoveCases (States movementCase)
	{
		switch (movementCase) 
		{

            case States.Idle: //Not moving
                anim.SetBool ("Run", false);
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", false);
                break;

            case States.Right: //Moving right
                sprite.flipX = false;
                transform.Translate(Vector3.right * Time.fixedDeltaTime * runSpeed);
				groundObject.transform.Translate(Vector3.left * Time.fixedDeltaTime * groundSpeed);
				frontGroundObject.transform.Translate(Vector3.left * Time.fixedDeltaTime * frontGroundSpeed);

                anim.SetBool("Run", true);
                break;

            case States.Left: //Moving left
                sprite.flipX = true;
                transform.Translate(-Vector3.right * Time.fixedDeltaTime * runSpeed);
				groundObject.transform.Translate(Vector3.right * Time.fixedDeltaTime * groundSpeed);
				frontGroundObject.transform.Translate(Vector3.right * Time.fixedDeltaTime * frontGroundSpeed);


                anim.SetBool("Run", true);
                break;

            case States.Jump: //Jumping
                transform.Translate((jumpDirection - jumpStart) * Time.fixedDeltaTime * jumpSpeed);
				if(jumpDirection.x < 0){
					groundObject.transform.Translate(Vector3.right * Time.fixedDeltaTime * groundSpeed);
					frontGroundObject.transform.Translate(Vector3.right * Time.fixedDeltaTime * frontGroundSpeed);

				}else{
					groundObject.transform.Translate(Vector3.left * Time.fixedDeltaTime * groundSpeed);
					frontGroundObject.transform.Translate(Vector3.left * Time.fixedDeltaTime * frontGroundSpeed);


				}
                anim.SetBool("Jump", true);
                break;

            case States.Fall: //Falling
                anim.SetBool("Fall", true);
                break;

            default:
                Debug.Log("Error Movement /n This state dose not exist" + gameObject);
                break;
		}
	}
    //Kan man hoppa?
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "JumpSpot") 
		{
            canJump = true;
            if (jumping)
            {
                jumping = false;
                rigi.gravityScale = 1;
                //collider.enabled = true;
                MoveCases(States.Idle);
            }
            if (other.transform.parent.GetChild(0) == other.transform)
            {
                jumpDirection = other.transform.parent.GetChild(1).gameObject.transform.position;
				localJumpDir = other.transform.parent.GetChild(1).gameObject.transform.localPosition;
                jumpStart = other.transform.parent.GetChild(0).gameObject.transform.position;
            }
            else
            {
                jumpDirection = other.transform.parent.GetChild(0).gameObject.transform.position;
				localJumpDir = other.transform.parent.GetChild(0).gameObject.transform.localPosition;
                jumpStart = other.transform.parent.GetChild(1).gameObject.transform.position;
            }
            Debug.Log("Jump Spot Enter " + gameObject);
		}
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "JumpSpot")
        {
            canJump = false;
            Debug.Log("Jump Spot Exit " + gameObject);
        }
    }

    void jump()
    {
        jumping = true;
        rigi.gravityScale = 0;
        //collider.enabled = false;
		if (localJumpDir.x > 0)
        {
			Debug.Log(localJumpDir.x);
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
	void Update(){
		Camera.main.transform.position = new Vector3 (transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

	}
}

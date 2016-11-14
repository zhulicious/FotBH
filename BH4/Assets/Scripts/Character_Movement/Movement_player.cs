using UnityEngine;
using System.Collections;

public class Movement_player : MonoBehaviour
{

	Animator anim;
    Rigidbody rigi;
	public float runSpeed = 5f;
    public float climbSpeed = 3f;
    public float fallSpeed = 5f;
    bool canClimb;
    bool climb;
    bool grounded;
    enum States { Idle, Right, Left, Hanging, Up, Down, Falling};

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
        climb = false;
        grounded = false;
        canClimb = false;
    }
	
	// Update is called once per frame.
	void FixedUpdate () 
	{
        States movement = States.Idle;

        if (climb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movement = States.Up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement = States.Down;
                if (canClimb)
                {
                    climb = false;
                    movement = States.Idle;
                }
            }
            else
            {
                movement = States.Hanging;
            }
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

            if (Input.GetKey(KeyCode.W) && canClimb)
            {
                climb = true;
                movement = States.Hanging;
            }
            if (rigi.velocity.y < -3)
            {
                movement = States.Falling;
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
        Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
    //Vilken animation ska spelas
    void MoveCases (States movementCase)
	{
		switch (movementCase) 
		{

            case States.Idle: //Not moving
                rigi.useGravity = true;
                anim.SetBool ("Run", false);
                anim.SetBool("Climb", false);
                anim.SetBool("Fall", false);
                break;

            case States.Right: //Moving right
                transform.localEulerAngles = new Vector3(0, 0, 0);
                transform.Translate(Vector3.right * Time.fixedDeltaTime * runSpeed);
                anim.SetBool("Run", true);
                break;

            case States.Left: //Moving left
                transform.localEulerAngles = new Vector3 (0, 180, 0);
                transform.Translate(Vector3.right * Time.fixedDeltaTime * runSpeed);
                anim.SetBool("Run", true);
                break;

            case States.Hanging: //Climbing but not moving
                rigi.useGravity = false;
                anim.SetBool("Climb", true);
                anim.SetBool("UpAndDown", false);
                break;

            case States.Up: //Climbing up
                rigi.useGravity = false;
                anim.SetBool("UpAndDown", true);
                transform.Translate(Vector3.up * Time.deltaTime * climbSpeed);
                break;

            case States.Down: //Climbing down
                rigi.useGravity = false;
                anim.SetBool("UpAndDown", true);
                transform.Translate(Vector3.down * Time.deltaTime * climbSpeed);
                break;

            case States.Falling: //Falling
                anim.SetBool("Fall", true);
                break;

            default:
                Debug.Log("Error Movement /n This state dose not exist" + gameObject);
                break;
		}
	}
    //Kan man klättra?
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ClimbSpot") 
		{
            canClimb = true;
            Debug.Log("Climb Spot Enter " + gameObject);
		}
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ClimbSpot")
        {
            canClimb = false;
            Debug.Log("Climb Spot Exit " + gameObject);
        }
    }
}

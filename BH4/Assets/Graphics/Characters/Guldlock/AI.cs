using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    public float speed = 1;
    public float height = 0;
    public float maxDistance = 5;
    public float minDistance = 3;
    public float minWaitTime = 0;
    public float maxWaitTime = 3;
    float waitTime;
    public float threshold = 0.1f;
    public bool rightSide;
    bool walking;
    public GameObject target;
    public Vector3 destination;
    Vector3 direction;
    SpriteRenderer sprite;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        walking = false;

        if (!rightSide)
        {
            SwapSide();
        }
        Invoke("setDestination", waitTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (walking)
        {
            anim.SetBool("Walk", true);//Sätt animation till walk. Animator heter anim
            Move();
        }
        else
        {
            anim.SetBool("Walk", false);//sätt animation till idle. Animator heter anim
        }
    }

    //Sätt nästa destination.
    void setDestination()
    {
        destination = new Vector3 (Random.Range(target.transform.position.x + minDistance, target.transform.position.x + maxDistance),height,0);
        if (destination.x - transform.position.x < 0)
        {
            direction = Vector3.left;
            sprite.flipX = false;
        }
        else
        {
            direction = Vector3.right;
            sprite.flipX = true;
        }
        walking = true;
    }

    public void setDestination(float x)
    {
        destination = new Vector3( x, height, 0);
        if (destination.x - transform.position.x < 0)
        {
            direction = Vector3.left;
            sprite.flipX = false;
        }
        else
        {
            direction = Vector3.right;
            sprite.flipX = true;
        }
        walking = true;
    }

    //Gå mot nästa destination.
    void Move()
    {
        if(CheckIfGrounded())
        {
            direction = -direction;
        }
        transform.Translate(direction * speed * Time.fixedDeltaTime);
        if (Mathf.Abs(transform.position.x - destination.x) <= threshold)
        {
            walking = false;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            Invoke("setDestination", waitTime);
        }
    }

    //Om objektet befinner sig på fel sida av det den förljer kan den byta.
    void SwapSide()
    {
        Debug.Log("Swap Side!");
        maxDistance = -maxDistance;
        minDistance = -minDistance;
        walking = false;
        waitTime = 0;
    }

    //Gå inte över ett stup.
    bool CheckIfGrounded()
    {
        bool ground = false;
        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            ground = true;
        }
        return ground;
    }
}

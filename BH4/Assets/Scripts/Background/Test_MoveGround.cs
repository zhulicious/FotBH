using UnityEngine;
using System.Collections;


//Script is attached to object (empty or not) which in turn contains other objects relative to it. 
//In this case parent object is ground 2, and children are stones and other objects that should be on that road (Ground). 
public class Test_MoveGround : MonoBehaviour {

    Transform ground;
    float ground_speed;

    void Start ()
    {
        ground_speed = 3f; // Should be a bit faster than the speed of the parallax: ground moving speed.
        ground = this.transform; 
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ground.position += (-Vector3.right) * Time.deltaTime * ground_speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            ground.position += (Vector3.right) * Time.deltaTime * ground_speed;
        }
    }
}

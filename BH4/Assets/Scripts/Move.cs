using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public GameObject player;

    private Transform cameraTransform;
    //public float movementS;

	// Use this for initialization
	void Start () {

        cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {

        cameraTransform.position = new Vector3(player.transform.position.x, cameraTransform.position.y, cameraTransform.position.z);

        //cameraTransform.position = player.transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * Time.deltaTime); 
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}

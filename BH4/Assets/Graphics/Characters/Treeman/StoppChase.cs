using UnityEngine;
using System.Collections;

public class StoppChase : MonoBehaviour {

    public bool sChase;


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Enemy")
        {
            sChase = true;
            Debug.Log(sChase + " " + "triggerd");
        }
    }

	// Use this for initialization
	void Start () {

    }
	
}

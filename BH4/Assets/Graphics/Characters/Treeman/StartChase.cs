using UnityEngine;
using System.Collections;

public class StartChase : MonoBehaviour {

    public bool sChase;


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Tuva")
        {
            sChase = true;
            Debug.Log(sChase + " " + "triggerd");
        }
    }

	// Use this for initialization
	void Start () {

        sChase = false;

    }
	
}

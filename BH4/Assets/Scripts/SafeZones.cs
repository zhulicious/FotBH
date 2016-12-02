using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZones : MonoBehaviour {

    public bool tuvaIsHere;

    void Start ()
    {
        tuvaIsHere = false;
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.gameObject.name == "Tuva")
        {
            Debug.Log("Tuva has entered");
            tuvaIsHere = true;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.name == "Tuva")
        {
            Debug.Log("Tuva has exited");
            tuvaIsHere = false;
        }
    }
}

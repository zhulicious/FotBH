using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyktgubbeENTRY : MonoBehaviour {
    public GameObject tuva;
    LyktGubbe mainScriptLyktgubbe;

    void Start ()
    {
        mainScriptLyktgubbe = GetComponent<LyktGubbe>();
        mainScriptLyktgubbe.enabled = false;

    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject == tuva)
        {
            mainScriptLyktgubbe.enabled = true;
            this.enabled = false;
        }
    }
}

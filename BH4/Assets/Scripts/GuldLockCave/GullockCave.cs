/*
        Script should be placed on GULDLOCK and will only be used in the cave scene. 

        This script requires for a gameobject to have 3 children in following order: colliders, closed*, and open*

        * = cage sprites. 

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullockCave : MonoBehaviour {

    public GameObject cage;
	public GameObject talkTuva;
	public GameObject backWithKeys;
	public GameObject dialogs;
    GameObject cageopen;
    GameObject cageclosed;
    GameObject cagecolliders;
    
    Vector3 cagePosition;
    Vector3 targetPosition;
    public Transform otherPosition;
    float speed;

    bool walking;
    AI guldLockAI;
    Animator animations;
    SpriteRenderer sr;


    void SetValues ()
    {
        speed = 2.3f * Time.deltaTime;
        walking = false;

        cagePosition = cage.transform.position;
        cagePosition.z = this.transform.position.z;
        cagePosition.y = this.transform.position.y;

        cagecolliders = cage.transform.GetChild(0).gameObject;
        cageclosed = cage.transform.GetChild(1).gameObject;
        cageopen = cage.transform.GetChild(2).gameObject;
        cageopen.SetActive(false);

    }

    void Start ()
    {
        guldLockAI = GetComponent<AI>();
        guldLockAI.enabled = false;
        animations = this.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
        SetValues();
        StartCoroutine("CaveSequence");
    }
    
    void LetTuvaOut ()
    {
        cageclosed.SetActive(false);
        cageopen.SetActive(true);
        cagecolliders.transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update ()
    {
        if (walking)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        }
    }

    IEnumerator CaveSequence ()
    {
        //Start: Guldlock waits 5sec, walks to a target position
        yield return new WaitForSeconds(30f);
        targetPosition = cagePosition;
        walking = true;
        animations.SetBool("Walk", true);
		targetPosition = new Vector3(targetPosition.x -3, targetPosition.y, targetPosition.z);
		yield return new WaitUntil(() => transform.position == targetPosition);
        walking = false;
        animations.SetBool("Walk", false);
		dialogs.GetComponent<Dialogs>().EventDialog(talkTuva);
        yield return new WaitForSeconds(75.0f);
        targetPosition = otherPosition.position;
        sr.flipX = false;
        walking = true;
        animations.SetBool("Walk", true);
        //go get the "key" and return
        yield return new WaitUntil(() => transform.position == targetPosition);
        sr.flipX = true;
        targetPosition = cagePosition;
        yield return new WaitUntil(() => transform.position == targetPosition);
        walking = false;
        animations.SetBool("Walk", false);
        LetTuvaOut();
		dialogs.GetComponent<Dialogs>().EventDialog(backWithKeys);
        yield return new WaitForSeconds(5.0f);
        guldLockAI.enabled = true;
        this.enabled = false;
    }
}

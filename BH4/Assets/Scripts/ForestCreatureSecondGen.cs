/*

            SCRIPT REQUIRES FOLLOWING:
                * GAMEOBJECT ARRAY CONTAINING "SAFEZONES" SCRIPT
                * TRANSFORM ARRAY CONTAINING "SPAWNPOINTS" FOR THE TREEMAN
                * TRANSFORM POINT ON THE SAME LANE AS PLAYER CHARACTER
                * TRANSFORM POINT WHERE THE ENEMY WILL RETURN TO


*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestCreatureSecondGen : MonoBehaviour {
    public SafeZones[] safeZones;
    public GameObject tuva;

    public Transform[] spawnPositions;
    int spawnIndexer = 0;
    Vector3 currentPosition;
    public Transform[] chasePosition;
    public Transform[] returnPosition;
    float speed;
    int maxDistance = 2;

    Animator animations;

    bool searching;
    bool chasing;
    bool walking;

    void Start ()
    {
        animations = GetComponent<Animator>();
        speed = 2.65f * Time.deltaTime;

        animations.SetBool("Turning", true);
        searching = false;
        chasing = false;
        walking = false;

    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        animations.SetBool("Turning", true);
        if (collider.gameObject.name == "Tuva")
        {
            searching = true;
            animations.SetBool("Searching", true);
        }
    }
    
    int distance (int posA, int posB)
    {
        return (posB - posA);
    }

    bool tuvaIsCloseBy ()
    {
        int newDis = distance((int)transform.position.x, (int)tuva.transform.position.x);
        return newDis < maxDistance;
    }

    bool capturedTuva ()
    {
        int newDis = distance((int)transform.position.x, (int)tuva.transform.position.x);
        return (newDis == 1);
    }

    bool tuvaisSafe ()
    {
        foreach (SafeZones sf in safeZones)
        {
            if (sf.tuvaIsHere)
            {
                return true;
            }
        }
        return false;
    }

    void Update ()
    {
        if (searching && tuvaIsCloseBy())
        {
            Debug.Log("searching && Tuvais close by");
            StartCoroutine("StartTheChase");
            if (tuvaisSafe ())
            {
                Debug.Log("StopCour");
                StopCoroutine("StartTheChase");
            }
        }
        if (chasing)
        {
            Debug.Log("chasing");
            transform.position += Vector3.right * speed;
            if (capturedTuva())
            {
                Debug.Log("catured, time to move");
                StartCoroutine("TimeToMoveOn");
            }
        }

        if (walking)
        {
            transform.position += Vector3.left * speed;
        }
        

    }

    IEnumerator StartTheChase ()
    {
        yield return new WaitForSeconds(4.0f);
        transform.position = chasePosition[spawnIndexer].position;
        animations.SetBool("Chasing", true);
        chasing = true;
        yield break;
    }

    IEnumerator TimeToMoveOn ()
    {
        chasing = false;
        animations.SetBool("Idle", true);
        animations.SetBool("Turning", true);
        animations.SetBool("Searching", true);
        animations.SetBool("Chasing", true);
        walking = true;
        yield return new WaitUntil(() => transform.position.x == returnPosition[spawnIndexer].position.x);
        walking = false;
        spawnIndexer++;
        transform.position = spawnPositions[spawnIndexer].position;
        animations.SetBool("Idle", true);
        yield break;
    }
}

using UnityEngine;
using System.Collections;

/*
*       This script will only be usedd for Tuva in the Main Menu.
*
*       Tuva's movement method (IEnumerator GetTuvaMoving) is based on the "positionIndexer" number. 
*
*/

public class TuvaMenuScript : MonoBehaviour {

    Transform tuva;
    float movingSpeed;
    Vector3 tuvaStartPosition;
    SpriteRenderer tuva_sprite;

    public Vector3[] positions;
    public int positionsIndexer;
    bool movingCharacter = false;
    
    TuvaButtonScript tbs;
    int keyIndexer;
    int defaultKeyIndexer = 0;

    Animator tuva_animator;

    void Start ()
    {
        tuva = GameObject.Find("Tuva").transform;
        tuva_sprite = tuva.GetComponent<SpriteRenderer>();
        tuvaStartPosition = tuva.transform.position;
        tbs = GetComponent<TuvaButtonScript>();
        tuva_animator = GetComponent<Animator>();
        movingSpeed = 2.0f;
        keyIndexer = positionsIndexer + 1;
        StartCoroutine("GetTuvaMoving");

    }

    void Update ()
    {
        if (movingCharacter)
        {
            tuva.position = Vector3.MoveTowards(tuva.position, positions[positionsIndexer], movingSpeed * Time.deltaTime);
        }
    }

    IEnumerator GetTuvaMoving()

    {
        yield return new WaitForSeconds(1.0f);
        movingCharacter = true;
        tuva_animator.SetBool("Run", true);
        tbs.DisplayKeyButtons(keyIndexer);
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        tbs.DisplayKeyButtons(defaultKeyIndexer);
        movingCharacter = false;
        tuva_animator.SetBool("Run", false);
        positionsIndexer++;
        keyIndexer++;
        tuva_sprite.flipX = true;
        yield return new WaitForSeconds(2.0f);
        movingCharacter = true;
        tuva_animator.SetBool("Run", true);
        tbs.DisplayKeyButtons(keyIndexer);
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        movingCharacter = false;
        tuva_animator.SetBool("Run", false);
        positionsIndexer++;
        keyIndexer++;
        tbs.DisplayKeyButtons(defaultKeyIndexer);
        tuva_sprite.flipX = false;
        yield return new WaitForSeconds(2.0f);
        movingCharacter = true;
        tuva_animator.SetBool("Run", true);
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        movingCharacter = false;
        tuva_animator.SetBool("Run", false);
        tbs.DisplayKeyButtons(keyIndexer);
        yield break;

    }

    public void StopWalkingTuva()
    {
        StopCoroutine("GetTuvaMoving");

        movingCharacter = false;
        tuva.transform.position = tuvaStartPosition;
        tbs.DisplayKeyButtons(defaultKeyIndexer);
    }
}

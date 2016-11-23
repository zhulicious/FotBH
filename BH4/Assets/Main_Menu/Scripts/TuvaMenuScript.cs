using UnityEngine;
using System.Collections;

/*
*       This script will only be usedd for Tuva in the MAin Menu.
*
*/

public class TuvaMenuScript : MonoBehaviour {

    Transform tuva;
    float movingSpeed;
    Vector3 tuvaStartPosition;

    public Vector3[] positions;
    public int positionsIndexer;
    bool movingCharacter = false;

    TuvaButtonScript tbs;

    void Start ()
    {
        tuva = GameObject.Find("Tuva").transform;
        tuvaStartPosition = tuva.transform.position;
        tbs = GetComponent<TuvaButtonScript>();
        movingSpeed = 1.35f;
        StartCoroutine("TuvaMovingCoroutine");
    }

    void Update ()
    {
        if (movingCharacter)
        {
            tuva.position = Vector3.MoveTowards(tuva.position, positions[positionsIndexer], movingSpeed * Time.deltaTime);
        }
    }

    IEnumerator TuvaMovingCoroutine ()
    {
        yield return new WaitForSeconds(2.0f);
        movingCharacter = true;
        tbs.DisplayKeyButtons(positionsIndexer);
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        movingCharacter = false;
        positionsIndexer++;
        yield return new WaitForSeconds(2.0f);
        movingCharacter = true;
        tbs.DisplayKeyButtons(positionsIndexer);
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        movingCharacter = false;
        positionsIndexer++;
        yield return new WaitForSeconds(2.0f);
        movingCharacter = true;
       /* tbs.DisplayKeyButtons(positionsIndexer);*/ Debug.Log("Activate E-button");
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        movingCharacter = false;
        yield return new WaitUntil(() => tuva.position == positions[positionsIndexer]);
        yield break;

    }

    public void StopWalkingTuva()
    {
        StopCoroutine("TuvaMovingCoroutine");
        movingCharacter = false;
        tuva.transform.position = tuvaStartPosition;
    }
}

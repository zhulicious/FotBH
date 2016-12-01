using UnityEngine;
using System.Collections;

public class Guldlock : AI {

    bool fetching;
    public GameObject item;
    public Transform keyTarget;

    //Guldlock hämtar ett föremål.
    public void FetchItem()
    {
        setDestination(item.transform.position.x);
        fetching = true;
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - destination.x) <= threshold)
        {
            if (fetching)
            {
                Debug.Log("Got The Item!");
                item.transform.SetParent(transform);
                item.transform.localPosition = Vector3.up * (transform.localScale.y);
                fetching = false;
                UseItem(item);
            }
        }
    }

    void UseItem(GameObject currentItem)
    {
        switch (currentItem.tag)
        {
            case "Key":
                setDestination(keyTarget.position.x);
                break;
            case "Death":
                //Starta scenen
                break;
            default:
                Debug.Log("Error UseItem" + gameObject);
                break;
        }
    }
}

using UnityEngine;
using System.Collections;

public class SpawnSwitch : MonoBehaviour {

    public bool respawn;
    public Transform[] spawn;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            respawn = true;
        }
    }

}

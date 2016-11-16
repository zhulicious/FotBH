using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

	private Script_Mama_ForestCreature mamaRef;


	void Start () {
		mamaRef = GetComponentInParent<Script_Mama_ForestCreature> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Player")
		{
			mamaRef.PlayerStatus(true);
		}
		Debug.Log ("Safe");
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.name == "Player") 
		{
			mamaRef.PlayerStatus(false);
		}
		Debug.Log ("No Safe");

			
	}
}

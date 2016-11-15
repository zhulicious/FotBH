using UnityEngine;
using System.Collections;

public class ActivateMonster : MonoBehaviour {

	private Script_Mama_ForestCreature mama;

	void Start()
	{
		mama = GetComponentInParent<Script_Mama_ForestCreature> ();
	}


	void OnTriggerExit2D(Collider2D col)
	{
		if (col.name == "Player") {
			mama.GoMonster ();
			Debug.Log ("Activate Monster");
			//Destroy (col.gameObject);
		}
	}

}

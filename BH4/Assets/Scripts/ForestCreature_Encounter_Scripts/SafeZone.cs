using UnityEngine;

public class SafeZone : MonoBehaviour {

	private Script_Mama_ForestCreature mamaRef;
    public bool debugLog;


	void Start () {
		mamaRef = GetComponentInParent<Script_Mama_ForestCreature> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Tuva")
		{
			mamaRef.PlayerStatus(true);
            mamaRef._AudioManager.TuvaSafe();
            
		}
		if(debugLog)Debug.Log ("Safe");
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.name == "Tuva") 
		{
			mamaRef.PlayerStatus(false);
            mamaRef.EnemyBehaviourRef.Action();
		}
		if(debugLog)Debug.Log ("No Safe");

			
	}
}

using UnityEngine;

public class ActivateMonster : MonoBehaviour {

	private Script_Mama_ForestCreature mama;
    private AudioManager audioManager;

	void Start()
	{
		mama = GetComponentInParent<Script_Mama_ForestCreature> ();
        audioManager = mama._AudioManager;
	}


	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "Tuva") {
			mama.GoMonster ();
            audioManager.ActivateAllMusicTracks(true);
			Debug.Log ("Activate Montster");
			Destroy (gameObject);
		}
	}

}

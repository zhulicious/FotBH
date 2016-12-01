using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public Vector3 tuvaPosition;
	public Vector3 guldlockPosition;
	public Vector3 lanternPosition;

	GameObject tuva;
	GameObject guldlock;
	GameObject lantern;
	GameObject trigger;

	bool triggerUsed;
	bool fromSlice;


	void Awake(){



		if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1){
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(transform.gameObject);
			FindGameObjects();
			tuvaPosition = tuva.transform.position;
			guldlockPosition = guldlock.transform.position;
			lanternPosition = lantern.transform.position;
		}
	}
	void Start () {

	}
	void FindGameObjects(){
		tuva = GameObject.FindGameObjectWithTag("Tuva");
		guldlock = GameObject.FindGameObjectWithTag("Guldlock");
		lantern = GameObject.FindGameObjectWithTag("Lantern");
		trigger = GameObject.FindGameObjectWithTag("CutScene");
	}
	public void SetPositions(){
		FindGameObjects();
		if(triggerUsed){
			DestroyTrigger();
		}
		tuva.transform.position = tuvaPosition;
		guldlock.transform.position = guldlockPosition;
		lantern.transform.position = lanternPosition;
	}
	public void SavePositions(){
		tuvaPosition = tuva.transform.position;
		guldlockPosition = guldlock.transform.position;
		lanternPosition = lantern.transform.position;

		triggerUsed = true;
	}
	void DestroyTrigger(){
		Destroy(trigger.gameObject);
	}
	public bool ReturnFromSliceOrNot(){
		return fromSlice;
	}
	public void SetFromSlice(){
		fromSlice = true;
	}
	public void SetFromMenu(){
		fromSlice = false;
	}
}

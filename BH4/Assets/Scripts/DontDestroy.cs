using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public Vector3 tuvaPosition;

	GameObject tuva;
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
		}
	}
	void Start () {

	}
	void FindGameObjects(){
		tuva = GameObject.FindGameObjectWithTag("Tuva");
		trigger = GameObject.FindGameObjectWithTag("CutScene");
	}
	public void SetPositions(){
		FindGameObjects();
		if(triggerUsed){
			DestroyTrigger();
		}
		tuva.transform.position = tuvaPosition;
	}
	public void SavePositions(){
		tuvaPosition = tuva.transform.position;

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

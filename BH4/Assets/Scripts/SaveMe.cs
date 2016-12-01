using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour {

	public string _event;

	void Awake(){
		if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1){
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(transform.gameObject);
			SetOutSideSliceScene("TheNeck");
		}
	}
	public void SetOutSideSliceScene(string _s){
		_event = _s;
	}
	public string ReturnEnterScene(){
		return _event;
	}
}

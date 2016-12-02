using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateEvent : MonoBehaviour {


	public GameObject activateTrollTrigger;


	void Start () {
		GetComponent<Dialogs>().EventDialog(activateTrollTrigger);
	}

}

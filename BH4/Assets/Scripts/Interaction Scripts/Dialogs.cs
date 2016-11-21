using UnityEngine;
using System.Collections.Generic;

public class Dialogs : MonoBehaviour {

	Dictionary<int, string> dialogs = new Dictionary<int, string>();
	

	void Start () {
		dialogs.Add(1, "Stop");
		dialogs.Add(2, "Hello\n There");
		dialogs.Add(3, "No! \n Wait!");
		dialogs.Add(4, "Please");
		
	}
	public string returnDialog (int _key){
		return dialogs[_key];
	}
	

	void Update () {
	
	}
}

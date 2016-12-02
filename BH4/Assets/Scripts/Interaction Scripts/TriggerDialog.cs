using UnityEngine;
using System.Collections;

public class TriggerDialog : MonoBehaviour {
	public int[] chat_array;
	public GameObject myHostsBubble;
	public bool playSelf;
	public float playAfter;

	public int[] ReturnChatArray(){
		return chat_array;
	}
	public GameObject ReturnHostBubble(){
		return myHostsBubble;
	}
	void Start(){
		if(playSelf){
			StartCoroutine(playMe());
		}
	}
	IEnumerator playMe(){
		yield return new WaitForSeconds(playAfter);
		GameObject.FindGameObjectWithTag("Dialogs").GetComponent<Dialogs>().EventDialog(gameObject);
	}
}

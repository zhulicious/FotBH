using UnityEngine;
using System.Collections;

public class Talk : MonoBehaviour {

	public GameObject myChat;
	public GameObject dialogs;
	public GameObject chatSystem;

	public int chat_1;
	public int chat_2;
	public int chat_3;

	public GameObject ReturnMYChat(){
		return myChat;
	}
	public void Conversation(){
		if(chat_1 != 0 && chat_2 != 0 && chat_3 != 0){
			Debug.Log("sent 3 message");
			string first = dialogs.GetComponent<Dialogs>().returnDialog(chat_1);
			string second = dialogs.GetComponent<Dialogs>().returnDialog(chat_2);
			string Third = dialogs.GetComponent<Dialogs>().returnDialog(chat_3);

			chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, first, second, Third);
		}else if(chat_1 != 0 && chat_2 != 0){
			string first = dialogs.GetComponent<Dialogs>().returnDialog(chat_1);
			string second = dialogs.GetComponent<Dialogs>().returnDialog(chat_2);
			Debug.Log("sent 2 message");
			chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, first, second, null);
		}else if(chat_1 != 0){
			string first = dialogs.GetComponent<Dialogs>().returnDialog(chat_1);

			chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, first, null, null);
		}
	}
}

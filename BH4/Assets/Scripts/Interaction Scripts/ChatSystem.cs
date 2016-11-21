using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatSystem : MonoBehaviour {

	public GameObject target_1;
	public GameObject target_2;
	public GameObject target_3;
	public GameObject tuva;



	void Start () {
	
	}
	public void CharacterTalk(GameObject _target, string _message_1, string _message_2, string _message_3){

		GameObject chat = _target.GetComponent<Talk>().ReturnMYChat();
		//string text = chat.GetComponentInChildren<TextMesh>().text;
		StartCoroutine(ActivateBubble(chat, _message_1, _message_2, _message_3));

	}
	IEnumerator ActivateBubble(GameObject _chat, string _message_1, string _message_2, string _message_3){
		float waitTime = 4.0f, downTime = 0.2f;
		_chat.SetActive(true);
		_chat.GetComponentInChildren<TextMesh>().text = _message_1;
		yield return new WaitForSeconds(waitTime);
		if(_message_2 != null){
			CloseChat(_chat);
			yield return new WaitForSeconds(downTime);
			_chat.SetActive(true);
			_chat.GetComponentInChildren<TextMesh>().text = _message_2;
			yield return new WaitForSeconds(waitTime);
			CloseChat(_chat);
			if(_message_3 != null){
				yield return new WaitForSeconds(downTime);
				_chat.SetActive(true);
				_chat.GetComponentInChildren<TextMesh>().text = _message_3;
				yield return new WaitForSeconds(waitTime);
				CloseChat(_chat);
			}else{
				CloseChat(_chat);
				if(_chat.gameObject.tag == "Tuva_Chat"){
					tuva.GetComponent<TuvaInterations>().CanInteractAgain();
				}
			}
		}else{
			CloseChat(_chat);
			if(_chat.gameObject.tag == "Tuva_Chat"){
				tuva.GetComponent<TuvaInterations>().CanInteractAgain();
			}
		}
	}
	public void CloseChat(GameObject _chat){
		_chat.SetActive(false);

	}




	void Update () {
		if(Input.GetKeyDown(KeyCode.L)){
			CharacterTalk(target_1, "Hello!?", null, null);
		}else if(Input.GetKeyDown(KeyCode.K)){
			CharacterTalk(target_2, "I'll fight\n you!", "don't Worry", null);

		}else if(Input.GetKeyDown(KeyCode.J)){
			CharacterTalk(target_3, "Common!", "Come find me", "don't go");

		}
	}
}

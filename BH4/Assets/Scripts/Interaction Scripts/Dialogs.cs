using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour {

	Dictionary<int, string> dialogs = new Dictionary<int, string>();
	public GameObject dialogPanel;
	public Text dialogText;
	public GameObject tuva;

	void Start () {
		dialogs.Add(1, "Hello Child");
		dialogs.Add(2, "I can\nprotect you");
		dialogs.Add(3, "Who are\n you?");

		//Trolls i Cave Dialogs
		dialogs.Add(4, "<i>Troll 1: I’d say we cut of her head, then give the hair to the children to play with.</i>");
		dialogs.Add(5, "<i>Troll 2: No, you dumbtroll! That way she dies. She’d smell.</i>");
		dialogs.Add(6, "<i>Troll 1: Yuck, smelly human...</i>");
		dialogs.Add(7, "<i>Troll 2: We just cut the hair, then let more grow, then cut it again.</i>");
		dialogs.Add(8, "<i>Troll 1: We can make nice bracelets out of it.</i>");
		dialogs.Add(9, "<i>Troll 2: You and your bracelets… Hey, human, we’ll be back later. Don’t try anything.</i>");

		//Tuva Talks
		dialogs.Add(10, "All clear");
		dialogs.Add(11, "Quiet\nnow");
		dialogs.Add(12, "He is close");


	}
	public string returnDialog (int _key){
		return dialogs[_key];
	}

	public void EventDialog(GameObject _trigger){
		int[] _array = _trigger.GetComponent<TriggerDialog>().ReturnChatArray().Clone() as int[];
		StartCoroutine(DisplayDialog(_array));
	}
	IEnumerator DisplayDialog(int[] _array){
		for (int i = 0; i < _array.Length; i++) {
			if( _array[i] != 0){
				dialogPanel.SetActive(true);
				dialogText.GetComponent<Text>().text =  returnDialog(_array[i]);
				yield return new WaitForSeconds(5.0f);
				dialogPanel.SetActive(false);
				yield return new WaitForSeconds(0.2f);
			}
		}
	}
	public void ChatDialog(GameObject _trigger, GameObject _bubble){
		int[] _array = _trigger.GetComponent<TriggerDialog>().ReturnChatArray().Clone() as int[];
		StartCoroutine(DisplayChat(_array, _bubble));
	}
	IEnumerator DisplayChat(int[] _array, GameObject _bubble){
		for (int i = 0; i < _array.Length; i++) {
			if(_array[i] != 0){
				_bubble.SetActive(true);
				_bubble.GetComponentInChildren<TextMesh>().text = returnDialog(_array[i]);
				yield return new WaitForSeconds(3.0f);
				_bubble.SetActive(false);
				yield return new WaitForSeconds(0.2f);
				if(i == _array.Length -1){
					tuva.GetComponent<TuvaInterations>().CanInteractAgain();

				}
			}
		}
	}



}

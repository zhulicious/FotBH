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
		dialogs.Add(1, "Stop");
		dialogs.Add(2, "Hello\n There");
		dialogs.Add(3, "No! \n Wait!");

		//Trolls i Cave Dialogs
		dialogs.Add(4, "Troll 1: I’d say we cut of her head, then give the hair to the children to play with.");
		dialogs.Add(5, "Troll 2: No, you dumbtroll! That way she dies. She’d smell.");
		dialogs.Add(6, "Troll 1: Yuck, smelly human...");
		dialogs.Add(7, "Troll 2: We just cut the hair, then let more grow, then cut it again.");
		dialogs.Add(8, "Troll 1: We can make nice bracelets out of it.");
		dialogs.Add(9, "Troll 2: You and your bracelets… Hey, human, we’ll be back later. Don’t try anything.");

		//Tuva Talks
		dialogs.Add(10, "Hello!");
		dialogs.Add(11, "Im Tuva");
		dialogs.Add(12, "Fuck You");


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

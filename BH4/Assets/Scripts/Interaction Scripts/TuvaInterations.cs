using UnityEngine;
using System.Collections;

public class TuvaInterations : MonoBehaviour {

	public GameObject eButton;
	public GameObject chatSystem;
	public GameObject dialog;
	public enum doing{noInteraction, canInteract, alreadyInteracting};
	public doing tuvaDoing = doing.noInteraction;
	GameObject currentInteractionObject;
	string currentTag;



	void Start () {

	}
	void OnTriggerEnter2D(Collider2D col){
		currentTag = col.gameObject.tag;
		if(currentTag == "NPC_Talk"){
			col.gameObject.GetComponent<Talk>().Conversation();
			//chatSystem.GetComponent<ChatSystem>().CharacterTalk(col.gameObject, chat, null, null);
			col.gameObject.SetActive(false);
		}else if(currentTag == "Event"){
			//event happen ( cut scene)
		}else if (currentTag == "Dialog"){
			dialog.GetComponent<Dialogs>().EventDialog(col.gameObject);
			col.gameObject.SetActive(false);
		}
		currentInteractionObject = col.gameObject;
		if(tuvaDoing == doing.noInteraction || tuvaDoing != doing.alreadyInteracting){
			if(currentTag == "Tuva_Talk"){
				tuvaDoing = doing.canInteract;
			}else if(currentTag == "JumpSpot"){
				tuvaDoing = doing.canInteract;

				//CanInteractAgain();
			}else if(currentTag == "Pick_Up"){
				tuvaDoing = doing.canInteract;
			}else if(currentTag == "Use_Item"){
				tuvaDoing = doing.canInteract;
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(tuvaDoing != doing.alreadyInteracting){
			tuvaDoing = doing.noInteraction;
		}
		currentInteractionObject = null;

	}
	void ActivateInteractionButton(){
		eButton.SetActive(true);
	}
	void DeactivateInteractionButton(){
		eButton.SetActive(false);
	}
	public void CanInteractAgain(){
		if(currentInteractionObject != null){
			Debug.Log("can interact");
			tuvaDoing = doing.canInteract;
		}else{
			tuvaDoing = doing.noInteraction;
		}

	}
	IEnumerator WaitTime(float _time){
		yield return new WaitForSeconds(_time);
		CanInteractAgain();
	}
	void InteractWithObject(){
		tuvaDoing = doing.alreadyInteracting;
		DeactivateInteractionButton();
		if(currentTag == "Tuva_Talk"){
			//Should return Strings to say
			chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, "Who are\n you?", "Im Tuva", null);
		}else if(currentTag == "JumpSpot"){
			Debug.Log("jumpspot");
			StartCoroutine(WaitTime(2.0f));
		}else if(currentTag == "Pick_Up"){

		}else if(currentTag == "Use_Item"){

		}

	}
	void Update () {
		if(tuvaDoing == doing.canInteract){
			ActivateInteractionButton();
			if(Input.GetKeyDown(KeyCode.E)){
				InteractWithObject();
			}

		}else{
			DeactivateInteractionButton();
		}
	}

}

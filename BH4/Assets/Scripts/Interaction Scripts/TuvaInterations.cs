using UnityEngine;
using System.Collections;

public class TuvaInterations : MonoBehaviour {

	public GameObject eButton;
	public GameObject chatSystem;
	public enum doing{noInteraction, canInteract, alreadyInteracting};
	doing tuvaDoing = doing.noInteraction;
	GameObject currentInteractionObject;
	string currentTag;



	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D col){
		currentTag = col.gameObject.tag;
		if(currentTag == "Object_Talk"){
			col.gameObject.GetComponent<Talk>().Conversation();
			//chatSystem.GetComponent<ChatSystem>().CharacterTalk(col.gameObject, chat, null, null);
			col.gameObject.SetActive(false);
		}else if(currentTag == "Event"){
			//event happen
		}
		currentInteractionObject = col.gameObject;
		if(tuvaDoing == doing.noInteraction || tuvaDoing != doing.alreadyInteracting){
			if(currentTag == "Tuva_Talk"){
				tuvaDoing = doing.canInteract;
			}else if(currentTag == "Tuva_Jump"){
				tuvaDoing = doing.canInteract;
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
	void InteractWithObject(){
		tuvaDoing = doing.alreadyInteracting;
		DeactivateInteractionButton();
		if(currentTag == "Tuva_Talk"){
			//Should return Strings to say
			chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, "Who are\n you?", "Im Tuva", null);
		}else if(currentTag == "Tuva_Jump"){

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

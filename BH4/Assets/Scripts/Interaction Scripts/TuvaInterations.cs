using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TuvaInterations : MonoBehaviour {
	
	public GameObject dontDestroy;
	public GameObject eButton;
	public GameObject dialog;
	public enum doing{noInteraction, canInteract, alreadyInteracting};
	public doing tuvaDoing = doing.noInteraction;
	public GameObject currentInteractionObject;
	string currentTag;
	bool hasItem;



	void Start () {
		dontDestroy = GameObject.FindGameObjectWithTag("DontDestroy");
		dontDestroy.GetComponent<DontDestroy>().SetPositions();
	}
	void OnTriggerEnter2D(Collider2D col){
		currentTag = col.gameObject.tag;
		if(currentTag == "NPC_Talk"){
			//col.gameObject.GetComponent<Talk>().Conversation();
			dialog.GetComponent<Dialogs>().ChatDialog(col.transform.gameObject, col.transform.gameObject.GetComponent<TriggerDialog>().ReturnHostBubble());
			//chatSystem.GetComponent<ChatSystem>().CharacterTalk(col.gameObject, chat, null, null);
			col.gameObject.SetActive(false);
		}else if(currentTag == "CutScene"){
			col.gameObject.SetActive(false);
			dontDestroy.GetComponent<DontDestroy>().SavePositions();
			SceneManager.LoadScene("CS_Guldlock");

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
				//Debug.Log("found use");
				tuvaDoing = doing.canInteract;
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(tuvaDoing != doing.alreadyInteracting){
			tuvaDoing = doing.noInteraction;
		}
		if(col.transform.gameObject.tag == "Obstacle"){
			Debug.Log("exit objasctle");
			col.transform.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
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
			//Debug.Log("can interact");
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
			dialog.GetComponent<Dialogs>().ChatDialog(currentInteractionObject, currentInteractionObject.GetComponent<TriggerDialog>().ReturnHostBubble());
			//Should return Strings to say
			//chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, "Who are\n you?", "Im Tuva", null);
		}else if(currentTag == "JumpSpot"){
			GetComponent<Movement_player>().EButtonPressedForJump();
			currentInteractionObject.GetComponent<JumpSpot>().ReturnObstacle().GetComponent<BoxCollider2D>().isTrigger = true;
			StartCoroutine(WaitTime(2.0f));
		}else if(currentTag == "Pick_Up"){
			hasItem = true;
			currentInteractionObject.SetActive(false);
			currentInteractionObject = null;
			CanInteractAgain();
		}else if(currentTag == "Use_Item"){
			if(hasItem){
				//remove Object / add object
				dialog.GetComponent<Dialogs>().ChatDialog(currentInteractionObject, currentInteractionObject.GetComponent<TriggerDialog>().ReturnHostBubble());
				//chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, "Lets start\ndigging", null, null);
				currentInteractionObject.SetActive(false);
				currentInteractionObject = null;

			}else{
				//chatSystem.GetComponent<ChatSystem>().CharacterTalk(gameObject, "Need something\nto dig", null, null);
			}
			CanInteractAgain();
		}

	}
	public void TuvaDiedByTree(){
		GameObject.FindGameObjectWithTag("SaveMe").GetComponent<SaveMe>().SetOutSideSliceScene("DeathTree");
		SceneManager.LoadScene("OutsideSlice");
	}
	public void TuvaDiedByLantern(){
		GameObject.FindGameObjectWithTag("SaveMe").GetComponent<SaveMe>().SetOutSideSliceScene("DeathLantern");
		SceneManager.LoadScene("OutsideSlice");
	}
	public void TuvaContinueToSkogsra(){
		GameObject.FindGameObjectWithTag("SaveMe").GetComponent<SaveMe>().SetOutSideSliceScene("Skogsra");
		SceneManager.LoadScene("OutsideSlice");
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
		if(Input.GetKeyDown(KeyCode.Y)){
			TuvaDiedByTree();
		}else if(Input.GetKeyDown(KeyCode.U)){
			TuvaDiedByLantern();
		}else if(Input.GetKeyDown(KeyCode.I)){
			TuvaContinueToSkogsra();
		}
	}

}

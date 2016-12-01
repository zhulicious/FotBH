using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChoiceTree : MonoBehaviour {
	/*
	theNeck(3)-Kallra -ForestProtector -Guldlock
	Kallra_stage1(2) -Kallra_stage2 -Ghost
	Kallra_stage2(3) -DeathKallra# -Boy1 -Boy2
	ForestProtector(1) -Boy1
	Guldlock(2) -Boy1 -(Slice)
	Boy1(3) -Boy2 -Ghost -(Slice)
	Boy2(2) -Boy3 -Skogsra
	Ghost(2) -Skogsra -DeathGhost#
	(Slice) -Skogsra -DeathTree -DeathLantern -Skogsra
	Boy3(2) -Boy4_NoCompass_WithBoy -Skogsra
	Skogsra(3) if(boy_Points >= 2){-Boy4_Compass_WithBoy}else{-Boy4_Compass_NoBoy}  -Sjora -DeathSkogsRa#
	Boy4_NoCompass_WithBoy(2) -TuvaFairy# -Sjora
	Boy4_Compass_WithBoy(2) -TuvaFairy# -Sjora
	Boy4_Compass_NoBoy(1) -Sjora
	TrickTheNeck(2) -TuvaFail#, - TuvaWin#

	Sjora(3) -FoundTheNeck -TrickTheNeck - DeathSjora#

	----END SCENES----
	TuvaFairy
	FoundTheNeck
	TuvaFail
	TuvaWin
	
	DeathKallra
	DeathGhost
	DeathTree
	DeathLantern
	DeathSjora
	DeathSkogsra

	 */

	public enum scene{TheNeck, Kallra_Stage1, Kallra_Stage2, ForestProtector, Guldlock, Boy1, Boy2_WithBoy, Boy2_NoBoy, Boy3, Ghost, Slice, Skogsra, Sjora,
	TuvaFairy, FoundTheNeck, TrickTheNeck, DeathKallra, DeathGhost, DeathTree, DeathLantern, DeathSjora, DeathSkogsra, Boy4_NoCompass_WithBoy,
	Boy4_Compass_WithBoy, Boy4_Compass_NoBoy, TuvaFail, TuvaWin}

	public GameObject allButImage;
	public scene currentScene;
	public GameObject sceneImage;
	public GameObject option_1;
	public GameObject option_2;
	public GameObject option_3;
	public Text header;
	public Text mainText;
	public Text choice_1;
	public Text choice_2;
	public Text choice_3;
	bool endSceneActive;

	int cA;
	int boyPoints;


	void Start () {
		//GetDOntDestobject
		currentScene = scene.TheNeck;
		cA = 3;
		ChangeVisualForScene();

	}
	public void ChangeScene(int choice){
		switch(currentScene){
		case scene.TheNeck:
			if(choice == 1){currentScene = scene.Kallra_Stage1; cA = 2;}
			else if(choice == 2){currentScene = scene.ForestProtector; cA = 1;}
			else if(choice == 3){currentScene = scene.Guldlock; cA = 2;}
			break;

		case scene.Kallra_Stage1:
			if(choice == 1){currentScene = scene.Kallra_Stage2; cA = 3;}
			else if(choice == 2){currentScene = scene.Ghost; cA = 2;}
			break;

		case scene.Kallra_Stage2:
			if(choice == 1){currentScene = scene.DeathKallra; cA = 0; EnterEndScene();}
			else if(choice == 2){currentScene = scene.Boy1; cA = 3; boyPoints++;}
			else if(choice == 3){currentScene = scene.Boy2_NoBoy; cA = 2; boyPoints++;}
			break;

		case scene.ForestProtector:
			currentScene = scene.Boy1; cA = 1; boyPoints++;
			break;

		case scene.Guldlock:
			if(choice == 1){currentScene = scene.Boy1; cA = 3; boyPoints++;}
			else if(choice == 2){StartCoroutine(LoadVertical(0.0f));}
			break;

		case scene.Boy1:
			if(choice == 1){currentScene = scene.Boy2_WithBoy; cA = 2; boyPoints++; }
			else if(choice == 2){currentScene = scene.Ghost; cA = 2;}
			else if(choice == 3){StartCoroutine(LoadVertical(0.0f));}
			break;

		case scene.Boy2_WithBoy:
			if(choice == 1){currentScene = scene.Boy3; cA = 2;}
			else if(choice == 2){currentScene = scene.Skogsra; cA = 3;}
			break;
		case scene.Boy2_NoBoy:
			if(choice == 1){currentScene = scene.Boy3; cA = 2;}
			else if(choice == 2){currentScene = scene.Skogsra; cA = 3;}
			break;

		case scene.Boy3:
			if(choice == 1){currentScene = scene.Boy4_Compass_WithBoy; cA = 2;}
			else if(choice == 2){currentScene = scene.Skogsra; cA = 3;}
			break;

		case scene.Ghost:
			if(choice == 1){currentScene = scene.Skogsra; cA = 3;}
			else if(choice == 2){currentScene = scene.DeathGhost; cA = 0; EnterEndScene();}
			break;

		case scene.Skogsra:
			if(choice == 1){
				if(boyPoints >= 2){
					currentScene = scene.Boy4_Compass_WithBoy;
					cA = 2;
				}else{
					currentScene = scene.Boy4_Compass_NoBoy;
					cA = 1;
				}
			}
			else if(choice == 2){currentScene = scene.Sjora; cA = 3;}
			else if(choice == 3){currentScene = scene.DeathSkogsra; cA = 0;EnterEndScene();}
			break;

		case scene.Sjora:
			if(choice == 1){currentScene = scene.FoundTheNeck; cA = 0;EnterEndScene();}
			else if(choice == 2){currentScene = scene.TrickTheNeck; cA = 2;}
			else if(choice == 3){currentScene = scene.DeathSjora; cA = 0;EnterEndScene();}
			break;

		case scene.TuvaFairy:
			break;

		case scene.FoundTheNeck:

			break;

		case scene.TrickTheNeck:
			if(choice == 1){currentScene = scene.TuvaWin; cA = 0;EnterEndScene();}
			else if(choice == 2){currentScene = scene.TuvaFail; cA = 0;EnterEndScene();}
			break;

		case scene.DeathKallra:

			break;

		case scene.DeathGhost:

			break;

		case scene.DeathTree:

			break;

		case scene.DeathLantern:

			break;

		case scene.DeathSjora:

			break;

		case scene.DeathSkogsra:

			break;

		case scene.Boy4_NoCompass_WithBoy:
			if(choice == 1){currentScene = scene.TuvaFairy; cA = 0;EnterEndScene();}
			else if(choice == 2){currentScene = scene.Sjora; cA = 3;}
			break;

		case scene.Boy4_Compass_WithBoy:
			if(choice == 1){currentScene = scene.TuvaFairy; cA = 0;EnterEndScene();}
			else if(choice == 2){currentScene = scene.Sjora; cA = 3;}
			break;

		case scene.Boy4_Compass_NoBoy:
			currentScene = scene.Sjora; cA = 3;
			break;

		case scene.TuvaFail:

			break;
		case scene.TuvaWin:

			break;
		}

		ChangeVisualForScene();
	}

	public void ChangeVisualForScene(){
		//Set scene image
		Sprite loadedImage = Resources.Load<Sprite>("Image/image_" + currentScene.ToString());
		sceneImage.GetComponent<Image>().sprite = loadedImage;

		//Set Header?!?!?
		if(!endSceneActive){
			TextAsset loadedHeaderText = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_header");
			header.text = loadedHeaderText.text;

			//Set Main Text
			TextAsset loadedMainText = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_main");
			mainText.text = loadedMainText.text;
		}


		//Set option Amount
		if(cA == 1){
			option_1.SetActive(true); option_2.SetActive(false); option_3.SetActive(false);
			TextAsset laoadedChoice1Text = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_choice_1");
			choice_1.text = laoadedChoice1Text.text;
		}
		else if(cA == 2){
			option_1.SetActive(true); option_2.SetActive(true); option_3.SetActive(false);
			TextAsset laoadedChoice1Text = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_choice_1");
			TextAsset laoadedChoice2Text = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_choice_2");
			choice_1.text = laoadedChoice1Text.text;
			choice_2.text = laoadedChoice2Text.text;
		}
		else if(cA == 3){
			option_1.SetActive(true); option_2.SetActive(true); option_3.SetActive(true);
			TextAsset laoadedChoice1Text = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_choice_1");
			TextAsset laoadedChoice2Text = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_choice_2");
			TextAsset laoadedChoice3Text = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_choice_3");
			choice_1.text = laoadedChoice1Text.text;
			choice_2.text = laoadedChoice2Text.text;
			choice_3.text = laoadedChoice3Text.text;
		}
		else if(cA == 0){
			option_1.SetActive(false); option_2.SetActive(false); option_3.SetActive(false);
		}
	}
	IEnumerator LoadMainMenu(float _time){
		yield return new WaitForSeconds(_time);
		SceneManager.LoadScene("MainMenu");
	}
	IEnumerator LoadVertical(float _time){
		yield return new WaitForSeconds(_time);
		SceneManager.LoadScene("Skogen_version_one");
	}
	void EnterEndScene(){
		endSceneActive = true;
		allButImage.SetActive(false);
		StartCoroutine(LoadMainMenu(10.0f));
	}
	public void SetSceneAfterSlice(){
		currentScene = scene.Skogsra;
		cA = 3;
		ChangeVisualForScene();
	}
	public void KilledByLantern(){
		EnterEndScene();
		currentScene = scene.DeathLantern;
		cA = 0;
		ChangeVisualForScene();
	}
	public void KilledByTree(){
		EnterEndScene();
		currentScene = scene.DeathTree;
		cA = 0;
		ChangeVisualForScene();
	}

}

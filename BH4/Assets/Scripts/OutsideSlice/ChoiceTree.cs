using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

	Sjora(3) -FoundTheNeck -TrickTheNeck - DeathSjora#

	----END SCENES----
	TuvaFairy
	FoundTheNeck
	TrickTheNeck
	
	DeathKallra
	DeathGhost
	DeathTree
	DeathLantern
	DeathSjora
	DeathSkogsra

	 */

	public enum scene{TheNeck, Kallra_Stage1, Kallra_Stage2, ForestProtector, Guldlock, Boy1, Boy2, Boy3, Ghost, Slice, Skogsra, Sjora,
	TuvaFairy, FoundTheNeck, TrickTheNeck, DeathKallra, DeathGhost, DeathTree, DeathLantern, DeathSjora, DeathSkogsra, Boy4_NoCompass_WithBoy,
	Boy4_Compass_WithBoy, Boy4_Compass_NoBoy}

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

	int cA;
	int boyPoints;


	void Start () {
		currentScene = scene.TheNeck;
		cA = 3;
		ChangeVisualForScene();

	}
	public void ChangeScene(int choice){//Clicked button returns Int 1,2,3 //NO Slice
		switch(currentScene){
		case scene.TheNeck://you are at neck and press choice
			if(choice == 1){currentScene = scene.Kallra_Stage1; cA = 2;}
			else if(choice == 2){currentScene = scene.ForestProtector; cA = 1;}
			else if(choice == 3){currentScene = scene.Guldlock; cA = 2;}
			break;

		case scene.Kallra_Stage1:
			if(choice == 1){currentScene = scene.Kallra_Stage2; cA = 3;}
			else if(choice == 2){currentScene = scene.Ghost; cA = 2;}
			break;

		case scene.Kallra_Stage2:
			if(choice == 1){currentScene = scene.DeathKallra; cA = 0;}
			else if(choice == 2){currentScene = scene.Boy1; cA = 3;}//boy point
			else if(choice == 3){currentScene = scene.Boy2; cA = 2;}//boy point
			break;

		case scene.ForestProtector:
			currentScene = scene.Boy1; cA = 3;//boy point
			break;

		case scene.Guldlock:
			if(choice == 1){currentScene = scene.Boy1; cA = 3;}//boypoint
			else if(choice == 2){}//VErticalSLice LOadScene
			break;

		case scene.Boy1:
			if(choice == 1){currentScene = scene.Boy2; cA = 2;}//boypoint
			else if(choice == 2){currentScene = scene.Ghost; cA = 2;}
			else if(choice == 3){}//VErticalSLice LOadScene
			break;

		case scene.Boy2:
			if(choice == 1){currentScene = scene.Boy3; cA = 2;}
			else if(choice == 2){currentScene = scene.Skogsra; cA = 3;}//check boypoints
			break;

		case scene.Boy3:
			if(choice == 1){currentScene = scene.Boy4_Compass_WithBoy; cA = 2;}
			else if(choice == 2){currentScene = scene.Skogsra; cA = 3;}//checkBoyoints
			break;

		case scene.Ghost:
			if(choice == 1){currentScene = scene.Skogsra; cA = 3;}//checkBoyoints
			else if(choice == 2){currentScene = scene.DeathGhost; cA = 0;}
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
			else if(choice == 3){currentScene = scene.DeathSkogsra; cA = 0;}
			break;

		case scene.Sjora:
			if(choice == 1){currentScene = scene.FoundTheNeck; cA = 0;}
			else if(choice == 2){currentScene = scene.TrickTheNeck; cA = 0;}
			else if(choice == 3){currentScene = scene.DeathSjora; cA = 0;}
			break;

		case scene.TuvaFairy:
			//LoadMainMenu 15s
			break;

		case scene.FoundTheNeck:

			break;

		case scene.TrickTheNeck:

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
			if(choice == 1){currentScene = scene.TuvaFairy; cA = 0;}
			else if(choice == 2){currentScene = scene.Sjora; cA = 3;}
			break;

		case scene.Boy4_Compass_WithBoy:
			if(choice == 1){currentScene = scene.TuvaFairy; cA = 0;}
			else if(choice == 2){currentScene = scene.Sjora; cA = 3;}
			break;

		case scene.Boy4_Compass_NoBoy:
			currentScene = scene.Sjora; cA = 3;
			break;

		}
		ChangeVisualForScene();
	}

	public void ChangeVisualForScene(){
		//Set scene image
		Sprite loadedImage = Resources.Load<Sprite>("Image/image_" + currentScene.ToString());
		sceneImage.GetComponent<Image>().sprite = loadedImage;

		//Set Header?!?!?
		TextAsset loadedHeaderText = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_header");
		header.text = loadedHeaderText.text;

		//Set Main Text
		TextAsset loadedMainText = (TextAsset)Resources.Load("Text/" + currentScene.ToString() + "_main");
		mainText.text = loadedMainText.text;

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
}

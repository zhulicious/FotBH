using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour {

	Dictionary<int, string> dialogs = new Dictionary<int, string>();
	public GameObject dialogPanel;
	public Text dialogText;
	public GameObject tuva;
	void Awake(){
		dialogs.Add(1, "Hello Child");
		dialogs.Add(2, "I can\nprotect you");
		dialogs.Add(3, "Who are\n you?");

		//Trolls i Cave Dialogs
		dialogs.Add(4, "Troll 1:<i> I’d say we cut of her head, then give the hair to the children to play with.</i>");
		dialogs.Add(5, "Troll 2:<i> No, you dumbtroll! That way she dies. She’d smell.</i>");
		dialogs.Add(6, "Troll 1:<i> Yuck, smelly human...</i>");
		dialogs.Add(7, "Troll 2:<i> We just cut the hair, then let more grow, then cut it again.</i>");
		dialogs.Add(8, "Troll 1:<i> We can make nice bracelets out of it.</i>");
		dialogs.Add(9, "Troll 2:<i> You and your bracelets… Hey, human, we’ll be back later. Don’t try anything.</i>");

		dialogs.Add(10, "All clear");
		dialogs.Add(11, "Quiet\nnow");
		dialogs.Add(12, "He is close");

		dialogs.Add(13, "Please\nhelp me?");
		dialogs.Add(14, "Quiet\nnow");
		dialogs.Add(15, "He is close");

		//Guldlock and Tuva
		dialogs.Add(16, "Guldlock:<i> Sorry for how they've treated you. They can be rellly mean sometimes... Are you hurt?</i>");
		dialogs.Add(17, "Tuva:<i> No, I'm fine</i>");
		dialogs.Add(18, "Guldlock:<i> Good... But you might not stay that way if you stay here.</i>");
		dialogs.Add(19, "Tuva:<i> ...If you are with them, why are you being so nice? And how come you look so different..?</i>");
		dialogs.Add(20, "Guldlock:<i> I try to be part of them, I have my whole life But they always treat me like an outsider,</i>");
		dialogs.Add(21, "Guldlock:<i> Like i actually belonged with the wolves, the bugs, bees, fairies, will o' wisps or...humans..</i>");
		dialogs.Add(22, "Guldlock:<i> ...</i>");
		dialogs.Add(23, "Guldlock:<i> When i see you, you make me... wonder .. You remond me of what i looked like when i was younger. I didn't have a tail then, and my hair..</i>");
		dialogs.Add(24, "Guldlock:<i> ...</i>");
		dialogs.Add(25, "Tuva:<i> ...Maybe.. maybe we can find out</i>");
		dialogs.Add(26, "Guldlock:<i> What do you mean?</i>");
		dialogs.Add(27, "Tuva:<i> We can escape, together. Then you can leave the forest, go to the village where i live. Maybe someone knows who you are.</i>");
		dialogs.Add(28, "Guldlock:<i> Do you really mean that?</i>");
		dialogs.Add(29, "Tuva:<i> Yes!</i>");
		dialogs.Add(30, "Guldlock:<i> I'll go and get the keys!</i>");


		dialogs.Add(31, "Guldlock:<i> I have tried escaping before, but they always catch me! Maybe if we work togther, we can actually get out!</i>");
		dialogs.Add(32, "Guldlock:<i> Common, hurry, before they get back!</i>");

		dialogs.Add(33, "Guldlock:<i>They stopped following us. We're safe now... Can you Believe it? We are free!</i>");
		dialogs.Add(34, "Tuva:<i> I have a bad feeling though...</i>");
		dialogs.Add(35, "Guldlock:<i> What do you mean? We made it, we'll be fine!</i>");
		dialogs.Add(36, "Tuva:<i> W-Who are you old man?</i>");
		dialogs.Add(37, "Old man:<i> Hello there, young ones.</i>");


		dialogs.Add(38, "Guldlock:<i> This is wonderful! I'll finally meet them! I can finnaly find my real famaily! I'll find home! Oh, this is great! I'll-</i>");

		dialogs.Add(39, "Tuva:<i>...</i>");
		dialogs.Add(40, "Old man:<i> ..You could say i am a guardian of sorts. For you see the Tree Ghast haunts this area,</i>");
		dialogs.Add(41, "Old man:<i> ever looking for new victims, like you friend. They are horrid creatures, I tell you.</i>");
		dialogs.Add(42, "Tuva:<i> Why dind't you help her</i>");
		dialogs.Add(43, "Old man:<i> They are drawn to the light, you see. You better put it out if they are close,</i>");
		dialogs.Add(44, "Old man:<i> or they'll notice you. Oh, silly old me, I forget, humans can't do that.</i>");
		dialogs.Add(45, "Old man:<i> Follow me.</i>");

		dialogs.Add(46, "Old man:<i> There you are. Good thing you didn't get caught. Now follow me.</i>");
		dialogs.Add(47, "Tuva:<i> ....</i>");
		dialogs.Add(48, "Old man:<i> Are you coming or what?</i>");
		dialogs.Add(49, "< Press E or follow the old man >");
		dialogs.Add(50, "< Press E or follow the old man >");
		dialogs.Add(51, "< Press E or follow the old man >");


	}
	void Start () {



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

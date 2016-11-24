using UnityEngine;
using System.Collections;

public class TriggerDialog : MonoBehaviour {
	public int[] chat_array;
	public GameObject myHostsBubble;

	public int[] ReturnChatArray(){
		return chat_array;
	}
	public GameObject ReturnHostBubble(){
		return myHostsBubble;
	}
}

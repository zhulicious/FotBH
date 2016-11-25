using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickOption : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler{

	public GameObject choiceTree;
	public int number;

	public void OnPointerEnter(PointerEventData click){
		GetComponent<Text>().color = Color.green;
	}
	public void OnPointerDown(PointerEventData click){
		choiceTree.GetComponent<ChoiceTree>().ChangeScene(number);
	}	
	public void OnPointerExit(PointerEventData click){
		GetComponent<Text>().color = Color.black;
	}

}

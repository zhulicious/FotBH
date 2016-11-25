using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CS_Guldlock : MonoBehaviour {

	void Start () {
		StartCoroutine(ReturnToSlice());
	}
	IEnumerator ReturnToSlice(){
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("trollskog_vs_1");
	}
}

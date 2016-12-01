using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CS_Guldlock : MonoBehaviour {

	public float time;
	public string scene;

	void Start () {
		StartCoroutine(ReturnToSlice());
	}
	IEnumerator ReturnToSlice(){
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(scene);
	}
}

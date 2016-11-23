using UnityEngine; using UnityEngine.SceneManagement;
using System.Collections;

/*
P C E = Play, Credits, Exit

*/

public class PCE_buttonScript : MonoBehaviour {

    public MenuScript menuScript;
    public TuvaMenuScript tvms;
	
    public void ActivateMe ()
    {
        if (currentName == "Play")
        {
            //SceneManager.LoadScene("trollskog_vs_1");
            Debug.Log("LoadScene(trollskog)");
        }
        else if (currentName == "Credits")
        {
            tvms.AbortMission();
            menuScript.ChangeToCreditPanel("Credits");
        }
        else if (currentName == "Exit")
        {
            //Application.Quit();
            Debug.Log("Application.Quit();");
        }
        else if (currentName == "Return")
        {
            tvms.StartCoroutine("GetTuvaMoving");
            menuScript.ChangeToCreditPanel("Menu");
        }
    }

    string currentName 
    {
        get
        {
            return this.gameObject.name;
        }
    }
}

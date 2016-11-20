using UnityEngine; using UnityEngine.SceneManagement;
using System.Collections;

/*
P C E = Play, Credits, Exit

*/

public class PCE_buttonScript : MonoBehaviour {

    public MenuScript menuScript;
	
    public void ActivateMe ()
    {
        if (currentName == "Play")
        {
            SceneManager.LoadScene("trollskog_vs_1");
        }
        else if (currentName == "Credits")
        {
            menuScript.ChangeToCreditPanel("Credits");
        }
        else if (currentName == "Exit")
        {
            //Application.Quit();
            Debug.Log("Application.Quit();");
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

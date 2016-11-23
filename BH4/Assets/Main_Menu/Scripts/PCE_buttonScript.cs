using UnityEngine; using UnityEngine.SceneManagement;
using System.Collections;

/*
P C E = Play, Credits, Exit

*/

public class PCE_buttonScript : MonoBehaviour {

    public MenuScript menuScript;
<<<<<<< HEAD
    public TuvaMenuScript tvms;
=======
    public TuvaMenuScript tms;
>>>>>>> master
	
    public void ActivateMe ()
    {
        if (currentName == "Play")
        {
            //SceneManager.LoadScene("trollskog_vs_1");
            Debug.Log("LoadScene(trollskog)");
        }
        else if (currentName == "Credits")
        {
<<<<<<< HEAD
            tvms.AbortMission();
=======
            tms.StopWalkingTuva();
>>>>>>> master
            menuScript.ChangeToCreditPanel("Credits");
        }
        else if (currentName == "Exit")
        {
            //Application.Quit();
            Debug.Log("Application.Quit();");
        }
        else if (currentName == "Return")
        {
<<<<<<< HEAD
            tvms.StartCoroutine("GetTuvaMoving");
=======
            tms.StartCoroutine("TuvaMovingCoroutine");
>>>>>>> master
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

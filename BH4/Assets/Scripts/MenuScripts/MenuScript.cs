using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    GameObject titleButtons;
    GameObject return_button;

    public LayerMask button_mask;

    public Canvas canvas;
    GameObject menu_UI;
    GameObject credits_UI;

    public TuvaMenuScript tms;

    void Start ()
    {
        menu_UI = canvas.transform.GetChild(0).gameObject;
        credits_UI = canvas.transform.GetChild(1).gameObject;

        titleButtons = GameObject.Find("titlebuttons");
        return_button = GameObject.Find("Return");

        ChangeToCreditPanel("Menu");
    }

    void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown (0))
        {
            if (Physics.Raycast(ray, out hit, button_mask))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("hitobject: " + hitObject.name);
                    hitObject.SendMessage("ActivateMe", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }

    }



    public void ChangeToCreditPanel (string value)
    {
        if (value == "Menu")
        {
            titleButtons.gameObject.SetActive(true);
            return_button.gameObject.SetActive(false);
            menu_UI.SetActive(true);
            credits_UI.SetActive(false);
        }

        if (value == "Credits")
        {
            tms.StopWalkingTuva();
            titleButtons.gameObject.SetActive(false);
            return_button.gameObject.SetActive(true);
            menu_UI.SetActive(false);
            credits_UI.SetActive(true);
        }
    }

}

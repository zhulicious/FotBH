using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    GameObject play_button;
    GameObject credits_button;
    GameObject exit_button;

    public LayerMask button_mask;

    public Canvas canvas;
    GameObject menu_UI;
    GameObject credits_UI;

    void Start ()
    {
        play_button = GameObject.Find("Play");
        credits_button = GameObject.Find("Credits");
        exit_button = GameObject.Find("Exit");
        Debug.Log(play_button.name + ", " + credits_button.name + ", " + exit_button.name);

        menu_UI = canvas.transform.GetChild(0).gameObject;
        credits_UI = canvas.transform.GetChild(1).gameObject;
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
            menu_UI.SetActive(true);
            credits_UI.SetActive(false);
        }
        if (value == "Credits")
        {
            play_button.gameObject.SetActive(false);
            credits_button.gameObject.SetActive(false);
            exit_button.gameObject.SetActive(false);
            menu_UI.SetActive(false);
            credits_UI.SetActive(true);
        }
    }

}

using UnityEngine;
using System.Collections;

public class TuvaButtonScript : MonoBehaviour {

    GameObject D_Image;
    GameObject A_Image;
    GameObject E_Image;

    void Start ()
    {
        D_Image = this.transform.GetChild(0).gameObject;
        D_Image.SetActive(false);
        A_Image = this.transform.GetChild(1).gameObject;
        A_Image.SetActive(false);
        E_Image = this.transform.GetChild(2).gameObject;
        E_Image.SetActive(false);
    }

    public void DisplayKeyButtons (int activeButton)
    {
        if (activeButton == 0)
        {
            D_Image.SetActive(true);
        }
        else { D_Image.SetActive(false); }
        if (activeButton == 1)
        {
            A_Image.SetActive(true);
        }
        else { A_Image.SetActive(false); }
        if (activeButton == 2)
        {
            E_Image.SetActive(true);
        }
        else { E_Image.SetActive(false); }
    }
}

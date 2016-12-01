using UnityEngine;
using System.Collections;

public class LyktGubbe : AI {

    Light lyktLight;
    float maxLight;
    float minLight;
    float lerp;
    bool flash;
    bool lerpBool;

    void Awake()
    {
        lyktLight = GetComponent<Light>();
        lyktLight.range = 0;
        rightSide = true;
        maxLight = 10;
        minLight = 0;
        flash = false;
    }

    void Update()
    {
        if (flash)
        {
            Flash();
        }

    }
    //The Flash!
    void Flash()
    {
        lyktLight.range = Mathf.Lerp(minLight, maxLight, lerp);
        lerp += 0.5f * Time.deltaTime;

        if (lerp >= 1)
        {
            lerpBool = !lerpBool;
            float temp = maxLight;
            maxLight = minLight;
            minLight = temp;
            lerp = 0;
            if (!lerpBool)
            {
                flash = false;
            }
        }
    }
    //När ska han flasha
    void OnBecameInvisible()
    {
        flash = true;
    }
}

﻿using UnityEngine;
using System.Collections;

public class AudioTransition : MonoBehaviour {

    private GameObject backgroundAudio;

    private AudioSource background_one;
    private AudioSource background_two;

    private float track_one_volume;
    private float track_two_volume;

    public AudioClip caveBackgroundAudio;
    public AudioClip forestBackgroundAudio;

    public GameObject fadeOut_Start; //<---Triggers
    public GameObject fadeOut_End;
    private float distanceBetweenTriggers;
    
    private bool exitingCave;
    private bool leftCave;
    public GameObject player;

	void Start () {
        backgroundAudio = transform.GetChild(0).gameObject;
        background_one = backgroundAudio.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        background_two = backgroundAudio.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        distanceBetweenTriggers = Vector2.Distance(fadeOut_Start.transform.position, fadeOut_End.transform.position);
        track_one_volume = background_one.volume;
        track_two_volume = background_two.volume;
    }
	
	
	void Update () {
        if(exitingCave && !leftCave)
        {
           Background_Two.volume = FadeAudioOut(track_two_volume, distanceBetweenTriggers);
           Background_One.volume = FadeAudioIn(distanceBetweenTriggers);
        }
	
	}
    private float FadeAudioOut(float volume, float distance)
    {     
        float disTweenPlayerAndExit = Vector2.Distance(player.transform.position, fadeOut_End.transform.position);
        float newVolume = volume *(disTweenPlayerAndExit / distanceBetweenTriggers);

        return newVolume;
    }
    private float FadeAudioIn(float distance)
    {
        float disTweenPlayerAndStartTigger = Vector2.Distance(player.transform.position, fadeOut_Start.transform.position);
        float newVolume = (disTweenPlayerAndStartTigger / distanceBetweenTriggers);

        return newVolume;
    }

    public bool ExitingCave {get { return exitingCave;} set { exitingCave = value;}}
    public bool LeftCave { get { return leftCave; } set { leftCave = value;} }
    public AudioSource Background_One { get{ return background_one; } set { background_one = value;} }
    public AudioSource Background_Two { get { return background_two; } set { background_two = value; } }

}
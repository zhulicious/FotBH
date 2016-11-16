using System.Collections.Generic;
using UnityEngine;

public class Audio_Mama : MonoBehaviour {

    private AudioSource mainBackGroundTrack;
    private AudioSource owlHoots;

    public List<AudioClip> puddleFootSteps;
    public List<AudioClip> caveFootStep;

    public AudioClip caveBackGroundTrack;
    public AudioClip forestBackGroundTrack;
    public AudioClip owlHootTrack;

    
    void Start()
    {
        mainBackGroundTrack = transform.GetChild(0).transform.GetChild(0).GetComponent<AudioSource>();
        owlHoots = transform.GetChild(0).transform.GetChild(1).GetComponent<AudioSource>();
    }

    public void PlayCaveBackGroundTrack()
    {
        mainBackGroundTrack.clip = caveBackGroundTrack;
    }
    public void PlayForestBackGroundTrack()
    {
        mainBackGroundTrack.clip = forestBackGroundTrack;
    }
    
}

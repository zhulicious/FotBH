using System.Collections.Generic; //Author: Axel Stenkrona.
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private Dictionary<string, AudioSource> allAudioSources;
    private AllAudioUsedInScene aauis;
    private AudioSource fullTrackSpeaker;

    public bool debugLog;

    void Awake()
    {
        if (debugLog) Debug.Log("AudioManager Awaking");
        fullTrackSpeaker = transform.GetChild(4).GetChild(4).GetComponent<AudioSource>();
        allAudioSources = new Dictionary<string, AudioSource>();
        allAudioSources.Add("fullTrackSpeaker", fullTrackSpeaker);
        


       
       
        if (debugLog) Debug.Log("AudioManager Awoken");
    }

 

    public void PlayOrStopTheme(bool b) // if b is true "ThemeSong" will play. If b is false "ThemeSong" will stop;
    {
        {
            if (b)
            {
                if (debugLog) Debug.Log("Audio: Playing Theme.");
                allAudioSources["fullTrackSpeaker"].Play();
            }
            else
            {
                if (debugLog) Debug.Log("Audio: Theme Stopped");
                allAudioSources["fullTrackSpeaker"].Stop();
            }
        }
    }
    
    
    //Properties

   
  
    public AllAudioUsedInScene AAUIS { get { return aauis;} set { aauis = value; } }
    public Dictionary<string, AudioSource> AllAudioSources { get{ return allAudioSources; } set{ allAudioSources = value; } }
    
  


}
public struct AudioPackage
{
    public Dictionary<string, AudioClip[]> foley;
    public Dictionary<string, AudioClip[]> fx;
    public Dictionary<string, AudioClip> dia;
    public Dictionary<string, AudioClip> atm;
    public Dictionary<string, AudioClip> mus;
}


public struct DIA
{
    public AudioSource playerAudioReference;
    public AudioSource nPC_AudioReference;
}
public struct FX
{
  
}
public struct Foley
{
    public AudioClip[][] footSteps;
}
public struct ATM
{
    public AudioSource currentTrack;
    public AudioSource nextTrack;
   
}
public struct MUS
{
    public AudioSource melody;
    public AudioSource rhytm;
    public AudioSource bass;
    public AudioSource percussion;
    public AudioSource allInOne;
}
public struct AudioKing
{
    public DIA _dia;
    public FX _fx;
    public Foley _foley;
    public ATM _atm;
    public MUS _mus;
}

public struct AllAudioUsedInScene
{
    public AudioPackage tuvaAudioPackage;
    public AudioPackage lgAudioPackage;
    public AudioPackage fcAudioPackage;
    public AudioPackage glAudioPackage;
    public AudioPackage mainMenyPackage;
    public MUS_Storage musicAudioPackage;
}
public struct MUS_Storage
{
    public Dictionary<string, MUS> allTracks;
}





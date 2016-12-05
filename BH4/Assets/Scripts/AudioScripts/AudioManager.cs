using System.Collections.Generic; //Author: Axel Stenkrona.
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private Dictionary<string, AudioSource> allAudioSources;                    // AudioSources:
    private AllAudioUsedInScene aauis;                                          // fullTrackSpeaker, musicMelody, musicRhythm, musicPercussion, musicBass, atm, dialogueOne, dialogueTwo
    private AudioSource fullTrackSpeaker;
 

    private int fcAudioStateIndex;
    private bool fcActive;


    public bool debugLog;

    void Awake()
    {
        if (debugLog) Debug.Log("AudioManager Awaking");
        fullTrackSpeaker = transform.GetChild(4).GetChild(4).GetComponent<AudioSource>();
        allAudioSources = new Dictionary<string, AudioSource>();
        allAudioSources.Add("fullTrackSpeaker", fullTrackSpeaker);

        //Music AudioSources
        allAudioSources.Add("musicMelody", transform.GetChild(4).GetChild(0).GetComponent<AudioSource>());
        allAudioSources.Add("musicRhythm", transform.GetChild(4).GetChild(1).GetComponent<AudioSource>());
        allAudioSources.Add("musicBass", transform.GetChild(4).GetChild(2).GetComponent<AudioSource>());
        allAudioSources.Add("musicPercussion", transform.GetChild(4).GetChild(3).GetComponent<AudioSource>());

        //ATM
        allAudioSources.Add("atm", transform.GetChild(3).GetComponent<AudioSource>());

        //DIA
        allAudioSources.Add("dialogueOne", transform.GetChild(0).GetChild(0).GetComponent<AudioSource>());
        allAudioSources.Add("dialogueTwo", transform.GetChild(0).GetChild(1).GetComponent<AudioSource>());







        if (debugLog) Debug.Log("AudioManager Awoken");
    }
    void Update()
    {
        if (fcActive)
        {
            ForestCreatureAudioStates(fcAudioStateIndex);
        }
    }



   
    public void PlayATM(bool b) // Turn on or off the ATM audio.
    {
      if(b)
        {
            if (debugLog) Debug.Log("Audio: Playing ATM.");
            allAudioSources["atm"].Play();
        }
      else
        {
            if (debugLog) Debug.Log("Audio: ATM Stopped.");
            allAudioSources["atm"].Stop();
        }
    }
   
    public void PlayMusic(string trackname)
    {
        allAudioSources["fullTrackSpeaker"].clip = aauis.musicAudioPackage.musicTracks[trackname];
        allAudioSources["fullTrackSpeaker"].Play();
    }
    public void StopAudioSource(string audioSourceName)
    {
        allAudioSources[audioSourceName].Stop();
    }
    public void PlayDIAOne(AudioClip ac)
    {
        allAudioSources["dialogueOne"].PlayOneShot(ac);
    }
    public void PlayDIATwo(AudioClip ac)
    {
        allAudioSources["dialogueTwo"].PlayOneShot(ac);
    }
    public void ForestCreatureAudioStates(int state) 
    {
        switch (state)
        {
            case 0: LerpVolume(1f,"musicBass", 0.5f);
                    LerpVolume(0f, "musicMelody", 0.5f);
                    LerpVolume(0f, "musicPercussion", 0.5f);
                break;

            case 1: LerpVolume(1f, "musicMelody", 0.5f);
                
                break;

            case 2: LerpVolume(0f, "musicBass", 0.25f);
                    LerpVolume(0f, "musicMelody", 0.25f);
                    LerpVolume(1f, "musicPercussion", 0.25f);
                    
                break;

                    
        }
            
    }
    public void LerpVolume(float wantedvolume, string audioSourceName, float time) //<<<<Volume is the float you want to fade to.
    {
        float currentVolune = allAudioSources[audioSourceName].volume;
        AudioSource audioSource = allAudioSources[audioSourceName];
        audioSource.volume = Mathf.Lerp(audioSource.volume, wantedvolume, time * Time.deltaTime);
    }    
    public void ActivateAudio_FC(bool b)
    {
        if (debugLog) Debug.Log("Activate Audio_FC: " + b.ToString());

        ActivateAllMusicTracks(false);

         AllAudioSources["musicBass"].clip = aauis.musicAudioPackage.mus_dictionary["ForestCreature"]["wholeBass"]; //Placing audiotracks in correct audiosource.
         AllAudioSources["musicMelody"].clip = aauis.musicAudioPackage.mus_dictionary["ForestCreature"]["wholeMelody"];
         AllAudioSources["musicPercussion"].clip = aauis.musicAudioPackage.mus_dictionary["ForestCreature"]["wholeMelody"];

        ActivateAllMusicTracks(true);

        fcActive = b;
    } //< This should be called when the ForestCreature is triggered.
    public void ActivateAllMusicTracks(bool o)
    {
        if(o)
        {
            AllAudioSources["musicBass"].Play();
            AllAudioSources["musicMelody"].Play();
            allAudioSources["musicPercussion"].Play();
        }
        else
        {
            AllAudioSources["musicBass"].Stop();
            AllAudioSources["musicMelody"].Stop();
            allAudioSources["musicPercussion"].Stop();
        }
    } // Call this if you want to play or stop all four music tracks (Not the theme track).
   




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


public struct MUS
{
    public AudioSource melody;
    public AudioSource rhytm;
    public AudioSource bass;
    public AudioSource percussion;
    public AudioSource allInOne;
}



public struct AllAudioUsedInScene
{
    public AudioPackage tuvaAudioPackage;
    public AudioPackage lgAudioPackage;
    public AudioPackage fcAudioPackage;
    public AudioPackage glAudioPackage;
    public AudioPackage mainMenyPackage;
    public MUS_Storage musicAudioPackage;
    public AudioClip atm;
}
public struct MUS_Storage
{
    public Dictionary<string, Dictionary<string, AudioClip>> mus_dictionary;
    public Dictionary<string, AudioClip> musicTracks;
}





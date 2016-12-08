using System.Collections;
using System.Collections.Generic; //Author: Axel Stenkrona.
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private Dictionary<string, AudioSource> allAudioSources;                    // AudioSources:
    private AllAudioUsedInScene aauis;                                          // fullTrackSpeaker, musicMelody, musicRhythm, musicPercussion, musicBass, atm, dialogueOne, dialogueTwo
    private AudioSource fullTrackSpeaker;
    private Dictionary<string, AudioClip> forestCreatureTrack;

    private int fcAudioStateIndex;
    private bool fcActive;
    private bool isTuvaSafe;

    private bool fadeinOrout;
    private float time;
    private AudioSource fadeAoudioSource;

    public bool debugLog;

    void Awake()
    {
        if (debugLog) Debug.Log("AudioManager Awaking");

        AAUIS = new AllAudioUsedInScene();
        aauis.fcAudioPackage = new AudioPackage();
        aauis.fcAudioPackage.fx = new Dictionary<string, AudioClip[]>();
        aauis.musicAudioPackage = new MUS_Storage();
        aauis.musicAudioPackage.mus_dictionary = new Dictionary<string, Dictionary<string, AudioClip>>();
        aauis.musicAudioPackage.musicTracks = new Dictionary<string, AudioClip>();
        aauis.atm = new Dictionary<string, AudioClip>();

        aauis.tuvaAudioPackage = new AudioPackage();
        aauis.tuvaAudioPackage.foley = new Dictionary<string, AudioClip[]>();

        aauis.lgAudioPackage = new AudioPackage();
        aauis.lgAudioPackage.foley = new Dictionary<string, AudioClip[]>();

        forestCreatureTrack = new Dictionary<string, AudioClip>();
        aauis.musicAudioPackage.mus_dictionary.Add("ForestCreature", forestCreatureTrack);

        fullTrackSpeaker = transform.GetChild(4).GetChild(4).GetComponent<AudioSource>();
        allAudioSources = new Dictionary<string, AudioSource>();
        allAudioSources.Add("fullTrackSpeaker", fullTrackSpeaker);

        //Music AudioSources
        allAudioSources.Add("musicMelody", transform.GetChild(4).GetChild(0).GetComponent<AudioSource>());
        allAudioSources.Add("musicRhythm", transform.GetChild(4).GetChild(1).GetComponent<AudioSource>());
        allAudioSources.Add("musicBass", transform.GetChild(4).GetChild(2).GetComponent<AudioSource>());
        allAudioSources.Add("musicPercussion", transform.GetChild(4).GetChild(3).GetComponent<AudioSource>());

        //ATM
        allAudioSources.Add("atm_one", transform.GetChild(3).GetChild(0).GetComponent<AudioSource>());
        allAudioSources.Add("atm_two", transform.GetChild(3).GetChild(1).GetComponent<AudioSource>());

        //DIA
        allAudioSources.Add("dialogueOne", transform.GetChild(0).GetChild(0).GetComponent<AudioSource>());
        allAudioSources.Add("dialogueTwo", transform.GetChild(0).GetChild(1).GetComponent<AudioSource>());







        if (debugLog) Debug.Log("AudioManager Awoken");
    }
    void Update()
    {

    }




    public void PlayATM(bool b) // Turn on or off the ATM audio.
    {
        if (b)
        {
            if (debugLog) Debug.Log("Audio: Playing ATM.");
            allAudioSources["atm_one"].Play();
            allAudioSources["atm_two"].Play();
        }
        else
        {
            if (debugLog) Debug.Log("Audio: ATM Stopped.");
            allAudioSources["atm_one"].Stop();
            allAudioSources["atm_two"].Stop();
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
        if (debugLog) Debug.Log("Playing: " + state.ToString());
        {
            switch (state)
            {

                case (int)EnemyMode.Relaxed:

                    StartCoroutine("FadeInVolumeBass");
                    StartCoroutine("FadeOutVolumeMelody");
                    StartCoroutine("FadeOutVolumePercussion");


                    break;

                case (int)EnemyMode.Turning:
                    StartCoroutine("FadeInVolumeMelody");

                    break;

                case (int)EnemyMode.Search:
                    StartCoroutine("FadeInVolumeBass");


                    StartCoroutine("FadeOutMelody");
                    StartCoroutine("FadeInPercussion");


                    break;
                case (int)EnemyMode.ChasingPlayer:
                    StartCoroutine("FadeInVolumeBass");
                    StartCoroutine("FadeInVolumeMelody");
                    StartCoroutine("FadeInVolumePercussion");
                    break;


            }
        }

    }
    public void TuvaSafe()
    {
        if (debugLog) Debug.Log("Thank You for using TuvaSafe");

        StartCoroutine("FadeOutVolumeBass");
        StartCoroutine("FadeOutVolumeMelody");
        StartCoroutine("FadeInVolumePercussion");
    }
    public void LerpVolume(float wantedvolume, string audioSourceName, float time) //<<<<Volume is the float you want to fade to.
    {

        //float currentVolume = allAudioSources[audioSourceName].volume;
        AudioSource audioSource = allAudioSources[audioSourceName];
        audioSource.volume = Mathf.Lerp(audioSource.volume, wantedvolume, time);
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
        if (o)
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

    IEnumerator FadeInVolumeBass()
         { 

            while (AllAudioSources["musicBass"].volume < 0.01f)
            {
                 AllAudioSources["musicBass"].volume -= Time.deltaTime / 0.5f;
                 yield return null;
            }  
             }
    IEnumerator FadeOutVolumeBass()
    {
        while (AllAudioSources["musicBass"].volume > 1.0f)
        {
            AllAudioSources["musicBass"].volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }
    IEnumerator FadeInVolumeMelody()
    {
        while (AllAudioSources["musicMelody"].volume < 0.01f)
        {
            AllAudioSources["musicMelody"].volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }
    IEnumerator FadeOutVolumeMelody()
    {
        while (AllAudioSources["musicMelody"].volume > 1.0f)
        {
            AllAudioSources["musicMelody"].volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }
    IEnumerator FadeInVolumePercussion()
    {
        while (AllAudioSources["musicPercussion"].volume < 0.01f)
        {
            AllAudioSources["musicPercussion"].volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }
    IEnumerator FadeOutVolumePercussion()
    {
        while (AllAudioSources["musicPercussion"].volume > 1.0f)
        {
            AllAudioSources["musicPercussion"].volume -= Time.deltaTime / 0.5f;
            yield return null;
        }
    }



    //Properties



    public AllAudioUsedInScene AAUIS { get { return aauis; } set { aauis = value; } }
    public Dictionary<string, AudioSource> AllAudioSources { get { return allAudioSources; } set { allAudioSources = value; } }
    public bool FCActive { get { return fcActive; } set { fcActive = value; } }
    public bool IsTuvaSafe {get{return isTuvaSafe;} set{isTuvaSafe = value;}}
 
    
    
  


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
    public Dictionary<string, AudioClip> atm;
}
public struct MUS_Storage
{
    public Dictionary<string, Dictionary<string, AudioClip>> mus_dictionary;
    public Dictionary<string, AudioClip> musicTracks;
}





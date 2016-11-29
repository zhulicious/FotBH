using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioManagerSpeaker;

    private AudioClip[] backgroundTracks;

    private AudioClip[] caveFootsteps;
    private AudioClip[] puddleFootsteps;
    private AudioClip[] tuvaVoice;

    private AudioClip[] miscellaneous;
    private AudioClip[] menuSounds;

    private TuvaAudioPackage tuvaAudioPack;
    private TuvaVoice tuvaVoiceSource;
    private TuvaSteps tuvaStepsSource;

    private DIA _dia;
    private FX _fx;
    private Foley _folay;
    private ATM _atm;
    private MUS _mus;




    void Awake()
    {

       

        audioManagerSpeaker = transform.GetChild(1).GetComponent<AudioSource>();
       //udioManagerSpeaker.clip = themeSong;

       //hemeSong = Resources.Load<AudioClip>("Audio/Theme/Audio_Spelman");
       //f (themeSong == null) { Debug.Log("themeSong = null"); }

        backgroundTracks = Resources.LoadAll<AudioClip>("Audio/BackgroundTracks");
        if (backgroundTracks == null) { Debug.Log("backgroundTracks = null"); }

        caveFootsteps = Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Cave");
        puddleFootsteps = Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Puddles");
        tuvaVoice = Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/Voice");

        miscellaneous = Resources.LoadAll<AudioClip>("Audio/SoundFX/Enviroment/Miscellaneous");
        menuSounds = Resources.LoadAll<AudioClip>("Audio/SoundFX/MenuSounds");



        tuvaStepsSource.stepsPuddle = puddleFootsteps;
        tuvaStepsSource.stepsCave = caveFootsteps;

        tuvaAudioPack.tuvaStepsPack = tuvaStepsSource;
        tuvaAudioPack.tuvaVoicePack = tuvaVoiceSource;

    }

    public struct TuvaAudioPackage
    {
        public TuvaSteps tuvaStepsPack;
        public TuvaVoice tuvaVoicePack;
    }
    public struct TuvaVoice
    {
        public AudioClip tuvaDie;
    }
    public struct TuvaSteps
    {
        public AudioClip[] stepsPuddle;
        public AudioClip[] stepsCave;
    }

    public void PlayOrStopTheme(bool b) // if b is true "ThemeSong" will play. If b is false "ThemeSong" will stop;
    {
      //if (audioManagerSpeaker.clip.name != themeSong.name)
        {
        //  audioManagerSpeaker.clip = themeSong;
            if (b)
            {
                audioManagerSpeaker.Play();
            }
            else
            {
                audioManagerSpeaker.Stop();
            }
        }
    }


    //Properties

   //ublic AudioClip ThemeSong { get { return themeSong; } set { themeSong = value; } }
    public AudioClip[] BackgroundTracks { get { return backgroundTracks; } set { backgroundTracks = value; } }
    public AudioClip[] Miscellaneous { get { return miscellaneous; } set { miscellaneous = value; } } // "Audio_BranchSnap", "Audio_OwlHooting", "Audio_RustlingBushes", "Audio_SearchingInBushes", "Audio_TwigSnap".
    public AudioClip[] MenuSounds { get { return menuSounds; } set { menuSounds = value; } } // "Audio_BackEscBtn", "Audio_ClickBtn", "Audio_MouseOverBtn".

    public TuvaAudioPackage TuvaAudioPack { get { return tuvaAudioPack; } set { tuvaAudioPack = value; } } // This struct has all sounds relating to Tuva.

   

   
   
    public AudioSource AudioManagerSpeaker { get { return audioManagerSpeaker; } set { audioManagerSpeaker = value; } }

    public DIA _DIA { get { return _dia; } set { _dia = value; } }
    public FX _FX { get { return _fx; } set { _fx = value; } }
    public Foley _Folay {get{return _folay;} set{_folay = value;}}
    public ATM _ATM {get{return _atm;} set{_atm = value;}}
    public MUS _Mus {get{return _mus ;} set{_mus = value;}}


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
    public AudioSource playerAudioReference;
    public AudioSource nPCAudioReference;
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
}



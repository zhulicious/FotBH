using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioManagerSpeaker;
    private AudioSource background_one;
    private AudioSource background_two;

    private GameObject backgroundAudio;

    private AudioClip themeSong;

    private AudioClip[] backgroundTracks;

    private AudioClip[] caveFootsteps;
    private AudioClip[] puddleFootsteps;
    private AudioClip[] tuvaVoice;

    private AudioClip[] miscellaneous;
    private AudioClip[] menuSounds;

    private TuvaAudioPackage tuvaAudioPack;
    private TuvaVoice tuvaVoiceSource;
    private TuvaSteps tuvaStepsSource;

    void Awake()
    {
    
        backgroundAudio = transform.GetChild(0).gameObject;
        background_one = backgroundAudio.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        background_two = backgroundAudio.transform.GetChild(1).gameObject.GetComponent<AudioSource>();

        audioManagerSpeaker = transform.GetChild(1).GetComponent<AudioSource>();
        audioManagerSpeaker.clip = themeSong;

        themeSong = Resources.Load<AudioClip>("Audio/Theme/Audio_Spelman");
        if (themeSong == null) { Debug.Log("themeSong = null"); }
    
        backgroundTracks = Resources.LoadAll<AudioClip>("Audio/BackgroundTracks"); 
        if(backgroundTracks == null) { Debug.Log("backgroundTracks = null"); }

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
        if (audioManagerSpeaker.clip.name != themeSong.name)
        {
            audioManagerSpeaker.clip = themeSong;
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

    public AudioClip ThemeSong { get { return themeSong; } set { themeSong = value; } }
    public AudioClip[] BackgroundTracks { get { return backgroundTracks; } set { backgroundTracks = value; } }
    public AudioClip[] Miscellaneous { get { return miscellaneous; } set { miscellaneous = value; } } // "Audio_BranchSnap", "Audio_OwlHooting", "Audio_RustlingBushes", "Audio_SearchingInBushes", "Audio_TwigSnap".
    public AudioClip[] MenuSounds { get { return menuSounds; } set { menuSounds = value; } } // "Audio_BackEscBtn", "Audio_ClickBtn", "Audio_MouseOverBtn".

    public TuvaAudioPackage TuvaAudioPack { get { return tuvaAudioPack; } set { tuvaAudioPack = value; } } // This struct has all sounds relating to Tuva.

    public GameObject BackgroundAudio { get { return backgroundAudio; } set { backgroundAudio = value; } }

    public AudioSource Background_One { get { return background_one; } set { background_one = value; } }
    public AudioSource Background_Two { get { return background_two; } set { background_two = value; } }
    public AudioSource AudioManagerSpeaker { get { return audioManagerSpeaker; } set { audioManagerSpeaker = value;} }
}

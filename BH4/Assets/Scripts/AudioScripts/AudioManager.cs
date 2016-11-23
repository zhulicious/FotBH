using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioManagerSpeaker;

    private AudioClip themeSong;

    private AudioClip[] backgroundTracks;

    private AudioClip[] caveFootsteps;
    private AudioClip[] puddleFootsteps;

    private AudioClip[] miscellaneous;
    private AudioClip[] menuSounds;

    void Start()
    {
        audioManagerSpeaker = transform.GetChild(1).GetComponent<AudioSource>();
        audioManagerSpeaker.clip = themeSong;

        themeSong = Resources.Load("Audio/Theme") as AudioClip;
        backgroundTracks = Resources.LoadAll("Audio/BackgroundTracks") as AudioClip[];

        caveFootsteps = Resources.LoadAll("Audio/Actor/Tuva/FootSteps/Cave") as AudioClip[];
        puddleFootsteps = Resources.LoadAll("Audio/Actor/Tuva/FootSteps/Puddles") as AudioClip[];

        miscellaneous = Resources.LoadAll("Audio/SoundFX/Enviroment/Miscellaneous") as AudioClip[];
        menuSounds = Resources.LoadAll("Audio/SoundFX/MenuSounds") as AudioClip[];


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
    public AudioClip[] CaveFootsteps { get { return caveFootsteps; } set { caveFootsteps = value; } } // 8 sounds.
    public AudioClip[] PuddleFootsteps {get{return puddleFootsteps ;} set{puddleFootsteps = value;}} // 10 sounds
    public AudioClip[] Miscellaneous { get { return miscellaneous; } set { miscellaneous = value; } } // "Audio_BranchSnap", "Audio_OwlHooting", "Audio_RustlingBushes", "Audio_SearchingInBushes", "Audio_TwigSnap".
    public AudioClip[] MenuSounds { get { return menuSounds; } set { menuSounds = value; } } // "Audio_BackEscBtn", "Audio_ClickBtn", "Audio_MouseOverBtn".

    
}

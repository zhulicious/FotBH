using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioClip[] backgroundTracks;

    private AudioClip[] caveFootsteps;
    private AudioClip[] puddleFootsteps;
    private AudioClip[] tuvaVoice;

    private AudioClip[] miscellaneous;
    private AudioClip[] menuSounds;

    private AudioKing audioKing;

    public bool debugLog;

    void Awake()
    {
        if (debugLog) Debug.Log("AudioManager Awaking");

        audioKing = new AudioKing();
        audioKing._dia = new DIA();
        audioKing._fx = new FX();
        audioKing._foley = new Foley();
        audioKing._atm = new ATM();
        audioKing._mus = new MUS();


       
       
        if (debugLog) Debug.Log("AudioManager Awoken");
    }

 

    public void PlayOrStopTheme(bool b) // if b is true "ThemeSong" will play. If b is false "ThemeSong" will stop;
    {
        {
            if (b)
            {
                if (debugLog) Debug.Log("Audio: Playing Theme.");
                AudioKing._mus.allInOne.Play();
            }
            else
            {
                if (debugLog) Debug.Log("Audio: Theme Stopped");
                AudioKing._mus.allInOne.Stop();
            }
        }
    }
    
    //Properties

   
    public AudioClip[] BackgroundTracks { get { return backgroundTracks; } set { backgroundTracks = value; } }
    public AudioClip[] Miscellaneous { get { return miscellaneous; } set { miscellaneous = value; } } // "Audio_BranchSnap", "Audio_OwlHooting", "Audio_RustlingBushes", "Audio_SearchingInBushes", "Audio_TwigSnap".
    public AudioClip[] MenuSounds { get { return menuSounds; } set { menuSounds = value; } } // "Audio_BackEscBtn", "Audio_ClickBtn", "Audio_MouseOverBtn".

    public AudioKing AudioKing {get{return audioKing;} set{audioKing = value;}}
  


}

public struct DIA
{
    public AudioSource playerAudioReference;
    public AudioSource nPC_AudioReference;
}
public struct FX
{
    public AudioSource buttons;
    public AudioClip clicked;
    public AudioClip back_esc;
    public AudioClip hoverOver;
}
public struct Foley
{
    public AudioSource playerAudioReference;
    public AudioSource nPCAudioReference;
    public AudioClip[] tuva_PuddleSteps;
    public AudioClip[] tuva_CaveSteps;
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



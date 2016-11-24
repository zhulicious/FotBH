using UnityEngine; // This class is meant for the transition between the cave soundtrack and the forest soundtrack. A prefab of this class on a gameobject 
                   // can be found in Assets/Prefabs/AudioPrefabs.
public class AudioTransition : MonoBehaviour {

  
    private AudioManager am_Ref;

    private float track_one_volume;
    private float track_two_volume;

    private AudioClip caveBackgroundAudio; //These clips can be find in Assets/Audio/Background.
    private AudioClip forestBackgroundAudio;

    public GameObject fadeOut_Start; //<---Triggers, prefabs of these gameObjects can be found in Assets/Prefabs/AudioPrefabs.
    public GameObject fadeOut_End;
    private float distanceBetweenTriggers;
    
    private bool exitingCave;
    private bool leftCave;
    public GameObject player;

	void Start () {
        fadeOut_End.GetComponent<A_AudioTrigger>().SetAT_RefAndAM_Ref(this, AM_Ref);
        fadeOut_Start.GetComponent<A_AudioTrigger>().SetAT_RefAndAM_Ref(this, AM_Ref);

        am_Ref = GetComponent<AudioManager>(); //Works.
       
        distanceBetweenTriggers = Vector2.Distance(fadeOut_Start.transform.position, fadeOut_End.transform.position);
        track_one_volume = am_Ref.Background_One.volume;
        track_two_volume = am_Ref.Background_Two.volume;

        AM_Ref.Background_One.clip = am_Ref.BackgroundTracks[1]; // <-ForestBackground.
        AM_Ref.Background_Two.clip = am_Ref.BackgroundTracks[0]; // <-CaveBackground.
        AM_Ref.Background_Two.Play();
    }
	
	
	void Update () {
        if(exitingCave && !leftCave)
        {
            AM_Ref.Background_One.panStereo = AM_Ref.Background_Two.volume = FadeAudioOut(track_two_volume, distanceBetweenTriggers);
           AM_Ref.Background_One.volume = FadeAudioIn(distanceBetweenTriggers);
           
        }
	
	}
    private float FadeAudioOut(float volume, float distance)
    {     
        float disTweenPlayerAndExit = Vector2.Distance(player.transform.position, fadeOut_End.transform.position);
        float newVolume = volume * (disTweenPlayerAndExit / distanceBetweenTriggers) * (disTweenPlayerAndExit / distanceBetweenTriggers);

        return newVolume;
    }
    private float FadeAudioIn(float distance)
    {
        float disTweenPlayerAndStartTigger = Vector2.Distance(player.transform.position, fadeOut_Start.transform.position);
        float newVolume = (disTweenPlayerAndStartTigger / distanceBetweenTriggers) * (disTweenPlayerAndStartTigger / distanceBetweenTriggers);

        return newVolume;
    }

    public bool ExitingCave {get { return exitingCave;} set { exitingCave = value;}}
    public bool LeftCave { get { return leftCave; } set { leftCave = value;} }
    public AudioManager AM_Ref { get { return am_Ref; } set { am_Ref = value; } }

}

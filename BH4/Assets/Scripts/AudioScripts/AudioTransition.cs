using UnityEngine; // This class is meant for the transition between the cave soundtrack and the forest soundtrack. A prefab of this class on a gameobject 
                   // can be found in Assets/Prefabs/AudioPrefabs.
public class AudioTransition : MonoBehaviour {

    private GameObject backgroundAudio;
    private AudioManager am_Ref;

    private AudioSource background_one;
    private AudioSource background_two;

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
        backgroundAudio = transform.GetChild(0).gameObject;
        background_one = backgroundAudio.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        background_two = backgroundAudio.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        distanceBetweenTriggers = Vector2.Distance(fadeOut_Start.transform.position, fadeOut_End.transform.position);
        track_one_volume = background_one.volume;
        track_two_volume = background_two.volume;

        Background_One.clip = am_Ref.BackgroundTracks[1]; // <-ForestBackground.
        Background_Two.clip = am_Ref.BackgroundTracks[0]; // <-CaveBackground.

    }
	
	
	void Update () {
        if(exitingCave && !leftCave)
        {
            Background_One.panStereo = Background_Two.volume = FadeAudioOut(track_two_volume, distanceBetweenTriggers);
           Background_One.volume = FadeAudioIn(distanceBetweenTriggers);
           
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
    public AudioSource Background_One { get{ return background_one; } set { background_one = value;} }
    public AudioSource Background_Two { get { return background_two; } set { background_two = value; } }

}

using UnityEngine; //This class should be but on triggers, one close to the exit of the cave and the other right after leaving the cave. 

public class A_AudioTrigger : MonoBehaviour {

    private AudioTransition at_Ref;
    private AudioManager am_Ref;
    public bool isFadeOutStart; // In the expector you check this if the trigger is the trigger right before the exit.

    public void SetAT_RefAndAM_Ref(AudioTransition x, AudioManager m)
    {
        at_Ref = x;
        am_Ref = m;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
           

            if (isFadeOutStart)
            {
              
                if (!at_Ref.ExitingCave)
                {
                  
                    am_Ref.AudioKing._atm.nextTrack.Play();
                    at_Ref.ExitingCave = true;
                }
                else
                {
                  
                    at_Ref.ExitingCave = false;
                    am_Ref.AudioKing._atm.currentTrack.Stop();

                }
            }
            else
            {
                
                am_Ref.AudioKing._atm.currentTrack.Stop();

                at_Ref.LeftCave = true;
            }
           
        }
       
    }
}

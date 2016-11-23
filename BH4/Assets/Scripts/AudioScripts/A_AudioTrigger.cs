using UnityEngine; //This class should be but on triggers, one close to the exit of the cave and the other right after leaving the cave. 

public class A_AudioTrigger : MonoBehaviour {

    private AudioTransition at_Ref;
    private AudioManager am_Ref;
    public bool isFadeOutStart; // In the expector you check this if the trigger is the trigger right before the exit.

    private void Start()
    {
        at_Ref = GameObject.Find("AudioManager").GetComponent<AudioTransition>();
        am_Ref = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
           

            if (isFadeOutStart)
            {
              
                if (!at_Ref.ExitingCave)
                {
                  
                    at_Ref.Background_One.Play();
                    at_Ref.ExitingCave = true;
                }
                else
                {
                  
                    at_Ref.ExitingCave = false;
                    at_Ref.Background_One.Stop();

                }
            }
            else
            {
                
                at_Ref.Background_Two.Stop();
                at_Ref.Background_Two.clip = am_Ref.Miscellaneous[1]; 
                at_Ref.LeftCave = true;
            }
           
        }
       
    }
}

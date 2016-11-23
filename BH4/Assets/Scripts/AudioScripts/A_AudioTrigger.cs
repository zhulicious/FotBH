using UnityEngine; //This class should be but on triggers, one close to the exit of the cave and the other right after leaving the cave. 

public class A_AudioTrigger : MonoBehaviour {

    public AudioTransition at_Ref;
    public bool isFadeOutStart; // In the expector you check this if the trigger is the trigger right before the exit.
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            Debug.Log("isPlayer = true");

            if (isFadeOutStart)
            {
                Debug.Log("isFadeOutStartTrigger = true");
                if (!at_Ref.ExitingCave)
                {
                    Debug.Log("exiting cave = false");
                    at_Ref.Background_One.Play();
                    at_Ref.ExitingCave = true;
                }
                else
                {
                    Debug.Log("exiting cave = true");
                    at_Ref.ExitingCave = false;
                    at_Ref.Background_One.Stop();

                }
            }
            else
            {
                Debug.Log("is Fade Out End.");
                at_Ref.Background_Two.Stop();
                at_Ref.LeftCave = true;
            }
           
        }
       
    }
}

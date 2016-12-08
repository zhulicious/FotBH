using UnityEngine;

public enum EnemyMode {Relaxed = 0, Turning = 1, Search = 2, ChasingPlayer = 3 }

public class EnemyBehaviour : MonoBehaviour { //This script is the AI for the tree monster. The idea is to use a switch with four cases. 

	public Script_Mama_ForestCreature gamePlayRef; // This is the mother script that has all the scripts thats needed to make this part of the game work.
	public GameObject friendlyOldMan; // This is the NPC that carries a lantern and will extinguish the flame when the mosnter is about to search for the player (case 2).
   // public StoppChase chase;
    //public SpawnSwitch spawnSwitch;
    public float movementS;
    private AudioManager audioManager;
	private EnemyMode currentMode;
	private bool isPlayerSafe; //Scripts can access this variable with the property variable IsPlayerSafe.
    private int csp = 0;

	private Animator myAnimator;


	public float relaxedTime; // These floats are the times every case is active.
	public float turningTime;
	public float searchTime;

	private EnemyMode nextMode;

    public bool debugLog;

	void Start () {
		currentMode = EnemyMode.Relaxed;
        audioManager = gamePlayRef._AudioManager;

        myAnimator = GetComponent<Animator>();
        myAnimator.Play("TreemanIdle");


	}
	
	
	void Update () {

        //Debug.Log(csp);
      
        /*
       if (spawnSwitch.respawn)
         {
             GetComponent<Transform>().position = spawnSwitch.spawn[csp].transform.position;
             csp++;
             spawnSwitch.respawn = false;
         }
         else if (chase.sChase)
         {
             GetComponent<Transform>().position = spawnSwitch.spawn[csp].transform.position;
             chase.sChase = false;
         }

        */

    }


    public void Action()
	{

        myAnimator.SetBool("Idle", false);
        myAnimator.SetBool("Turning", false);
        myAnimator.SetBool("Searching", false);
        myAnimator.SetBool("Chasing", false);

        switch (nextMode)
		{
		case EnemyMode.Relaxed: //Monstret is not looking for the player. It is safe for the player to move outside of safezones.
			if(debugLog) Debug.Log ("Case 0 - Relaxed");
          
                  
			    currentMode = EnemyMode.Relaxed;
                if(!IsPlayerSafe)audioManager.ForestCreatureAudioStates((int)CurrentMode);

            myAnimator.SetBool("Idle", true);
			nextMode = EnemyMode.Turning;
			Invoke ("Action", relaxedTime);
			break;
		case EnemyMode.Turning: //Friendly Old Man turns off a lantern inorder to warn the player that the monster is soon searching for you.		
         if (debugLog) Debug.Log ("Case 1 - Turning");
			    currentMode = EnemyMode.Turning;
                    

            myAnimator.SetBool("Turning", true);
            nextMode = EnemyMode.Search;
            Invoke ("Action", turningTime);
			break;
		case EnemyMode.Search: //Monster is searching for player, if player is not inside a safezone the monster will see the player.
            if (debugLog) Debug.Log ("Case 2 - Searching");

                if (currentMode == EnemyMode.Search && !IsPlayerSafe)
                {
                    nextMode = EnemyMode.ChasingPlayer;
                    Action();

                }


                currentMode = EnemyMode.Search;
            if(!IsPlayerSafe)audioManager.ForestCreatureAudioStates((int)nextMode);
                myAnimator.SetBool("Searching", true);
            nextMode = EnemyMode.Relaxed;
            Invoke ("Action", searchTime);
			break;
        case EnemyMode.ChasingPlayer:
                if (debugLog) Debug.Log("Case 3 - Chasing");
                if (!IsPlayerSafe) audioManager.ForestCreatureAudioStates((int)nextMode);
                myAnimator.SetBool("Chasing", true);
                GetComponent<Transform>().Translate(Vector3.right * movementS * Time.deltaTime);

                nextMode = EnemyMode.Relaxed;
            break;
        }
	}
		
	public bool IsPlayerSafe {get {return isPlayerSafe;} set {isPlayerSafe = value;}}
    
    public EnemyMode CurrentMode { get { return currentMode; } set { currentMode = value; } } 

}

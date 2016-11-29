using UnityEngine; //This state is for the second cutscene.
using System.Collections;

public class CutSceneTwoState : MonoBehaviour {



    private StateMachine _StateMachine;
    private AudioManager _audioManager;

    private bool debugLog;




    public CutSceneTwoState(StateMachine stateMachine_Ref)
    {
        CheckDebugLogBool(stateMachine_Ref);

        if (debugLog) Debug.Log("Constructing CutSceneTwoState");

        _StateMachine = stateMachine_Ref;

        if (debugLog) Debug.Log("CutSceneTwoState constructed!");

    }
    public void StateUpdate()
    {

    }
    public void LoadAssets()
    {
        if (debugLog) Debug.Log("Loading Assets for CutSceneTwoState...");

        if (debugLog) Debug.Log("CutSceneTwoState Loaded");
    }

    private void CheckDebugLogBool(StateMachine o)
    {
        if (o.DebugLog) debugLog = true;
    }

}





using UnityEngine; // The state for the first cutscene.
using System.Collections;

public class CutSceneOneState : MonoBehaviour {



    private StateMachine _StateMachine;
    private AudioManager _audioManager;

    private bool debugLog;




    public CutSceneOneState(StateMachine stateMachine_Ref)
    {
        CheckDebugLogBool(stateMachine_Ref);

        if (debugLog) Debug.Log("Constructing CutSceneOneState");

        _StateMachine = stateMachine_Ref;

        if (debugLog) Debug.Log("CutSceneOneState constructed!");

    }
    public void StateUpdate()
    {

    }
    public void LoadAssets()
    {
        if (debugLog) Debug.Log("Loading Assets for CutSceneOneState...");

        if (debugLog) Debug.Log("CutSceneOneState Loaded");
    }

    private void CheckDebugLogBool(StateMachine o)
    {
        if (o.DebugLog) debugLog = true;
    }

}





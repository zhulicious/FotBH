using Assets.Code.Interfaces;
using Assets.Code.States;
using UnityEngine;


public class StateMachine : MonoBehaviour {

    private IStateBase activeState;
    public AudioManager _audioManager;
    public GameObject tuva;
    


    public bool debugLog; //If this is true Debug.Logs will be shown in the console.


    void Start()
    {
        activeState = new MainMenuState(this);

    }
    void Update()
    {
        if (activeState != null)
        {
            activeState.StateUpdate();
        }
    }

    public void SwitchState(IStateBase newState)
    {
        activeState = newState;
    }

    public bool DebugLog {get{ return debugLog; } set{debugLog = value;}}
    public IStateBase ActiveState { get { return activeState; } set { activeState = value;}}
    

}

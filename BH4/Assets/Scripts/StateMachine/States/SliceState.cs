using Assets.Code.Interfaces; //This state is for the verticle slice.
using UnityEngine;

namespace Assets.Code.States
{
    public class SliceState : IStateBase
    {
        private StateMachine _StateMachine;
        private AudioManager _audioManager;

        private bool debugLog;




        public SliceState(StateMachine stateMachine_Ref)
        {
            CheckDebugLogBool(stateMachine_Ref);

            if (debugLog) Debug.Log("Constructing SliceState");

            _StateMachine = stateMachine_Ref;

            if (debugLog) Debug.Log("SliceState constructed!");

        }
        public void StateUpdate()
        {

        }
        public void LoadAssets()
        {
            if (debugLog) Debug.Log("Loading Assets for SliceState...");

            if (debugLog) Debug.Log("SliceState Loaded");
        }


        public void CheckDebugLogBool(StateMachine o)
        {
            if (o.DebugLog) debugLog = true;
        }
    }
}


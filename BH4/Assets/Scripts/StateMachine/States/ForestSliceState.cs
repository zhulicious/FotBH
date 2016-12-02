using Assets.Code.Interfaces; //This state is for the verticle slice.
using UnityEngine;

namespace Assets.Code.States
{
    public class ForestSliceState : IStateBase
    {
        private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private AudioKing audioKing;
        private AllAudioUsedInScene aauis;

        private bool debugLog;




        public ForestSliceState(StateMachine stateMachine_Ref)
        {
            CheckDebugLogBool(stateMachine_Ref);

            if (debugLog) Debug.Log("Constructing SliceState");

            aauis = new AllAudioUsedInScene();
            _stateMachine = stateMachine_Ref;
            _audioManager = stateMachine_Ref._audioManager;
           
            _stateMachine.tuva = GameObject.Find("Tuva");

            UnloadAssets();
            LoadAssets();

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
        public void UnloadAssets()
        {
            if (debugLog) Debug.Log("Unloading not needed Assets");
            audioKing._mus.allInOne = null;
            if (debugLog) Debug.Log("Assets unloaded.");

        }


        public void CheckDebugLogBool(StateMachine o)
        {
            if (o.DebugLog) debugLog = true;
        }
    }
}


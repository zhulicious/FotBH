using Assets.Code.Interfaces; //This state is for the verticle slice.
using UnityEngine;

namespace Assets.Code.States
{
    public class SliceState : IStateBase
    {
        private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private AudioKing audioKing;

        private bool debugLog;




        public SliceState(StateMachine stateMachine_Ref)
        {
            CheckDebugLogBool(stateMachine_Ref);

            if (debugLog) Debug.Log("Constructing SliceState");

            _stateMachine = stateMachine_Ref;
            _audioManager = stateMachine_Ref._audioManager;
            audioKing = _audioManager.AudioKing;
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
            audioKing._foley.tuva_CaveSteps = Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Cave");
            audioKing._foley.tuva_CaveSteps = Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Puddles");
            //audioKing._foley.playerAudioReference = _stateMachine.player.GetComponent<AudioSource>();
             //audioKing._foley.nPCAudioReference =

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


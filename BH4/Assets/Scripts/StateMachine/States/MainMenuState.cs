using Assets.Code.Interfaces;
using UnityEngine;

namespace Assets.Code.States
{
    public class MainMenuState : IStateBase
	{
		private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private AudioClip theme;

        public bool debugLog;

		public MainMenuState (StateMachine stateMachine_Ref)
		{
            CheckDebugLogBool(stateMachine_Ref);
            if(debugLog) Debug.Log("Constructing BeginState");

            LoadAssets();


          if(debugLog) Debug.Log("MainMenuStateConstructed");
		}
		public void StateUpdate()
		{
			

		}
        public void LoadAssets()
        {
            if (debugLog) Debug.Log("Loading Assets for MainMenu"); 

                theme = Resources.Load<AudioClip>("Audio/Theme");

            if (debugLog) Debug.Log("MainMenu Assets Loaded!");    
        }

        public void CheckDebugLogBool(StateMachine o)
        {
            if (o.DebugLog) debugLog = true;
        }

    }
}


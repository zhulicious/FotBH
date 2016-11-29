using Assets.Code.Interfaces;
using UnityEngine;

namespace Assets.Code.States
{
    public class MainMenuState : IStateBase
	{
		private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private AudioKing audioKingReference;
        private AudioClip theme;

        public bool debugLog;

		public MainMenuState (StateMachine stateMachine_Ref)
		{
            CheckDebugLogBool(stateMachine_Ref);
            if(debugLog) Debug.Log("Constructing BeginState");
            _audioManager = _stateMachine._audioManager;
            audioKingReference = _audioManager.AudioKing;
            LoadAssets();
            


          if(debugLog) Debug.Log("MainMenuStateConstructed");
		}
		public void StateUpdate()
		{
			

		}
        public void LoadAssets()
        {

            if (debugLog) Debug.Log("Loading Assets for MainMenu"); 

                 audioKingReference._mus.allInOne.clip = Resources.Load<AudioClip>("Audio/Theme");
                 audioKingReference._fx.clicked = Resources.Load<AudioClip>("Audio/SoundFX/MenuSounds/Audio_ClickBtn");
                 audioKingReference._fx.back_esc = Resources.Load<AudioClip>("Audio/SoundFX/MenuSounds/Audio_BackEscBtn");
                 audioKingReference._fx.hoverOver = Resources.Load<AudioClip>("Audio/SoundFX/MenuSounds/Audio_MouseOverBtn");


            if (debugLog) Debug.Log("MainMenu Assets Loaded!");    
        }
        public void UnloadAssets()
        {

        }

        public void CheckDebugLogBool(StateMachine o)
        {
            if (o.DebugLog) debugLog = true;
        }
        

    }
}


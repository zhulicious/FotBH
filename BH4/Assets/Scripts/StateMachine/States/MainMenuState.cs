using Assets.Code.Interfaces;
using UnityEngine;

namespace Assets.Code.States
{
    public class MainMenuState : IStateBase
	{
		private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private AllAudioUsedInScene aauis;
        private AudioKing audioKingReference;
        private AudioClip theme;

        public bool debugLog;

		public MainMenuState (StateMachine stateMachine_Ref)
		{
            CheckDebugLogBool(stateMachine_Ref);
            if(debugLog) Debug.Log("Constructing BeginState");
            _audioManager = _stateMachine._audioManager;
            aauis = new AllAudioUsedInScene();
            LoadAssets();
            _audioManager.PlayOrStopTheme(true);


          if(debugLog) Debug.Log("MainMenuStateConstructed");
		}
		public void StateUpdate()
		{
			

		}
        public void LoadAssets()
        {

            if (debugLog) Debug.Log("Loading Assets for MainMenu");

            aauis.mainMenyPackage.mus.Add("theme", Resources.Load<AudioClip>("Audio/Theme"));
            aauis.mainMenyPackage.fx.Add("buttonSounds", Resources.LoadAll<AudioClip>("Audio/SoundFX/MenuSounds"));
            _audioManager.AAUIS = aauis;
            _audioManager.AllAudioSources["fullTrackSpeaker"].clip = aauis.mainMenyPackage.mus["theme"];     
            


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


using Assets.Code.Interfaces; //This state is for the first Cut scene.
using UnityEngine;

namespace Assets.Code.States
{
	public class AntiSliceState : IStateBase 
	{
		private StateMachine _StateMachine;
		private AudioManager _audioManager;

		private bool debugLog;


		

		public AntiSliceState (StateMachine stateMachine_Ref)
		{
			CheckDebugLogBool(stateMachine_Ref);
			
			  if(debugLog) Debug.Log("Constructing AntiSliceState");

			_StateMachine = stateMachine_Ref;

			if (debugLog) Debug.Log("AntiSliceState constructed!");
		
		}
		public void StateUpdate()
		{
			
		}
		public void LoadAssets()
		{
			if (debugLog) Debug.Log("Loading Assets for AntiSliceState...");

			if (debugLog) Debug.Log("AntiSliceState Loaded");
		}

		public void CheckDebugLogBool(StateMachine o)
		{
			if (o.DebugLog) debugLog = true;
		}

	}
}


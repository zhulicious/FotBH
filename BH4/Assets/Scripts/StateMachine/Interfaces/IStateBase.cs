namespace Assets.Code.Interfaces
{
    public interface IStateBase 
	{
		void StateUpdate();
        void LoadAssets();
        void UnloadAssets();
        void CheckDebugLogBool(StateMachine o);
	}
}
namespace Assets.Code.Interfaces
{
    public interface IStateBase 
	{
		void StateUpdate();
        void LoadAssets();
        void CheckDebugLogBool(StateMachine o);
	}
}
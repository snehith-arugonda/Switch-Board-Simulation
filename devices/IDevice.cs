namespace switchBoardSimulation
{
    public interface IDevice
    {
        DeviceType Type
        {
            get;
        }
        int Id
        {
            get;
        }
        bool State
        {
            get;set;
        }
        void ChangeState(){}
        void RepairSwitch(){}
        void RewireSwitch(){}
    }
}
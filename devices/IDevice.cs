namespace switchBoardSimulation
{
    public interface IDevice
    {
        string Type
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
    }
}
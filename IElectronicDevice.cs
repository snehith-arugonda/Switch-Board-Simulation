namespace switchBoardSimulation
{
    public interface IElectronicDevice
    {
        string Type
        {
            get;
        }
        int Id
        {
            get;
        }
        int GlobalId
        {
            get;
        }
        string State
        {
            get;set;
        }
    }
}
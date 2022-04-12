namespace switchBoardSimulation
{
    public class Fan:ElectronicDevice, IElectronicDevice
    {
        private string _state = "OFF";
        private string _type = "Fan";
        private static int _serialNumber = 0;
        private int _id = ++_serialNumber;
        private int _globalId = ++ElectronicDevice.globalSerialNumber;
        public string Type
        {
            get
            {
                return _type;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public int GlobalId
        {
            get
            {
                return _globalId;
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
    }
}
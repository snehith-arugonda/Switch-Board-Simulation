namespace switchBoardSimulation
{
    public class AC:IDevice
{
        private bool _state = false;
        private string _type = Devices.AC.ToString();
        private static int _serialNumber = 0;
        private int _id = ++_serialNumber;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
        }

        public bool State
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
        public override string ToString()
        {
            return $"{this.Type} {this.Id} is \"{(this.State == true?"ON":"OFF")}\"";
        }
    }
}
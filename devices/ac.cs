namespace switchBoardSimulation
{
    public class AC:IDevice
{
        private bool _state = false;
        private DeviceType _type = DeviceType.AC;
        private static int _serialNumber = 0;
        private int _id = ++_serialNumber;
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public DeviceType Type
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
        public void ChangeState()
        {
            this.State = !this.State;
            Console.WriteLine($"\n \n {this.Type} {this.Id} state is toggled \n \n");
        }
        public void RewireSwitch()
        {
            Console.WriteLine($"\n \n {this.Type} {this.Id} Switch is rewired \n \n");
        }
        public void RepairSwitch()
        {
            Console.WriteLine($"\n \n {this.Type} {this.Id} Switch is repaired \n \n");
        }
        public override string ToString()
        {
            return $"{this.Type} {this.Id} is \"{(this.State == true?"ON":"OFF")}\"";
        }
    }
}
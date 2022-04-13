namespace switchBoardSimulation
{
    public class CreateDevices
    {
        private List<IDevice> ListOfDevices;
        private int _numberOfFans;
        private int _numberOfBulbs;
        private int _numberOfACs;
        public int NumberOfFans
        {
            get
            {
                return _numberOfFans;
            }
            set
            {
                _numberOfFans = value;
            }
        }
        public int NumberOfACs
        {
            get
            {
                return _numberOfACs;
            }
            set
            {
                _numberOfACs = value;
            }
        }
        public int NumberOfBulbs
        {
            get
            {
                return _numberOfBulbs;
            }
            set
            {
                _numberOfBulbs = value;
            }
        }
        public CreateDevices()
        {
            ListOfDevices = new List<IDevice>();
        }
        public void CreateDevice()
        {
            CreateFan();
            CreateAC();
            CreateBulb();
        }
        private void CreateFan()
        {
            int i = 1;
            while (i <= NumberOfFans)
            {
                ListOfDevices.Add(new Fan());
                i++;
            }
        }
        private void CreateAC()
        {
            int i = 1;
            while (i <= NumberOfACs)
            {
                ListOfDevices.Add(new AC());
                i++;
            }
        }
        private void CreateBulb()
        {
            int i = 1;
            while (i <= NumberOfBulbs)
            {
                ListOfDevices.Add(new Bulb());
                i++;
            }
        }

        public void ShowDevices()
        {
            for(int i = 0;i < ListOfDevices.Count;i++)
            {
                Console.WriteLine($"{i+1}. {ListOfDevices[i].ToString()}");
            }
        }

        public void ChangeStateOfDevice(int id)
        {
            Console.WriteLine("Select one of the options");
            Console.WriteLine($"1. {ListOfDevices[id - 1].Type} {ListOfDevices[id - 1].Id} {(ListOfDevices[id-1].State == false?"ON":"OFF")}");
            Console.WriteLine("2. back");
            int target;
            try
            {
                if(!int.TryParse(Console.ReadLine(), out target) || target >= 3)
                {
                    throw new FormatException();
                }
                if (target == 1)
                {
                    ListOfDevices[id - 1].State = !ListOfDevices[id-1].State; 
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
            }
        }

        public int GetMaxId()
        {
            return ListOfDevices.Count;
        }
    }
    public enum Devices
    {
        Fan,
        AC,
        Bulb
    }
}
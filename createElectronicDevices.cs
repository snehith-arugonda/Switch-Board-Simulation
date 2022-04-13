namespace switchBoardSimulation
{
    public class createElectronicDevices
    {
        public List<IElectronicDevice> ListOfDevices;
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
        public createElectronicDevices()
        {
            ListOfDevices = new List<IElectronicDevice>();
        }
        public void createDevices()
        {
            createFan();
            createAC();
            createBulb();
        }
        private void createFan()
        {
            int i = 1;
            while (i <= NumberOfFans)
            {
                ListOfDevices.Add(new Fan());
                i++;
            }
        }
        private void createAC()
        {
            int i = 1;
            while (i <= NumberOfACs)
            {
                ListOfDevices.Add(new AC());
                i++;
            }
        }
        private void createBulb()
        {
            int i = 1;
            while (i <= NumberOfBulbs)
            {
                ListOfDevices.Add(new Bulb());
                i++;
            }
        }

        public void showDevices()
        {
            foreach (var device in this.ListOfDevices)
            {
                Console.WriteLine($"{device.GlobalId}. {device.Type} {device.Id} is \"{device.State}\"");
            }
        }

        public void changeStateOfDevice(int id)
        {
            Console.WriteLine("Select one of the options");
            string deviceState = ListOfDevices[id - 1].State == "OFF"?"ON":"OFF";
            Console.WriteLine($"1. {ListOfDevices[id - 1].Type} {ListOfDevices[id - 1].Id} {deviceState}");
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
                    if (ListOfDevices[id - 1].State == "OFF")
                    {
                        ListOfDevices[id - 1].State = "ON";
                    }
                    else
                    {
                        ListOfDevices[id - 1].State = "OFF";
                    }
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
            }
        }

        public int getMaxId()
        {
            return ListOfDevices.Count;
        }
    }
}
namespace switchBoardSimulation
{
    public class SwitchBoard
    {
        private string _name = "Switch Board";
        private List<IDevice> ListOfDevices;
        private int _numberOfFans;
        private int _numberOfBulbs;
        private int _numberOfACs;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
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
        public SwitchBoard()
        {
            ListOfDevices = new List<IDevice>();
        }
        public void CreateDevices()
        {
            Fan.MakeZero();
            AC.MakeZero();
            Bulb.MakeZero();
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
            Console.WriteLine($"{0}. exit current switch board");
            for(int i = 0;i < ListOfDevices.Count;i++)
            {
                Console.WriteLine($"{i+1}. {ListOfDevices[i].ToString()}");
            }
        }
        public void RunSwitchBoardSimulation()
        {
            bool runSimulation = true;
            while (runSimulation)
            {
                this.ShowDevices();
                Console.WriteLine("\nSelect the Id of the device which you want to operate on or exit the switchboard");
                int target;
                if (!int.TryParse(Console.ReadLine(), out target) || target > this.GetMaxId())
                {
                    try
                    {
                        throw new FormatException();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
                    }
                }
                else
                {
                    if(target == 0)
                    {
                        return;
                    }
                    this.OperationsOnDevice(target);
                }
            }
        }

        public void OperationsOnDevice(int id)
        {
            Console.WriteLine("\nSelect one of the options");
            int num = 1;
            foreach(var operation in Enum.GetValues(typeof(Operation)))
            {
                Console.WriteLine($"{num++}. {operation}");
            }
            try
            {
                int target;
                if(!int.TryParse(Console.ReadLine(), out target) || target > num || target < 0)
                {
                    throw new FormatException();
                }
                else
                {
                    switch (target)
                    {
                        case 1:ListOfDevices[id - 1].ChangeState();
                        break;
                        case 2:ListOfDevices[id - 1].RewireSwitch();
                        break;
                        case 3:ListOfDevices[id - 1].RepairSwitch();
                        break;
                        case 4:return;
                        default:return;
                    }
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
}
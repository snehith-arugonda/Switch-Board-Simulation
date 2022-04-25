namespace switchBoardSimulation
{
    public sealed class Simulator
    {
        private static Simulator _instance = new Simulator();
        private List<KeyValuePair<string, SwitchBoard>> SwitchBoardSimulator;

        public static Simulator GetSimulator
        {
            get
            {
                return _instance;
            }
        }

        private Simulator()
        {
            SwitchBoardSimulator = new List<KeyValuePair<string, SwitchBoard>>();
            while (true)
            {
                StartSimulator();
            }
        }
        private void StartSimulator()
        {
            if (SwitchBoardSimulator.Count > 0)
            {
                Console.WriteLine("\n \n List of Switch Boards \n");
                Console.WriteLine($"{0}. new Switch Board");
                int i = 1;
                foreach (KeyValuePair<string, SwitchBoard> switchBoard in SwitchBoardSimulator)
                {
                    Console.WriteLine($"{i++}. {switchBoard.Key}");
                }
                Console.WriteLine(" \n Select one of the Switch Boards or New Switch Board to add SWitch Board ");
                int switchBoardNumber;
                if (!int.TryParse(Console.ReadLine(), out switchBoardNumber) || switchBoardNumber > SwitchBoardSimulator.Count)
                {
                    try
                    {
                        throw new FormatException();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n\nInvalid Input \n" + e.Message);
                    }
                }
                else
                {
                    if (switchBoardNumber == 0)
                    {
                        NewSwitchBoard();
                    }
                    else
                    {
                        SwitchBoard selectedSwitchBoard = SwitchBoardSimulator[switchBoardNumber - 1].Value;
                        selectedSwitchBoard.RunSwitchBoardSimulation();
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\nNo Switch Boards in Simulator");
                Console.WriteLine("To Add Switch Boards add the switchboard here");
                Console.WriteLine("\nAvailable devices are");
                foreach (var device in Enum.GetValues(typeof(DeviceType)))
                {
                    Console.WriteLine(device);
                }
                NewSwitchBoard();
            }
        }
        private void NewSwitchBoard()
        {
            try
            {
                Console.WriteLine("Give the name of Switch Board");
                string switchboardName = Console.ReadLine()!;
                Console.WriteLine("Give Number Of fans:");
                int nFans;
                if (!int.TryParse(Console.ReadLine(), out nFans))
                {
                    throw new FormatException();
                }

                Console.WriteLine("Give Number Of Acs:");
                int nACs;
                if (!int.TryParse(Console.ReadLine(), out nACs))
                {
                    throw new FormatException();
                }

                Console.WriteLine("Give Number Of fans:");
                int nBulbs;
                if (!int.TryParse(Console.ReadLine(), out nBulbs))
                {
                    throw new FormatException();
                }
                SwitchBoard switchboard = new SwitchBoard
                {
                    Name = switchboardName,
                    NumberOfACs = nACs,
                    NumberOfBulbs = nBulbs,
                    NumberOfFans = nFans
                };

                this.SwitchBoardSimulator.Add(new KeyValuePair<string, SwitchBoard>(switchboardName, switchboard));
                switchboard.CreateDevices();
                switchboard.RunSwitchBoardSimulation();
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
            }
        }
    }
}
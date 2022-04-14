namespace switchBoardSimulation
{
    public sealed class Simulator
    {
        private static Simulator _instance = new Simulator();
        private List<SwitchBoard> ListOfSwitchBoards;

        public static Simulator GetSimulator
        {
            get 
            {
                return _instance;
            }
        }

        private Simulator()
        {
            ListOfSwitchBoards = new List<SwitchBoard>();
            StartSimulator();
        }
        private void StartSimulator()
        {
            if (ListOfSwitchBoards.Count > 0)
            {
                Console.WriteLine("\n \n List of Switch Boards \n");
                Console.WriteLine($"{0}. new Switch Board");
                for (int i = 0; i < ListOfSwitchBoards.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ListOfSwitchBoards[i].Name}");
                }
                Console.WriteLine(" \n Select one of the Switch Boards or New Switch Board to add SWitch Board ");
                int switchBoardNumber;
                if(!int.TryParse(Console.ReadLine(), out switchBoardNumber) || switchBoardNumber > ListOfSwitchBoards.Count)
                {
                    try
                    {
                        throw new FormatException();
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("\n\nInvalid Input \n" + e.Message);
                    }
                }
                else
                {
                    if(switchBoardNumber == 0)
                    {
                        NewSwitchBoard();
                    }
                    SwitchBoard selectedSwitchBoard = ListOfSwitchBoards[switchBoardNumber-1];
                    selectedSwitchBoard.RunSwitchBoardSimulation();
                }
            }
            else
            {
                Console.WriteLine("\n\nNo Switch Boards to display");
                Console.WriteLine("To Add Switch Boards add the switchboard here");
                Console.WriteLine("\nAvailable switchboard are");
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
                    Name = "Switch Board" + (ListOfSwitchBoards.Count + 1).ToString(),
                    NumberOfACs = nACs,
                    NumberOfBulbs = nBulbs,
                    NumberOfFans = nFans
                };

                this.ListOfSwitchBoards.Add(switchboard);
                switchboard.RunSwitchBoardSimulation();
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
            }
        }
    }
}
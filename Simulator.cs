namespace switchBoardSimulation
{
    public static class Simulator
    {
        public static void RunSimulator(in int nFans, in int nACs, in int nBulbs)
        {
            bool runSimulation = true;
            CreateDevices devices = new CreateDevices
            {
                NumberOfACs = nACs,
                NumberOfBulbs = nBulbs,
                NumberOfFans = nFans
            };

            devices.CreateDevice();
            while (runSimulation)
            {
                devices.ShowDevices();
                Console.WriteLine("Select the Id of the device which you eant to change the state of");
                int target;
                if (!int.TryParse(Console.ReadLine(), out target) || target > devices.GetMaxId())
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
                    devices.ChangeStateOfDevice(target);
                }
            }
        }
    }
}
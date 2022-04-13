namespace switchBoardSimulation
{
    public class simulation
    {
        public static void Main(string[] args)
        {
            bool runSimulation = true;
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

                createElectronicDevices devices = new createElectronicDevices
                {
                    NumberOfACs = nACs,
                    NumberOfBulbs = nBulbs,
                    NumberOfFans = nFans
                };

                devices.createDevices();
                while (runSimulation)
                {
                    devices.showDevices();
                    Console.WriteLine("Select the Id of the device which you eant to change the state of");
                    int target;
                    if(!int.TryParse(Console.ReadLine(), out target) || target > devices.getMaxId())
                    {
                        try
                        {
                            throw new FormatException();
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
                        }
                    }
                    else
                    {
                        devices.changeStateOfDevice(target);
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
                runSimulation = false;
            }
        }
    }
}

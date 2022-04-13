namespace switchBoardSimulation
{
    public class Simulation
    {
        public static void Main(string[] args)
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
                Simulator.RunSimulator(nFans, nACs, nBulbs);
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n \n Invalid Input, Try again \n" + e.Message + "\n \n");
            }
        }
    }
}
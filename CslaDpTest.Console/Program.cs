using System;
using System.Threading.Tasks;

namespace CslaDpTest.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var carList = CarList.Get(new[] { "Ford" });
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            try
            {
                var truckList = TruckList.Get("Ford");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            try
            {
                var veh = await VehicleCommand.GetCommand("vehicle");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.ReadLine();
        }
    }
}

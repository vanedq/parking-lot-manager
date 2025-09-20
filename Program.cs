using ParkingLot.Models.Manager;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager system = new Manager();
            Models.PK.ParkingLot establishmentUser = new Models.PK.ParkingLot();

            system.Welcome();
            system.SetUpPrices(establishmentUser);

            string userOption;
            do
            {
                system.ShowMenu();
                userOption = Console.ReadLine()??"";
                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("License Plate: ");
                        establishmentUser.AddVehicle(Console.ReadLine()??"");
                        system.WaitForResponse();
                        break;
                    case "2":
                        Console.WriteLine("License Plate: ");
                        establishmentUser.RemoveVehicle(Console.ReadLine()??"");
                        system.WaitForResponse();
                        break;
                    case "3":
                        establishmentUser.ListVehicles();
                        system.WaitForResponse();
                        break;
                    case "4":
                        system.SetUpPrices(establishmentUser);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Choose a valid option.");
                        break;
                }
            } while (userOption != "5");
        }
    }
}
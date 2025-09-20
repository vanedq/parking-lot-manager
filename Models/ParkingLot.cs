namespace ParkingLot.Models.PK;

public class ParkingLot
{
    public decimal initialPrice { get; set; }
    public decimal additionalPricePerHour { get; set; }
    private List<string> vehicle = new List<string>();

    public ParkingLot(){} //empty constructor so the instance can be created with no parameters

    public void AddVehicle(string licensePlate)
    {
        if (string.IsNullOrWhiteSpace(licensePlate))
            Console.WriteLine("[FAILURE] No vehicle entry was registered because no valid value was informed.");
        else if (vehicle.Contains(licensePlate))
            Console.WriteLine("[FAILURE] This license plate is already registered.");
        else
        {
            this.vehicle.Add(licensePlate);
            Console.WriteLine("[SUCCESS] Entry registered successfully.");
        }
    }
    public void RemoveVehicle(string licensePlate)
    {
        if (string.IsNullOrWhiteSpace(licensePlate))
            Console.WriteLine("[FAILURE] No vehicle exit was registered because no valid value was informed.");
        else if (vehicle.Contains(licensePlate))
        {
            int hoursParked;
            decimal finalPrice;

            do
            {
                Console.WriteLine("\nFor how many hours did the vehicle stay parked?");
                if (int.TryParse(Console.ReadLine(), out hoursParked))
                {
                    finalPrice = initialPrice + (hoursParked * additionalPricePerHour);
                    break;
                }
                else
                    Console.WriteLine("\n[FAILURE] Invalid answer. Use only integers, for example:" +
                    "\n- Less than 1h: 0 (no additional price charged)" +
                    "\n- More than 1h, up to 2h: 1" +
                    "\n- More than 2h, up to 3h: 2");
            } while (true);

            this.vehicle.Remove(licensePlate);
            Console.WriteLine($"[SUCCESS] Exit registered successfuly. The client must pay {finalPrice}.");
        }
        else
            Console.WriteLine("[FAILURE] There's no vehicle parked under that license plate." +
            "\nYou can check all the license plates registered in option 3 of menu.");
    }
    public void ListVehicles()
    {
        if (!vehicle.Any())
            Console.WriteLine("\nNo vehicles parked.");
        else
        {
            int counter = 0;
            Console.WriteLine("\nVehicles inside the parking lot:");
            foreach (string i in this.vehicle)
            {
                Console.WriteLine($"{counter + 1} - {this.vehicle[counter]}");
                counter++;
            }   
        }
    }
}
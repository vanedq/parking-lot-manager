namespace ParkingLot.Models.Manager;

class Manager
{
    public void Welcome()
    {
        Console.WriteLine("\nWelcome to the Parking Lot System Manager.");
    }

    public void SetUpPrices(PK.ParkingLot establishmentUser)
    {
        decimal initialPrice;
        decimal priceByHour;
        string input;

        Console.WriteLine("\nTo answer the following two informations, use your local currency separating sign (dot/comma)." +
        "\nIf you use the wrong pattern, it will be ignored." +
        "\nYou can always redefine the price through option 4 of menu.");

        do
        {
            Console.WriteLine("\nEnter the starting price for parking:");
            input = Console.ReadLine()!;
            if (decimal.TryParse(input, out initialPrice))
            {
                establishmentUser.initialPrice = initialPrice;
                Console.WriteLine($"[SUCCESS] The starting price was set up to {establishmentUser.initialPrice}.");
            }
            else
                Console.WriteLine("[FAILURE] Invalid format.");
        } while (initialPrice == 0);
        do
        {
            Console.WriteLine("\nEnter the price for every additional hour:");
            input = Console.ReadLine()!;
            if (decimal.TryParse(input, out priceByHour))
            {
                establishmentUser.additionalPricePerHour = priceByHour;
                Console.WriteLine($"[SUCCESS] The price by hour was set up to {establishmentUser.additionalPricePerHour}.");
            }
            else
                Console.WriteLine("[FAILURE] Invalid format.");
        } while (priceByHour == 0);


    }
    public void ShowMenu()
    {
        Console.WriteLine(
        @"
+===================================================+
|                       MENU                        |
|            What would you like to do?             |
+===================================================+
| 1 | Register vehicle entry                        |
+===================================================+
| 2 | Register vehicle exit                         |
+===================================================+
| 3 | Visualize all vehicles inside the parking lot |
+===================================================+
| 4 | Change the prices                             |
+===================================================+
| 5 | Exit program                                  |
+===================================================+
");
    }

    public void WaitForResponse()
    {
        Console.WriteLine("> Press any key to go back to menu.");
        Console.ReadKey(true);
    }
}
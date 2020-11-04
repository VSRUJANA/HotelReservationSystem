using System;

namespace Hotel_Reservation_System
{
    class Program
    {
        // Driver Code
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System!");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            string type = "";

            // Validate Customer Type
            try
            {
                Console.WriteLine("Enter customer type");
                type = Console.ReadLine().ToUpper();
                if (type != "REGULAR" && type != "REWARD")
                    throw new CustomExceptions(CustomExceptions.ExceptionType.INVALID_CUSTOMER_TYPE, "Entered Customer type is invalid!");

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message + " Try again!");
                Console.ResetColor();
                System.Environment.Exit(0);
            }

            CustomerType customerType = (type == "REGULAR") ? CustomerType.REGULAR : CustomerType.REWARD;
            ManageHotels hotelManager = new ManageHotels(customerType);

            // Add hotels to Reservation system
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            // Enter Check in and Check out dates
            Console.Write("\x1b[1mEnter Check in date in ddMonyyyy format  : \x1b[0m");
            DateTime checkInDate = hotelManager.ValidateDate(Console.ReadLine());
            Console.WriteLine();
            Console.Write("\x1b[1mEnter Check out date in ddMonyyyy format : \x1b[0m");
            DateTime checkOutDate = hotelManager.ValidateDate(Console.ReadLine());

            // Find cheapest Hotel for a given Date Range
            var cheapestBestRatedHotel = hotelManager.FindCheapestBestRatedHotel(checkInDate, checkOutDate);
            Console.WriteLine("\nCheapest Best rated Hotel available for the given date range :");
            hotelManager.DisplayHotel(cheapestBestRatedHotel);
        }
    }
}

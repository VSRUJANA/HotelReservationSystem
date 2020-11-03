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
            ManageHotels hotelManager = new ManageHotels();

            // Add hotels to Reservation system
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));

            // Display available hotels in Reservation system
            hotelManager.Display();

            /*
             // Enter Check in and Check out dates
             Console.Write("\x1b[1mEnter Check in date in ddMonyyyy format  : \x1b[0m");
             DateTime checkInDate = hotelManager.ValidateDate(Console.ReadLine());
             Console.WriteLine();
             Console.Write("\x1b[1mEnter Check out date in ddMonyyyy format : \x1b[0m");
             DateTime checkOutDate = hotelManager.ValidateDate(Console.ReadLine());

             // Find cheapest Hotel for a given Date Range
             var cheapestBestRatedHotel = hotelManager.FindCheapestBestRatedHotel(checkInDate, checkOutDate);
             Console.WriteLine("\nCheapest Best rated Hotel available for the given date range :");
             hotelManager.DisplayCheapestHotel(cheapestBestRatedHotel);
            */
        }
    }
}


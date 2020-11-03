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
            hotelManager.AddHotel(new Hotel("Lakewood", 110));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220));

            // Display available hotels
            hotelManager.Display();
        }
    }
}


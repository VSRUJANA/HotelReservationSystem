using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel_Reservation_System

{
    /// <summary>
    /// HotelReservation class contains methods for reserving hotel room
    /// </summary>
    public class ManageHotels
    {
        // hotels contains the list of hotels 
        public List<Hotel> hotels = new List<Hotel>();

        // Method to add new hotel 
        public void AddHotel(Hotel newHotel)
        {
            // Skipping duplicate entries
            foreach (var hotel in hotels)
            {
                if (hotel.name == newHotel.name)
                    return;
            }
            hotels.Add(newHotel);
        }

        // Method to display available hotels 
        public void Display()
        {
            Console.WriteLine("Hotels in Miami:");
            Console.WriteLine("HotelName" + "\t" + "RegularRate");
            foreach (var hotel in hotels)
            {
                Console.WriteLine(hotel.name + "\t$ " + hotel.regularRate);
            }
        }
    }
}

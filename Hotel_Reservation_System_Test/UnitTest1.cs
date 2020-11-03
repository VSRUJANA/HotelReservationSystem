using Hotel_Reservation_System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Reservation_System_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenDetailsOf3Hotels_WhenAddedToHotelList_ReturnSizeOfListAs3()
        {
            ManageHotels hotelManager = new ManageHotels();
            int expected = 3;

            hotelManager.AddHotel(new Hotel("Lakewood", 110));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220));
            int actual = hotelManager.hotels.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenInvalidDateRange_IsDateRangeValid_ShouldReturnFalse()
        {
            DateTime start = DateTime.Parse("17Nov2020");
            DateTime end = DateTime.Parse("12Nov2020");
            bool expected = false; 

            ManageHotels hotelManager = new ManageHotels();
            bool result = hotelManager.IsDateRangeValid(start, end);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenDateRange_FindCheapestHotelInAGivenDateRangeMethod_ShouldReturnCheapestHotel()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Lakewood";

            ManageHotels hotelManager = new ManageHotels();
            hotelManager.AddHotel(new Hotel("Lakewood", 110));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220));
            List<Hotel> cheapestHotels = hotelManager.FindCheapestHotelInAGivenDateRange(start, end);

            Assert.AreEqual(expected, cheapestHotels[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindCheapestHotelInAGivenDateRangeMethod_ShouldReturnAllAvailableCheapestHotels()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string[] expected = { "Lakewood", "Ridgewood" };

            ManageHotels hotelManager = new ManageHotels();
            hotelManager.AddHotel(new Hotel("Lakewood", 110));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestHotelInAGivenDateRange(start, end);
            string[] cheapestHotelsArray = cheapestHotelsList.Select(hotel => hotel.name).ToArray();

            CollectionAssert.AreEqual(expected, cheapestHotelsArray);
        }
    }
}


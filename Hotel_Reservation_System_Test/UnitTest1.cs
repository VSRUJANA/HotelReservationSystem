using Hotel_Reservation_System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}


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
            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            int expected = 3;

            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            int actual = hotelManager.hotels.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenInvalidDateRange_IsDateRangeValid_ShouldReturnFalseForRegularcustomer()
        {
            DateTime start = DateTime.Parse("17Nov2020");
            DateTime end = DateTime.Parse("12Nov2020");
            bool expected = false;

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            bool result = hotelManager.IsDateRangeValid(start, end);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenDateRange_FindCheapestHotelInAGivenDateRangeMethod_ShouldReturnCheapestHotelForRegularcustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Lakewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            List<Hotel> cheapestHotels = hotelManager.FindCheapestHotelInAGivenDateRange(start, end);

            Assert.AreEqual(expected, cheapestHotels[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindCheapestHotelInAGivenDateRangeMethod_ShouldReturnAllAvailableCheapestHotelsForRegularcustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string[] expected = { "Lakewood", "Ridgewood" };

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110, 90, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestHotelInAGivenDateRange(start, end);
            string[] cheapestHotelsArray = cheapestHotelsList.Select(hotel => hotel.name).ToArray();

            CollectionAssert.AreEqual(expected, cheapestHotelsArray);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedCheapestHotelMethod_ShouldReturnBestRatedCheapestHotelForRegularcustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Lakewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestBestRatedHotel(start, end);

            Assert.AreEqual(expected, cheapestHotelsList[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedCheapestHotelMethod_ShouldReturnBestRatedFromCheapestHotelsForRegularcustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Ridgewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110, 90, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestBestRatedHotel(start, end);

            Assert.AreEqual(expected, cheapestHotelsList[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedHotelMethod_ShouldReturnBestRatedHotelForRegularcustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Ridgewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindBestRatedHotel(start, end);

            Assert.AreEqual(expected, cheapestHotelsList[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedHotelMethod_ShouldReturnAllBestRatedHotelsForRegularcustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string[] expected = {"Ridgewood" };

            ManageHotels hotelManager = new ManageHotels(CustomerType.REGULAR);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110, 90, 100, 40, 5));
            List<Hotel> bestHotelsList = hotelManager.FindCheapestBestRatedHotel(start, end);
            string[] bestHotelsArray = bestHotelsList.Select(hotel => hotel.name).ToArray();

            CollectionAssert.AreEqual(expected, bestHotelsArray);
        }

        [TestMethod]
        public void GivenInvalidDateRange_IsDateRangeValid_ShouldReturnFalseForRewardCustomer()
        {
            DateTime start = DateTime.Parse("17Nov2020");
            DateTime end = DateTime.Parse("12Nov2020");
            bool expected = false;

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            bool result = hotelManager.IsDateRangeValid(start, end);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenDateRange_FindCheapestHotelInAGivenDateRangeMethod_ShouldReturnCheapestHotelForRewardCustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Lakewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            List<Hotel> cheapestHotels = hotelManager.FindCheapestHotelInAGivenDateRange(start, end);

            Assert.AreEqual(expected, cheapestHotels[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindCheapestHotelInAGivenDateRangeMethod_ShouldReturnAllAvailableCheapestHotelsForRewardCustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string[] expected = { "Lakewood", "Ridgewood" };

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110, 90, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestHotelInAGivenDateRange(start, end);
            string[] cheapestHotelsArray = cheapestHotelsList.Select(hotel => hotel.name).ToArray();

            CollectionAssert.AreEqual(expected, cheapestHotelsArray);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedCheapestHotelMethod_ShouldReturnBestRatedCheapestHotelForRewardCustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Ridgewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestBestRatedHotel(start, end);

            Assert.AreEqual(expected, cheapestHotelsList[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedCheapestHotelMethod_ShouldReturnBestRatedFromCheapestHotelsForRewardCustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Ridgewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110, 90, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindCheapestBestRatedHotel(start, end);

            Assert.AreEqual(expected, cheapestHotelsList[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedHotelMethod_ShouldReturnBestRatedHotelForRewardCustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string expected = "Ridgewood";

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            List<Hotel> cheapestHotelsList = hotelManager.FindBestRatedHotel(start, end);

            Assert.AreEqual(expected, cheapestHotelsList[0].name);
        }

        [TestMethod]
        public void GivenDateRange_FindBestRatedHotelMethod_ShouldReturnAllBestRatedHotelsForRewardCustomer()
        {
            DateTime start = DateTime.Parse("12Nov2020");
            DateTime end = DateTime.Parse("14Nov2020");
            string[] expected = { "Ridgewood" };

            ManageHotels hotelManager = new ManageHotels(CustomerType.REWARD);
            hotelManager.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelManager.AddHotel(new Hotel("Bridgewood", 160, 60, 110, 150, 4));
            hotelManager.AddHotel(new Hotel("Ridgewood", 110, 90, 100, 40, 5));
            List<Hotel> bestHotelsList = hotelManager.FindCheapestBestRatedHotel(start, end);
            string[] bestHotelsArray = bestHotelsList.Select(hotel => hotel.name).ToArray();

            CollectionAssert.AreEqual(expected, bestHotelsArray);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace Hotel_Reservation_System
{
    /// <summary>
    /// HotelReservation class contains methods for reserving hotel room
    /// </summary>
    public class ManageHotels
    {
        // hotels contains the list of hotels 
        public List<Hotel> hotels = new List<Hotel>();
        public CustomerType customerType;
        public static double cheapestRate = 0;

        // Parameterised Constructor
        public ManageHotels(CustomerType customerType)
        {
            this.customerType = customerType;
            hotels = new List<Hotel>();
        }


        // Method to add new hotel 
        public void AddHotel(Hotel newHotel)
        {
            hotels.Add(newHotel);
        }

        // Method to display available hotels 
        public void Display()
        {
            Console.WriteLine("Hotels in Miami:");
            Console.WriteLine("HotelName" + "\t" + "WeekDayRegularRate" + "\t" + "WeekEndRegularRate" + "\t" + "WeekDayRewardRate" + "\t" + "WeekEndRewardRate" + "\t" + "Rating");
            foreach (var hotel in hotels)
            {
                Console.Write(hotel.name + "\t  $ " + hotel.regularWeekDayRate + "\t\t\t $ " + hotel.regularWeekEndRate);
                Console.Write("\t\t\t $ " + hotel.rewardWeekDayRate + "\t\t\t  $ " + hotel.rewardWeekEndRate + "\t\t\t  $ " + hotel.rating + "\n");
            }
        }

        // Method to check whether date is valid
        public DateTime ValidateDate(string date)
        {
            DateTime minDate = DateTime.Today;
            DateTime maxDate = DateTime.Today.AddDays(365);
            try
            {
                DateTime formattedDate = DateTime.Parse(date);
                if (formattedDate == null)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.NULL_DATE, "Date cannot be NULL! ");
                }
                else if (formattedDate < minDate)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.INVALID_DATE_RANGE, "Date entered is too early! ");
                }
                else if (formattedDate > maxDate)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.INVALID_DATE_RANGE, "Booking for requested dates are not opened yet! ");
                }
                return formattedDate;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.Write("Please enter a valid date in ddMonyyyy format: ");
                return ValidateDate(Console.ReadLine());
            }
        }

        // Check if Check out date is greater than Check in date
        public bool IsDateRangeValid(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn > checkOut)
                return false;
            return true;
        }

        // If Check out date is less than Check in date throw INVALID_DATE_RANGE exception
        public DateTime HandleInvalidDateRange(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                if (!IsDateRangeValid(checkIn, checkOut))
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.INVALID_DATE_RANGE, "Check out date must be greater than Check in date! ");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.Write("Please enter a valid Check out date: ");
                checkOut = ValidateDate(Console.ReadLine());
            }
            return checkOut;
        }

        // Get number of week days in the given date range
        public int GetWeekdaysInDateRange(DateTime start, DateTime end)
        {
            int weekDays = 0;
            while (start <= end)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++weekDays;
                }
                start = start.AddDays(1);
            }
            return weekDays;
        }

        // Method to find Cheapest rate based on Regular week day and week end rates
        public double CheapestRegularRate(int weekDays, int weekEndDays)
        {
            if (customerType == CustomerType.REGULAR)
                return hotels.Min(hotel => (weekDays * hotel.regularWeekDayRate) + (weekEndDays * hotel.regularWeekEndRate));
            else
                return hotels.Min(hotel => (weekDays * hotel.rewardWeekDayRate) + (weekEndDays * hotel.rewardWeekEndRate));
        }

        // Method to find Cheapest hotels based on Regular customer rates for given date range
        public List<Hotel> FindCheapestHotelInAGivenDateRange(DateTime start, DateTime end)
        {
            end = HandleInvalidDateRange(start, end);
            TimeSpan timeSpan = end.Subtract(start);
            int numberOfDays = (int)timeSpan.TotalDays + 1;
            int weekDays = GetWeekdaysInDateRange(start, end);
            int weekEndDays = numberOfDays - weekDays;
            cheapestRate = CheapestRegularRate(weekDays, weekEndDays);
            if (customerType == CustomerType.REGULAR)
                return hotels.Where(hotel => (weekDays * hotel.regularWeekDayRate) + (weekEndDays * hotel.regularWeekEndRate) == cheapestRate).ToList();
            else
                return hotels.Where(hotel => (weekDays * hotel.rewardWeekDayRate) + (weekEndDays * hotel.rewardWeekEndRate) == cheapestRate).ToList();
        }

        // Method to find Cheapest Best rated hotels based on Regular customer rates for given date range
        public List<Hotel> FindCheapestBestRatedHotel(DateTime start, DateTime end)
        {
            List<Hotel> cheapestHotels = FindCheapestHotelInAGivenDateRange(start, end);
            int maxRating = cheapestHotels.Max(hotel => hotel.rating);
            return cheapestHotels.FindAll(hotel => hotel.rating == maxRating);
        }

        // Method to find Best rated hotel for given date range
        public List<Hotel> FindBestRatedHotel(DateTime start, DateTime end)
        {
            end = HandleInvalidDateRange(start, end);
            TimeSpan timeSpan = end.Subtract(start);
            int numberOfDays = (int)timeSpan.TotalDays + 1;
            int weekDays = GetWeekdaysInDateRange(start, end);
            int weekEndDays = numberOfDays - weekDays;
            int maxRating = hotels.Max(hotel => hotel.rating);
            var bestRatedHotels = hotels.FindAll(hotel => hotel.rating == maxRating);
            Console.WriteLine("\nBest rated Hotels available for the given date range : ");
            foreach (Hotel hotel in bestRatedHotels)
            {
                double weekDayRate = (customerType == CustomerType.REGULAR) ? hotel.regularWeekDayRate : hotel.regularWeekEndRate;
                double weekEndRate = (customerType == CustomerType.REGULAR) ? hotel.rewardWeekDayRate : hotel.rewardWeekEndRate;
                double totalBill = (weekDays * weekDayRate) + (weekEndDays * weekEndRate);
                Console.WriteLine("Hotel '" + hotel.name + "' and Total Rate  : $ " + totalBill);
            }
            return bestRatedHotels;
        }

        // Method to display available cheapest hotel
        public void DisplayHotel(List<Hotel> Hotels)
        {
            foreach (Hotel hotel in Hotels)
            {
                Console.WriteLine("Hotel '" + hotel.name + "' , Rating : " + hotel.rating + " and Total Rate  : $ " + cheapestRate);
            }
        }
    }
}

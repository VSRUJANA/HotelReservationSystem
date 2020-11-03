using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_System
{
    /// <summary>
    /// Create class for hotel data
    /// </summary>
    public class Hotel
    {
        // Data members of the class
        public String name;
        public int regularWeekDayRate;
        public int regularWeekEndRate;
        public int rewardWeekDayRate;
        public int rewardWeekEndRate;
        public int rating;

        // Parameterised Constructor
        public Hotel(string name, int regularWeekDayRate, int regularWeekEndRate, int rewardWeekDayRate, int rewardWeekEndRate, int rating)
        {
            this.name = name;
            this.regularWeekDayRate = regularWeekDayRate;
            this.regularWeekEndRate = regularWeekEndRate;
            this.rewardWeekDayRate = rewardWeekDayRate;
            this.rewardWeekEndRate = rewardWeekEndRate;
            this.rating = rating;
        }
    }
}
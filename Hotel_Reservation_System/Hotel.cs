﻿using System;
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
        public int weekDayRegularRate;
        public int weekEndRegularRate;
        public int rating;

        // Parameterised Constructor
        public Hotel(string name, int weekDayRegularRate, int weekEndRegularRate, int rating)
        {
            this.name = name;
            this.weekDayRegularRate = weekDayRegularRate;
            this.weekEndRegularRate = weekEndRegularRate;
            this.rating = rating;
        }
    }
}
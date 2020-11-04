using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_System
{
    public class CustomExceptions : Exception
    {
        /// <summary>
        /// Exception types
        /// </summary>
        public enum ExceptionType
        {
            NULL_DATE,
            INVALID_DATE_FORMAT,
            INVALID_DATE_RANGE,
            INVALID_CUSTOMER_TYPE
        }
        public ExceptionType type;
        /// <summary>
        /// Constructor of custom exception inheriting from Exception class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public CustomExceptions(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}


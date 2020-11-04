using Hotel_Reservation_System;
using System;

public enum CustomerType
{
    REGULAR, REWARD
}
public class CustomerTypeValidation
{
    // Validate Customer Type
    public static void ValidateCustomerType(string type)
    {
        try
        {
            if (type != "REGULAR" && type != "REWARD")
                throw new CustomExceptions(CustomExceptions.ExceptionType.INVALID_CUSTOMER_TYPE, "Entered Customer type is invalid!");
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message + " Try again!");
            Console.ResetColor();
            System.Environment.Exit(0);
        }
    }
}

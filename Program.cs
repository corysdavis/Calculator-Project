using System;

public class Calculator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\nSDC220L Project Week 1 === Calculator Application === Cory Davis\n");

        Console.WriteLine("Welcome!\n");
        Console.WriteLine("Instructions for using the calculator:\n");
        Console.WriteLine("---------------------------------\n");
        Console.WriteLine("For integer operations: Enter two whole numbers.");
        Console.WriteLine("The values will be added together and the result will be shown as a whole number.\n");
        Console.WriteLine("For floating-point operations: Enter two decimal numbers (floating point).");
        Console.WriteLine("The first value will be subtracted from the second value and the result will be shown rounded to 2 decimal places.\n");
        Console.WriteLine("---------------------------------\n");

        Console.Write("Enter first whole number (integer): ");
        int intNum1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second whole number (integer): ");
        int intNum2 = Convert.ToInt32(Console.ReadLine());

        double intResult = intNum1 + intNum2;
        Console.WriteLine($"Result: {intResult:F0}\n");

        Console.Write("Enter first floating point number: ");
        double floatNum1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second floating point number: ");
        double floatNum2 = Convert.ToDouble(Console.ReadLine());

        double floatResult = floatNum2 - floatNum1;
        Console.WriteLine($"Result: {floatResult:F2}\n");

        Console.WriteLine("Thank you for using the calculator!");
    }
}

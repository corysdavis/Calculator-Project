using System;

public static class Exceptions
{
    public static void HandleSafeDivision()
    {
        double num1 = 0, num2 = 0;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.Write("Enter the first number: ");
                string? input1 = Console.ReadLine();
                num1 = double.Parse(input1 ?? throw new FormatException("Input cannot be null."));

                Console.Write("Enter the second number: ");
                string? input2 = Console.ReadLine();
                num2 = double.Parse(input2 ?? throw new FormatException("Input cannot be null."));

                if (num2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }

                double result = num1 / num2;
                Console.WriteLine($"Result: {result:F2}");
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero is not allowed. Please try again.");
            }
        }
    }
}

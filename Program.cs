using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n--- SDC220L Project Week 2 --- Calculator Application --- Cory Davis\n");
        DisplayInstructions();

        Calculator calc = new Calculator();
        bool running = true;

        while (running)
        {
            DisplayMenu();
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                int a = GetValidInt("Enter first whole number: ");
                int b = GetValidInt("Enter second whole number: ");
                Console.WriteLine($"Result: {calc.AddIntegers(a, b)}");
            }
            else if (choice == "2")
            {
                double a = GetValidDouble("Enter first decimal number: ");
                double b = GetValidDouble("Enter second decimal number: ");
                Console.WriteLine($"Result: {calc.SubtractDoubles(a, b):F2}");
            }
            else if (choice == "3")
            {
                int a = GetValidInt("Enter first whole number: ");
                int b = GetValidInt("Enter second whole number: ");
                Console.WriteLine($"Result: {calc.MultiplyIntegers(a, b)}");
            }
            else if (choice == "4")
            {
                double a = GetValidDouble("Enter dividend: ");
                double b = GetValidDouble("Enter divisor: ");
                double result = calc.DivideDoubles(a, b);
                if (double.IsNaN(result))
                    Console.WriteLine("Error: Division by zero.");
                else
                    Console.WriteLine($"Result: {result:F2}");
            }
            else if (choice == "5")
            {
                Console.Write("Enter a formula: ");
                string? formula = Console.ReadLine();
                double result = calc.EvaluateFormula(formula ?? "");
                if (!double.IsNaN(result))
                    Console.WriteLine($"Result: {result:F2}");
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.\n");
            }

            Console.WriteLine();
        }
        Console.WriteLine("Thanks for using the calculator!\n");
    }

    static void DisplayInstructions()
    {
        Console.WriteLine("Instructions:");
        Console.WriteLine(" - Select a number from the menu to perform a calculation.");
        Console.WriteLine(" - You can perform basic math operations or evaluate a full expression.");
        Console.WriteLine(" - The program will loop until you choose to quit.\n");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine(" 1 - Add two numbers");
        Console.WriteLine(" 2 - Subtract two numbers");
        Console.WriteLine(" 3 - Multiply two numbers");
        Console.WriteLine(" 4 - Divide two numbers");
        Console.WriteLine(" 5 - Enter a formula to evaluate");
        Console.WriteLine(" 6 - Quit");
    }

    static int GetValidInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
                return number;
            else
                Console.WriteLine("Invalid input. Please enter a whole number.");
        }
    }

    static double GetValidDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double number))
                return number;
            else
                Console.WriteLine("Invalid input. Please enter a decimal number.");
        }
    }
}

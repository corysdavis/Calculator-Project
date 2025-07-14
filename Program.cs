using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n--- SDC220L Project Week 3 --- Calculator Application --- Cory Davis\n");
        DisplayInstructions();

        Calculator calc = new Calculator();
        bool running = true;

        while (running)
        {
            DisplayMainMenu();
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    int a1 = GetValidInt("Enter first whole number: ");
                    int b1 = GetValidInt("Enter second whole number: ");
                    Console.WriteLine($"Result: {calc.AddIntegers(a1, b1)}");
                    break;

                case "2":
                    double a2 = GetValidDouble("Enter first decimal number: ");
                    double b2 = GetValidDouble("Enter second decimal number: ");
                    Console.WriteLine($"Result: {calc.SubtractDoubles(a2, b2):F2}");
                    break;

                case "3":
                    int a3 = GetValidInt("Enter first whole number: ");
                    int b3 = GetValidInt("Enter second whole number: ");
                    Console.WriteLine($"Result: {calc.MultiplyIntegers(a3, b3)}");
                    break;

                case "4":
                    double a4 = GetValidDouble("Enter dividend: ");
                    double b4 = GetValidDouble("Enter divisor: ");
                    double result4 = calc.DivideDoubles(a4, b4);
                    Console.WriteLine(double.IsNaN(result4) ? "Error: Division by zero." : $"Result: {result4:F2}");
                    break;

                case "5":
                    Console.Write("Enter a formula: ");
                    string? formula = Console.ReadLine();
                    double result5 = calc.EvaluateFormula(formula ?? "");
                    if (!double.IsNaN(result5))
                        Console.WriteLine($"Result: {result5:F2}");
                    break;

                case "6":
                    HandleSingleMemory(calc);
                    break;

                case "7":
                    HandleCollectionMemory(calc);
                    break;

                case "8":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Thanks for using the calculator!\n");
    }

    static void DisplayInstructions()
    {
        Console.WriteLine("Instructions:");
        Console.WriteLine(" - Use the menu to select calculator functions or memory operations.");
        Console.WriteLine(" - Memory allows storing one number or up to 10 integers.");
        Console.WriteLine(" - Program runs until you choose to quit.\n");
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine(" 1 - Add two numbers");
        Console.WriteLine(" 2 - Subtract two numbers");
        Console.WriteLine(" 3 - Multiply two numbers");
        Console.WriteLine(" 4 - Divide two numbers");
        Console.WriteLine(" 5 - Evaluate a formula");
        Console.WriteLine(" 6 - Single memory operations");
        Console.WriteLine(" 7 - Integer collection memory");
        Console.WriteLine(" 8 - Quit");
    }

    static void HandleSingleMemory(Calculator calc)
    {
        Console.WriteLine("\n--- Single Memory Menu ---");
        Console.WriteLine(" 1 - Store value");
        Console.WriteLine(" 2 - Retrieve value");
        Console.WriteLine(" 3 - Replace value");
        Console.WriteLine(" 4 - Clear memory");

        Console.Write("Choose an option: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
            case "3":
                double value = GetValidDouble("Enter value to store: ");
                calc.MemoryValue = value;
                Console.WriteLine("Value stored.");
                break;

            case "2":
                Console.WriteLine(calc.MemoryValue.HasValue ? $"Stored value: {calc.MemoryValue}" : "Memory is empty.");
                break;

            case "4":
                calc.MemoryValue = null;
                Console.WriteLine("Memory cleared.");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void HandleCollectionMemory(Calculator calc)
    {
        Console.WriteLine("\n--- Collection Memory Menu ---");
        Console.WriteLine(" 1 - Display all values");
        Console.WriteLine(" 2 - Display count");
        Console.WriteLine(" 3 - Add a value");
        Console.WriteLine(" 4 - Remove a value");
        Console.WriteLine(" 5 - Sum of values");
        Console.WriteLine(" 6 - Average of values");
        Console.WriteLine(" 7 - Difference of first and last values");

        Console.Write("Choose an option: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                if (calc.IntMemory.Count == 0)
                    Console.WriteLine("Collection is empty.");
                else
                    Console.WriteLine("Stored values: " + string.Join(", ", calc.IntMemory));
                break;

            case "2":
                Console.WriteLine($"Count: {calc.IntMemory.Count}");
                break;

            case "3":
                if (calc.IntMemory.Count >= 10)
                {
                    Console.WriteLine("Memory full (max 10 values).");
                }
                else
                {
                    int newVal = GetValidInt("Enter integer to add: ");
                    calc.IntMemory.Add(newVal);
                    Console.WriteLine("Value added.");
                }
                break;

            case "4":
                int removeVal = GetValidInt("Enter value to remove: ");
                if (calc.IntMemory.Remove(removeVal))
                    Console.WriteLine("Value removed.");
                else
                    Console.WriteLine("Value not found.");
                break;

            case "5":
                int sum = 0;
                foreach (int val in calc.IntMemory)
                    sum += val;
                Console.WriteLine($"Sum: {sum}");
                break;

            case "6":
                if (calc.IntMemory.Count == 0)
                    Console.WriteLine("Collection is empty.");
                else
                    Console.WriteLine($"Average: {(double)calc.IntMemory.Sum() / calc.IntMemory.Count:F2}");
                break;

            case "7":
                if (calc.IntMemory.Count >= 2)
                    Console.WriteLine($"Difference (first - last): {calc.IntMemory[0] - calc.IntMemory[^1]}");
                else
                    Console.WriteLine("Need at least two values.");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
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

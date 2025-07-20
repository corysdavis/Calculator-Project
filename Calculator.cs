using System;
using System.Collections.Generic;

public class Calculator
{
    public int AddIntegers(int a, int b) => a + b;
    public double SubtractDoubles(double a, double b) => b - a;
    public int MultiplyIntegers(int a, int b) => a * b;
    public double DivideDoubles(double a, double b) => b != 0 ? a / b : double.NaN;

    public double EvaluateFormula(string formula)
    {
        try
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(formula, ""));
        }
        catch
        {
            Console.WriteLine("Invalid formula format.");
            return double.NaN;
        }
    }

    public double? MemoryValue { get; set; }

    public List<int> IntMemory { get; set; } = new List<int>();
}


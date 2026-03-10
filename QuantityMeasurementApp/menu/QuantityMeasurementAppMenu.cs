using System;
using QuantityMeasurementApp.models;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

public class QuantityMeasurementAppMenu
{
    private readonly QuantityMeasurementService measurementService = new QuantityMeasurementService();

    public void Run()
    {
        bool shouldExit = false;

        while (!shouldExit)
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Quantity Measurement App");
            Console.WriteLine("-----------------------");

            Console.WriteLine("1. Length Measurement");
            Console.WriteLine("2. Weight Measurement");
            Console.WriteLine("3. Volume Measurement");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    RunCategory<LengthUnit>("Length", "0:Inches, 1:Feet, 2:Yards, 3:CM");
                    break;

                case "2":
                    RunCategory<WeightUnit>("Weight", "0:Grams, 1:Kilograms, 2:Pounds");
                    break;

                case "3":
                    RunCategory<VolumeUnit>("Volume", "0:Liter, 1:MilliLiter, 2:Gallon");
                    break;

                case "4":
                    shouldExit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    /// <summary>
    /// Generic handler for measurement categories.
    /// Prevents duplication of menu logic for different unit types.
    /// </summary>
    private void RunCategory<T>(string categoryName, string unitsInfo) where T : struct, Enum
    {
        bool goBack = false;

        while (!goBack)
        {
            Console.WriteLine($"\n--- {categoryName} Measurement ---");
            Console.WriteLine("1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Subtraction");
            Console.WriteLine("5. Divide");
            Console.WriteLine("6. Back");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    ProcessConversion<T>(unitsInfo);
                    break;

                case "2":
                    ProcessComparison<T>(unitsInfo);
                    break;

                case "3":
                    ProcessAddition<T>(unitsInfo);
                    break;

                case "4":
                    ProcessSubtraction<T>(unitsInfo);
                    break;

                case "5":
                    ProcessDivision<T>(unitsInfo);
                    break;

                case "6":
                    goBack = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    private void ProcessDivision<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Value 1: ");
            double firstVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            double result = measurementService.Divide(firstVal, firstUnit, secondVal, secondUnit);

            Console.WriteLine($"\nResult Ratio: {result} (Dimensionless)");
        }
        catch (ArithmeticException ex)
        {
            Console.WriteLine("Math Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void ProcessSubtraction<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Value 1: ");
            double firstVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> quantityA = new Quantity<T>(firstVal, firstUnit);
            Quantity<T> quantityB = new Quantity<T>(secondVal, secondUnit);

            Console.Write("Explicit target selection (Y/N): ");
            string response = Console.ReadLine()?.ToLower() ?? "";

            if (response == "y")
            {
                Console.Write("Target Unit Index: ");
                T target = (T)(object)int.Parse(Console.ReadLine()!);

                Console.WriteLine($"Result: {measurementService.Subtract(quantityA, quantityB, target)}");
            }
            else
            {
                Console.WriteLine($"Result: {measurementService.Subtract(quantityA, quantityB, quantityA.Unit)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void ProcessComparison<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Value 1: ");
            double firstVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> a = new Quantity<T>(firstVal, firstUnit);
            Quantity<T> b = new Quantity<T>(secondVal, secondUnit);

            bool same = measurementService.Compare(a, b);

            Console.WriteLine($"\nResult: {a} {(same ? "==" : "!=")} {b}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void ProcessConversion<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Enter Value: ");
            double number = double.Parse(Console.ReadLine()!);

            Console.Write("Source Unit Index: ");
            T from = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Target Unit Index: ");
            T to = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> initial = new Quantity<T>(number, from);

            Quantity<T> result = measurementService.DemonstrateConversion(initial, to);

            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void ProcessAddition<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Value 1: ");
            double firstVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondVal = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> qA = new Quantity<T>(firstVal, firstUnit);
            Quantity<T> qB = new Quantity<T>(secondVal, secondUnit);

            Console.Write("Explicit target selection (Y/N): ");
            string answer = Console.ReadLine()?.ToLower() ?? "";

            if (answer == "y")
            {
                Console.Write("Target Unit Index: ");
                T target = (T)(object)int.Parse(Console.ReadLine()!);

                Console.WriteLine($"Result: {measurementService.DemonstrateAddition(qA, qB, target)}");
            }
            else
            {
                Console.WriteLine($"Result: {measurementService.DemonstrateAddition(qA, qB)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
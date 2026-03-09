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

            string userChoice = Console.ReadLine() ?? "";

            switch (userChoice)
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
    /// Generic handler that runs a measurement category menu.
    /// </summary>
    private void RunCategory<T>(string categoryName, string unitOptions) where T : struct, Enum
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

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    HandleConversion<T>(unitOptions);
                    break;

                case "2":
                    HandleComparison<T>(unitOptions);
                    break;

                case "3":
                    HandleAddition<T>(unitOptions);
                    break;

                case "4":
                    HandleSubtraction<T>(unitOptions);
                    break;

                case "5":
                    HandleDivision<T>(unitOptions);
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

    /// <summary>
    /// Performs division and prints the ratio.
    /// </summary>
    private void HandleDivision<T>(string unitOptions) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitOptions);

            Console.Write("Value 1: ");
            double firstValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            double resultRatio = measurementService.Divide(firstValue, firstUnit, secondValue, secondUnit);

            Console.WriteLine($"\nResult Ratio: {resultRatio} (Dimensionless)");
        }
        catch (ArithmeticException err)
        {
            Console.WriteLine("Math Error: " + err.Message);
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    /// <summary>
    /// Handles subtraction between two quantities.
    /// </summary>
    private void HandleSubtraction<T>(string unitOptions) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitOptions);

            Console.Write("Value 1: ");
            double firstValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> firstQuantity = new Quantity<T>(firstValue, firstUnit);
            Quantity<T> secondQuantity = new Quantity<T>(secondValue, secondUnit);

            Console.Write("Choose target unit manually? (Y/N): ");

            if ((Console.ReadLine() ?? "").ToLower() == "y")
            {
                Console.Write("Target Unit Index: ");
                T target = (T)(object)int.Parse(Console.ReadLine()!);

                Console.WriteLine($"Result: {measurementService.Subtract(firstQuantity, secondQuantity, target)}");
            }
            else
            {
                Console.WriteLine($"Result: {measurementService.Subtract(firstQuantity, secondQuantity, firstQuantity.Unit)}");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    private void HandleComparison<T>(string unitOptions) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitOptions);

            Console.Write("Value 1: ");
            double firstValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> firstQuantity = new Quantity<T>(firstValue, firstUnit);
            Quantity<T> secondQuantity = new Quantity<T>(secondValue, secondUnit);

            bool isEqual = measurementService.Compare(firstQuantity, secondQuantity);

            Console.WriteLine($"\nResult: {firstQuantity} {(isEqual ? "==" : "!=")} {secondQuantity}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    private void HandleConversion<T>(string unitOptions) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitOptions);

            Console.Write("Enter Value: ");
            double inputValue = double.Parse(Console.ReadLine()!);

            Console.Write("Source Unit Index: ");
            T source = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Target Unit Index: ");
            T destination = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> quantity = new Quantity<T>(inputValue, source);
            Quantity<T> converted = measurementService.DemonstrateConversion(quantity, destination);

            Console.WriteLine($"Result: {converted}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    private void HandleAddition<T>(string unitOptions) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitOptions);

            Console.Write("Value 1: ");
            double firstValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondValue = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> firstQuantity = new Quantity<T>(firstValue, firstUnit);
            Quantity<T> secondQuantity = new Quantity<T>(secondValue, secondUnit);

            Console.Write("Choose target unit manually? (Y/N): ");

            if ((Console.ReadLine() ?? "").ToLower() == "y")
            {
                Console.Write("Target Unit Index: ");
                T target = (T)(object)int.Parse(Console.ReadLine()!);

                Console.WriteLine($"Result: {measurementService.DemonstrateAddition(firstQuantity, secondQuantity, target)}");
            }
            else
            {
                Console.WriteLine($"Result: {measurementService.DemonstrateAddition(firstQuantity, secondQuantity)}");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }
}
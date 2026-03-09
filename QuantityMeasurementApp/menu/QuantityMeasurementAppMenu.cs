using System;
using QuantityMeasurementApp.models;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementService = new QuantityMeasurementService();

    public void Run()
    {
        bool shouldExit = false;

        while (!shouldExit)
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Quantity Measurement App (UC10)");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Length Measurement");
            Console.WriteLine("2. Weight Measurement");
            Console.WriteLine("3. Exit");

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
                    shouldExit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    /// <summary>
    /// Generic handler for running a measurement category menu.
    /// </summary>
    private void RunCategory<T>(string categoryName, string availableUnits) where T : struct, Enum
    {
        bool returnToMain = false;

        while (!returnToMain)
        {
            Console.WriteLine($"\n--- {categoryName} Measurement ---");
            Console.WriteLine("1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Back");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    ProcessConversion<T>(availableUnits);
                    break;

                case "2":
                    ProcessComparison<T>(availableUnits);
                    break;

                case "3":
                    ProcessAddition<T>(availableUnits);
                    break;

                case "4":
                    returnToMain = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private void ProcessComparison<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Enter first value: ");
            double firstValue = double.Parse(Console.ReadLine()!);

            Console.Write("First unit index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Enter second value: ");
            double secondValue = double.Parse(Console.ReadLine()!);

            Console.Write("Second unit index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            var quantityA = new Quantity<T>(firstValue, firstUnit);
            var quantityB = new Quantity<T>(secondValue, secondUnit);

            bool isEqual = measurementService.Compare(quantityA, quantityB);

            Console.WriteLine($"\nResult: {quantityA} {(isEqual ? "==" : "!=")} {quantityB}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    private void ProcessConversion<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Enter value: ");
            double inputValue = double.Parse(Console.ReadLine()!);

            Console.Write("Source unit index: ");
            T sourceUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Target unit index: ");
            T destinationUnit = (T)(object)int.Parse(Console.ReadLine()!);

            var originalQuantity = new Quantity<T>(inputValue, sourceUnit);
            var convertedQuantity = measurementService.DemonstrateConversion(originalQuantity, destinationUnit);

            Console.WriteLine($"Result: {convertedQuantity}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    private void ProcessAddition<T>(string unitsInfo) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(unitsInfo);

            Console.Write("Enter first value: ");
            double valueOne = double.Parse(Console.ReadLine()!);

            Console.Write("First unit index: ");
            T unitOne = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Enter second value: ");
            double valueTwo = double.Parse(Console.ReadLine()!);

            Console.Write("Second unit index: ");
            T unitTwo = (T)(object)int.Parse(Console.ReadLine()!);

            var firstQuantity = new Quantity<T>(valueOne, unitOne);
            var secondQuantity = new Quantity<T>(valueTwo, unitTwo);

            Console.Write("Select target unit explicitly? (Y/N): ");
            string response = Console.ReadLine() ?? "";

            if (response.ToLower() == "y")
            {
                Console.Write("Target unit index: ");
                T targetUnit = (T)(object)int.Parse(Console.ReadLine()!);

                var result = measurementService.DemonstrateAddition(firstQuantity, secondQuantity, targetUnit);
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                var result = measurementService.DemonstrateAddition(firstQuantity, secondQuantity);
                Console.WriteLine($"Result: {result}");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }
}
using System;
using QuantityMeasurementApp.models;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementService = new QuantityMeasurementService();

    public void Run()
    {
        bool shouldStop = false;

        while (!shouldStop)
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Quantity Measurement App (UC10)");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Length Measurement");
            Console.WriteLine("2. Weight Measurement");
            Console.WriteLine("3. Volume Measurement");
            Console.WriteLine("4. Exit");

            string userInput = Console.ReadLine() ?? "";

            switch (userInput)
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
                    shouldStop = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    /// <summary>
    /// Runs the selected measurement category menu and routes the action
    /// to the appropriate handler method.
    /// </summary>
    private void RunCategory<T>(string categoryName, string availableUnits) where T : struct, Enum
    {
        bool goBack = false;

        while (!goBack)
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
                    goBack = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    private void ProcessComparison<T>(string availableUnits) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(availableUnits);

            Console.Write("Value 1: ");
            double firstNumber = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T firstUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double secondNumber = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T secondUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> firstQuantity = new Quantity<T>(firstNumber, firstUnit);
            Quantity<T> secondQuantity = new Quantity<T>(secondNumber, secondUnit);

            bool isSame = measurementService.Compare(firstQuantity, secondQuantity);

            Console.WriteLine($"\nResult: {firstQuantity} {(isSame ? "==" : "!=")} {secondQuantity}");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }

    private void ProcessConversion<T>(string availableUnits) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(availableUnits);

            Console.Write("Enter Value: ");
            double enteredValue = double.Parse(Console.ReadLine()!);

            Console.Write("Source Unit Index: ");
            T fromUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Target Unit Index: ");
            T toUnit = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> originalQuantity = new Quantity<T>(enteredValue, fromUnit);
            Quantity<T> convertedQuantity = measurementService.DemonstrateConversion(originalQuantity, toUnit);

            Console.WriteLine($"Result: {convertedQuantity}");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }

    private void ProcessAddition<T>(string availableUnits) where T : struct, Enum
    {
        try
        {
            Console.WriteLine(availableUnits);

            Console.Write("Value 1: ");
            double numberOne = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 1 Index: ");
            T unitOne = (T)(object)int.Parse(Console.ReadLine()!);

            Console.Write("Value 2: ");
            double numberTwo = double.Parse(Console.ReadLine()!);

            Console.Write("Unit 2 Index: ");
            T unitTwo = (T)(object)int.Parse(Console.ReadLine()!);

            Quantity<T> quantityA = new Quantity<T>(numberOne, unitOne);
            Quantity<T> quantityB = new Quantity<T>(numberTwo, unitTwo);

            Console.Write("Explicit target selection (Y/N): ");
            string? decision = Console.ReadLine();

            if (decision != null && decision.ToLower() == "y")
            {
                Console.Write("Target Unit Index: ");
                T selectedUnit = (T)(object)int.Parse(Console.ReadLine()!);

                Quantity<T> result = measurementService.DemonstrateAddition(quantityA, quantityB, selectedUnit);
                Console.WriteLine($"Result: {result}");
            }
            else
            {
                Quantity<T> result = measurementService.DemonstrateAddition(quantityA, quantityB);
                Console.WriteLine($"Result: {result}");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }
}
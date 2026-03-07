using System;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using QuantityMeasurementApp.models;

/// <summary>
/// Console menu for interacting with the quantity measurement system.
/// It allows the user to convert units, compare values, or perform addition.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementHelper = new QuantityMeasurementService();

    public void Run()
    {
        bool stopApp = false;

        while (!stopApp)
        {
            Console.WriteLine("1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Exit");

            string userChoice = Console.ReadLine() ?? "";

            switch (userChoice)
            {
                case "1":
                    StartConversionProcess();
                    break;

                case "2":
                    OpenComparisonMenu();
                    break;

                case "3":
                    StartAdditionProcess();
                    break;

                case "4":
                    stopApp = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    /// <summary>
    /// Shows different comparison options and lets the user pick
    /// which units they want to compare.
    /// </summary>
    public void OpenComparisonMenu()
    {
        bool goBack = false;

        while (!goBack)
        {
            Console.WriteLine("1. Compare Feet with Feet");
            Console.WriteLine("2. Compare Inches with Inches");
            Console.WriteLine("3. Compare Yards with Yards");
            Console.WriteLine("4. Compare Centimeter with Centimeter");
            Console.WriteLine("5. Compare Feet with Inches");
            Console.WriteLine("6. Compare Yards with Inches");
            Console.WriteLine("7. Compare Centimeter with Inches");
            Console.WriteLine("8. Compare Feet with Yards");
            Console.WriteLine("9. Compare Centimeter with Feet");
            Console.WriteLine("10. Compare Yard with Centimeter");
            Console.WriteLine("11. Back");

            string optionSelected = Console.ReadLine() ?? "";

            switch (optionSelected)
            {
                case "1":
                    CompareMeasurements(LengthUnit.Feet, LengthUnit.Feet);
                    break;

                case "2":
                    CompareMeasurements(LengthUnit.Inches, LengthUnit.Inches);
                    break;

                case "3":
                    CompareMeasurements(LengthUnit.Yards, LengthUnit.Yards);
                    break;

                case "4":
                    CompareMeasurements(LengthUnit.Centimeters, LengthUnit.Centimeters);
                    break;

                case "5":
                    CompareMeasurements(LengthUnit.Feet, LengthUnit.Inches);
                    break;

                case "6":
                    CompareMeasurements(LengthUnit.Yards, LengthUnit.Inches);
                    break;

                case "7":
                    CompareMeasurements(LengthUnit.Centimeters, LengthUnit.Inches);
                    break;

                case "8":
                    CompareMeasurements(LengthUnit.Feet, LengthUnit.Yards);
                    break;

                case "9":
                    CompareMeasurements(LengthUnit.Centimeters, LengthUnit.Feet);
                    break;

                case "10":
                    CompareMeasurements(LengthUnit.Yards, LengthUnit.Centimeters);
                    break;

                case "11":
                    goBack = true;
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    /// <summary>
    /// Reads two values and checks whether they represent the same length.
    /// </summary>
    private void CompareMeasurements(LengthUnit firstUnit, LengthUnit secondUnit)
    {
        try
        {
            Console.Write($"Enter value1 in {firstUnit.GetSymbol()}: ");
            double firstValue = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Enter value2 in {secondUnit.GetSymbol()}: ");
            double secondValue = Convert.ToDouble(Console.ReadLine());

            Quantity firstQuantity = new Quantity(firstValue, firstUnit);
            Quantity secondQuantity = new Quantity(secondValue, secondUnit);

            bool equality = measurementHelper.Compare(firstQuantity, secondQuantity);

            Console.WriteLine(equality ? "Measurement are Equal" : "Measurement are not Equal");
        }
        catch (Exception problem)
        {
            Console.WriteLine("Error: " + problem.Message);
        }
    }

    /// <summary>
    /// Handles value conversion from one unit to another.
    /// </summary>
    private void StartConversionProcess()
    {
        Console.Write("Enter Value: ");
        double numberInput = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Units : 0:Inches , 1:Feet, 2:Yard, 3:CM");

        Console.Write("Enter Source Unit Index: ");
        LengthUnit fromUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter Target Unit Index: ");
        LengthUnit toUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        try
        {
            double convertedValue = measurementHelper.DemonstrateLengthConversion(numberInput, fromUnit, toUnit);

            Console.WriteLine($"{numberInput}{fromUnit.GetSymbol()} = {convertedValue}{toUnit.GetSymbol()}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    /// <summary>
    /// Reads two quantities and performs addition between them.
    /// </summary>
    private void StartAdditionProcess()
    {
        Console.WriteLine("Unit : 0:Inches, 1:Feet, 2:Yards 3:Centimeter");

        Console.Write("Enter Value 1: ");
        double firstInput = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 1(Index): ");
        LengthUnit unitA = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity quantityA = new Quantity(firstInput, unitA);

        Console.Write("Enter Value 2: ");
        double secondInput = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 2(Index): ");
        LengthUnit unitB = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity quantityB = new Quantity(secondInput, unitB);

        Quantity sumResult = quantityA.Add(quantityB);

        Console.WriteLine($"\nCalculation {quantityA} + {quantityB}");
        Console.WriteLine($"Result = {sumResult}");
    }
}
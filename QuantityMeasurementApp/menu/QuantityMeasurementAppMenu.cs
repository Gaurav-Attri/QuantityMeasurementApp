using System;
using QuantityMeasurementApp.models;

/// <summary>
/// Simple console menu that lets the user perform operations
/// like conversion, comparison and addition of quantities.
/// It reads input from the user and calls the service layer
/// to execute the required logic.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementService = new QuantityMeasurementService();

    public void Run()
    {
        bool shouldClose = false;

        while (!shouldClose)
        {
            Console.WriteLine("1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Exit");

            string userInput = Console.ReadLine() ?? "";

            switch (userInput)
            {
                case "1":
                    HandleConversion();
                    break;

                case "2":
                    CompareRun();
                    break;

                case "3":
                    HandleAddition();
                    break;

                case "4":
                    shouldClose = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    /// <summary>
    /// Displays comparison options for different unit combinations
    /// and forwards the request to the comparison handler.
    /// </summary>
    public void CompareRun()
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

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    PerformComparison(LengthUnit.Feet, LengthUnit.Feet);
                    break;

                case "2":
                    PerformComparison(LengthUnit.Inches, LengthUnit.Inches);
                    break;

                case "3":
                    PerformComparison(LengthUnit.Yards, LengthUnit.Yards);
                    break;

                case "4":
                    PerformComparison(LengthUnit.Centimeters, LengthUnit.Centimeters);
                    break;

                case "5":
                    PerformComparison(LengthUnit.Feet, LengthUnit.Inches);
                    break;

                case "6":
                    PerformComparison(LengthUnit.Yards, LengthUnit.Inches);
                    break;

                case "7":
                    PerformComparison(LengthUnit.Centimeters, LengthUnit.Inches);
                    break;

                case "8":
                    PerformComparison(LengthUnit.Feet, LengthUnit.Yards);
                    break;

                case "9":
                    PerformComparison(LengthUnit.Centimeters, LengthUnit.Feet);
                    break;

                case "10":
                    PerformComparison(LengthUnit.Yards, LengthUnit.Centimeters);
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
    /// Reads two quantities from the console and checks
    /// whether they represent the same measurement.
    /// </summary>
    private void PerformComparison(LengthUnit firstUnit, LengthUnit secondUnit)
    {
        try
        {
            Console.Write($"Enter value1 in {firstUnit.GetSymbol()}: ");
            double firstValue = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Enter value2 in {secondUnit.GetSymbol()}: ");
            double secondValue = Convert.ToInt32(Console.ReadLine());

            Quantity quantityA = new Quantity(firstValue, firstUnit);
            Quantity quantityB = new Quantity(secondValue, secondUnit);

            bool isEqual = measurementService.Compare(quantityA, quantityB);

            if (isEqual)
                Console.WriteLine("Measurement are Equal");
            else
                Console.WriteLine("Measurement are not Equal");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }

    /// <summary>
    /// Handles conversion of a value from one unit to another.
    /// User selects the source and destination unit using index values.
    /// </summary>
    private void HandleConversion()
    {
        Console.Write("Enter Value: ");
        double inputValue = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Units : 0:Inches , 1:Feet, 2:Yard, 3:CM");

        Console.Write("Enter Source Unit Index: ");
        LengthUnit sourceUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter Target Unit Index: ");
        LengthUnit destinationUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        try
        {
            double convertedValue = measurementService.DemonstrateLengthConversion(
                inputValue,
                sourceUnit,
                destinationUnit
            );

            Console.WriteLine($"{inputValue}{sourceUnit.GetSymbol()} = {convertedValue}{destinationUnit.GetSymbol()}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    /// <summary>
    /// Allows the user to add two quantities.
    /// User may optionally choose the unit in which the result should appear.
    /// </summary>
    private void HandleAddition()
    {
        Console.WriteLine("Unit : 0:Inches, 1:Feet, 2:Yards 3:Centimeter");

        Console.Write("Enter Value 1: ");
        double firstAmount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 1(Index): ");
        LengthUnit firstUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity quantityOne = new Quantity(firstAmount, firstUnit);

        Console.Write("Enter Value 2: ");
        double secondAmount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 2(Index): ");
        LengthUnit secondUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity quantityTwo = new Quantity(secondAmount, secondUnit);

        Console.Write("Explicit target selection (Y/N): ");
        string decision = Console.ReadLine()?.ToLower() ?? "n";

        Quantity finalResult;

        if (decision == "y")
        {
            Console.WriteLine("Enter the unit index of Target unit");
            LengthUnit chosenUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

            finalResult = quantityOne.Add(quantityTwo, chosenUnit);
        }
        else
        {
            finalResult = quantityOne.Add(quantityTwo);
        }

        Console.WriteLine($"\nCalculation {quantityOne} + {quantityTwo}");
        Console.WriteLine($"Result = {finalResult}");
    }
}
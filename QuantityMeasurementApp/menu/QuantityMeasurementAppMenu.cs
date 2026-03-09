using System;
using QuantityMeasurementApp.models;

/// <summary>
/// Simple console menu used to interact with the Quantity Measurement system.
/// It reads user input, shows options, and calls the required service methods
/// for conversion, comparison, and addition of measurements.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementService = new QuantityMeasurementService();

    public void Run()
    {
        bool stopProgram = false;

        while (!stopProgram)
        {
            Console.WriteLine("1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Exit");

            string userOption = Console.ReadLine() ?? "";

            switch (userOption)
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
                    stopProgram = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    /// <summary>
    /// Displays the comparison menu and allows the user to choose
    /// different unit combinations to compare.
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
            Console.WriteLine("6. compare Yards with Inches");
            Console.WriteLine("7. Compare Centimeter with Inches");
            Console.WriteLine("8. Compare Feet with Yards");
            Console.WriteLine("9. Compare Centimeter with Feet");
            Console.WriteLine("10. Compare Yard with Centimeter");
            Console.WriteLine("11. Back");

            string selected = Console.ReadLine() ?? "";

            switch (selected)
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
    /// Takes two values with their units and checks whether
    /// the measurements are equal after normalization.
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

            bool areEqual = measurementService.Compare(quantityA, quantityB);

            Console.WriteLine(areEqual
                ? "Measurement are Equal"
                : "Measurement are not Equal");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }

    /// <summary>
    /// Reads a value and converts it from one unit to another
    /// using the service layer.
    /// </summary>
    private void HandleConversion()
    {
        Console.Write("Enter Value: ");
        double inputValue = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Units : 0:Inches , 1:Feet, 2:Yard, 3:CM");

        Console.Write("Enter Source Unit Index: ");
        LengthUnit fromUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Console.Write("Enter Target Unit Index: ");
        LengthUnit toUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        try
        {
            double convertedValue = measurementService
                .DemonstrateLengthConversion(inputValue, fromUnit, toUnit);

            Console.WriteLine($"{inputValue}{fromUnit.GetSymbol()} = {convertedValue}{toUnit.GetSymbol()}");
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: " + err.Message);
        }
    }

    private void HandleAddition()
    {
        Console.WriteLine("Unit : 0:Inches, 1:Feet, 2:Yards 3:Centimeter");

        Console.Write("Enter Value 1: ");
        double firstInput = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 1(Index): ");
        LengthUnit firstUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity firstQuantity = new Quantity(firstInput, firstUnit);

        Console.Write("Enter Value 2: ");
        double secondInput = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 2(Index): ");
        LengthUnit secondUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity secondQuantity = new Quantity(secondInput, secondUnit);

        Console.Write("Explicit target selection (Y/N): ");
        string userDecision = Console.ReadLine()?.ToLower() ?? "n";

        Quantity finalResult;

        if (userDecision == "y")
        {
            Console.WriteLine("Enter the unit index of Target unit");
            LengthUnit desiredUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");
            finalResult = firstQuantity.Add(secondQuantity, desiredUnit);
        }
        else
        {
            finalResult = firstQuantity.Add(secondQuantity);
        }

        Console.WriteLine($"\nCalculation {firstQuantity} + {secondQuantity}");
        Console.WriteLine($"Result = {finalResult}");
    }
}
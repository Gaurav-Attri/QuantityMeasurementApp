using System;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using QuantityMeasurementApp.models;

/// <summary>
/// Console menu controller for the quantity measurement program.
/// It displays options and directs the user to conversion or comparison tasks.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService calcService = new QuantityMeasurementService();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Exit");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    RunConversion();
                    break;

                case "2":
                    ShowComparisonOptions();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    /// <summary>
    /// Displays comparison choices and routes to the compare method.
    /// </summary>
    public void ShowComparisonOptions()
    {
        while (true)
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

            string menuChoice = Console.ReadLine() ?? "";

            if (menuChoice == "11")
                return;

            switch (menuChoice)
            {
                case "1": ExecuteComparison(LengthUnit.Feet, LengthUnit.Feet); break;
                case "2": ExecuteComparison(LengthUnit.Inches, LengthUnit.Inches); break;
                case "3": ExecuteComparison(LengthUnit.Yards, LengthUnit.Yards); break;
                case "4": ExecuteComparison(LengthUnit.Centimeters, LengthUnit.Centimeters); break;
                case "5": ExecuteComparison(LengthUnit.Feet, LengthUnit.Inches); break;
                case "6": ExecuteComparison(LengthUnit.Yards, LengthUnit.Inches); break;
                case "7": ExecuteComparison(LengthUnit.Centimeters, LengthUnit.Inches); break;
                case "8": ExecuteComparison(LengthUnit.Feet, LengthUnit.Yards); break;
                case "9": ExecuteComparison(LengthUnit.Centimeters, LengthUnit.Feet); break;
                case "10": ExecuteComparison(LengthUnit.Yards, LengthUnit.Centimeters); break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    /// <summary>
    /// Reads two numeric values from the console and checks
    /// whether the measurements are equal after conversion.
    /// </summary>
    private void ExecuteComparison(LengthUnit firstType, LengthUnit secondType)
    {
        try
        {
            Console.Write($"Enter value1 in {firstType.GetSymbol()}: ");
            double firstInput = Convert.ToDouble(Console.ReadLine());

            Console.Write($"Enter value2 in {secondType.GetSymbol()}: ");
            double secondInput = Convert.ToDouble(Console.ReadLine());

            Quantity itemA = new Quantity(firstInput, firstType);
            Quantity itemB = new Quantity(secondInput, secondType);

            bool isEqual = calcService.Compare(itemA, itemB);

            if (isEqual)
                Console.WriteLine("Measurement are Equal");
            else
                Console.WriteLine("Measurement are not Equal");
        }
        catch (Exception problem)
        {
            Console.WriteLine("Error: " + problem.Message);
        }
    }

    /// <summary>
    /// Handles unit conversion by reading the value and
    /// unit indexes from the console.
    /// </summary>
    private void RunConversion()
    {
        Console.Write("Enter Value: ");
        double originalValue = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Units : 0:Inches , 1:Feet, 2:Yard, 3:CM");

        Console.Write("Enter Source Unit Index: ");
        int startIndex = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Target Unit Index: ");
        int endIndex = int.Parse(Console.ReadLine() ?? "0");

        LengthUnit startUnit = (LengthUnit)startIndex;
        LengthUnit endUnit = (LengthUnit)endIndex;

        double converted = calcService.DemonstrateLengthConversion(originalValue, startUnit, endUnit);

        Console.WriteLine($"{originalValue}{startUnit.GetSymbol()} = {converted}{endUnit.GetSymbol()}");
    }
}
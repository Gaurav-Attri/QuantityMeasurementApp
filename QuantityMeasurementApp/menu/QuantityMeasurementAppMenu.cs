using System;
using QuantityMeasurementApp.models;

/// <summary>
/// Console menu used to interact with the Quantity Measurement application.
/// It allows users to perform operations like conversion, comparison,
/// and addition for both length and weight measurements.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementHelper = new QuantityMeasurementService();

    public void Run()
    {
        bool closeProgram = false;

        while (!closeProgram)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Quantity Measurement App");
            Console.WriteLine("-----------------------");

            Console.WriteLine("\n1. Length Measurement");
            Console.WriteLine("2. Weight Measurement");
            Console.WriteLine("3. Exit");

            string menuInput = Console.ReadLine() ?? "";

            switch (menuInput)
            {
                case "1":
                    RunLength();
                    break;
                case "2":
                    RunWeight();
                    break;
                case "3":
                    closeProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public void RunWeight()
    {
        bool goBack = false;

        while (!goBack)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Weight Measurement");
            Console.WriteLine("-----------------------");

            Console.WriteLine("\n1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Exit");

            string selected = Console.ReadLine() ?? "";

            switch (selected)
            {
                case "1":
                    HandleWeightConversion();
                    break;
                case "2":
                    HandleWeightComparison();
                    break;
                case "3":
                    HandleWeightAddition();
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

    public void RunLength()
    {
        bool leaveSection = false;

        while (!leaveSection)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Length Measurement");
            Console.WriteLine("-----------------------");

            Console.WriteLine("\n1. Conversion");
            Console.WriteLine("2. Comparison");
            Console.WriteLine("3. Addition");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    HandleLengthConversion();
                    break;
                case "2":
                    HandleLengthComparison();
                    break;
                case "3":
                    HandleLengthAddition();
                    break;
                case "4":
                    leaveSection = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    /// <summary>
    /// Compares two length measurements.
    /// </summary>
    private void HandleLengthComparison()
    {
        try
        {
            Console.WriteLine("\n--- Length Comparison ---");
            Console.WriteLine("Available Units: 0:Inches, 1:Feet, 2:Yards, 3:CM");

            Console.Write("Select First Unit Index: ");
            LengthUnit firstUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "0");

            Console.Write($"Enter value in {firstUnit.GetSymbol()}: ");
            double firstValue = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Select Second Unit Index: ");
            LengthUnit secondUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "0");

            Console.Write($"Enter value in {secondUnit.GetSymbol()}: ");
            double secondValue = double.Parse(Console.ReadLine() ?? "0");

            Quantity q1 = new Quantity(firstValue, firstUnit);
            Quantity q2 = new Quantity(secondValue, secondUnit);

            bool isSame = q1.Equals(q2);

            Console.WriteLine("\n-----------------------");
            Console.WriteLine($"Result: {q1} {(isSame ? "==" : "!=")} {q2}");
            Console.WriteLine(isSame ? "Measurements are Equal" : "Measurements are NOT Equal");
            Console.WriteLine("-----------------------\n");
        }
        catch (Exception error)
        {
            Console.WriteLine($"\nError: {error.Message}");
        }
    }

    /// <summary>
    /// Handles length conversion between two units.
    /// </summary>
    private void HandleLengthConversion()
    {
        try
        {
            Console.Write("Enter Value: ");
            double inputValue = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Units : 0:Inches , 1:Feet, 2:Yard, 3:CM");

            Console.Write("Enter Source Unit Index: ");
            LengthUnit sourceUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

            Console.Write("Enter Target Unit Index: ");
            LengthUnit targetUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

            double result = measurementHelper.DemonstrateLengthConversion(inputValue, sourceUnit, targetUnit);

            Console.WriteLine($"{inputValue}{sourceUnit.GetSymbol()} = {result}{targetUnit.GetSymbol()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    /// <summary>
    /// Adds two length measurements.
    /// </summary>
    private void HandleLengthAddition()
    {
        Console.WriteLine("Unit : 0:Inches, 1:Feet, 2:Yards 3:Centimeter");

        Console.Write("Enter Value 1: ");
        double firstValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 1(Index): ");
        LengthUnit firstUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity firstQuantity = new Quantity(firstValue, firstUnit);

        Console.Write("Enter Value 2: ");
        double secondValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Unit 2(Index): ");
        LengthUnit secondUnit = (LengthUnit)int.Parse(Console.ReadLine() ?? "");

        Quantity secondQuantity = new Quantity(secondValue, secondUnit);

        Console.Write("Explicit target selection (Y/N): ");
        string decision = Console.ReadLine()?.ToLower() ?? "n";

        Quantity result;

        if (decision == "y")
        {
            Console.WriteLine("Enter the unit index of Target unit");
            LengthUnit target = (LengthUnit)int.Parse(Console.ReadLine() ?? "");
            result = firstQuantity.Add(secondQuantity, target);
        }
        else
        {
            result = firstQuantity.Add(secondQuantity);
        }

        Console.WriteLine($"\nCalculation {firstQuantity} + {secondQuantity}");
        Console.WriteLine($"Result = {result}");
    }

    /// <summary>
    /// Compares two weight quantities.
    /// </summary>
    private void HandleWeightComparison()
    {
        try
        {
            Console.WriteLine("Units: 0:Grams, 1:Kilograms, 2:Pounds");

            Console.Write("Enter Value 1: ");
            double firstValue = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Unit 1 Index: ");
            WeightUnit firstUnit = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Value 2: ");
            double secondValue = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Unit 2 Index: ");
            WeightUnit secondUnit = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");

            QuantityWeight w1 = new QuantityWeight(firstValue, firstUnit);
            QuantityWeight w2 = new QuantityWeight(secondValue, secondUnit);

            Console.WriteLine(w1.Equals(w2) ? "Weights are Equal" : "Weights are not Equal");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    /// <summary>
    /// Converts weight between two units.
    /// </summary>
    private void HandleWeightConversion()
    {
        Console.Write("Enter Value: ");
        double inputWeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Units: 0:Grams, 1:Kilograms, 2:Pounds");

        Console.Write("Enter Source Unit Index: ");
        WeightUnit source = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Target Unit Index: ");
        WeightUnit target = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");

        QuantityWeight weightObj = new QuantityWeight(inputWeight, source);
        QuantityWeight result = weightObj.ConvertTo(target);

        Console.WriteLine($"{inputWeight}{source.GetSymbol()} = {result.amount}{target.GetSymbol()}");
    }

    /// <summary>
    /// Adds two weight quantities.
    /// </summary>
    private void HandleWeightAddition()
    {
        Console.WriteLine("Units: 0:Grams, 1:Kilograms, 2:Pounds");

        Console.Write("Enter Value 1: ");
        double firstValue = Convert.ToDouble(Console.ReadLine());

        WeightUnit firstUnit = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Value 2: ");
        double secondValue = Convert.ToDouble(Console.ReadLine());

        WeightUnit secondUnit = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");

        QuantityWeight w1 = new QuantityWeight(firstValue, firstUnit);
        QuantityWeight w2 = new QuantityWeight(secondValue, secondUnit);

        Console.Write("Explicit target selection (Y/N): ");
        string choice = Console.ReadLine()?.ToLower() ?? "n";

        QuantityWeight result;

        if (choice == "y")
        {
            Console.Write("Enter Target Unit Index: ");
            WeightUnit target = (WeightUnit)int.Parse(Console.ReadLine() ?? "0");
            result = w1.Add(w2, target);
        }
        else
        {
            result = w1.Add(w2, firstUnit);
        }

        Console.WriteLine($"\nResult = {result.amount} {result.unitType.GetSymbol()}");
    }
}
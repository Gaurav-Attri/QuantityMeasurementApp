using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using QuantityMeasurementApp.models;

/// <summary>
/// Console menu for the Quantity Measurement program.
/// It shows the available comparison options, takes user input,
/// and calls the service to compare different measurement values.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService measurementService = new QuantityMeasurementService();

    /// <summary>
    /// Runs the main menu loop and processes the user's selection.
    /// </summary>
    public void Run()
    {
        bool stopProgram = false;

        while (!stopProgram)
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
            Console.WriteLine("11. Exit");

            string userInput = Console.ReadLine() ?? "";

            switch (userInput)
            {
                case "1":
                    HandleComparison(LengthUnit.Feet, LengthUnit.Feet);
                    break;

                case "2":
                    HandleComparison(LengthUnit.Inches, LengthUnit.Inches);
                    break;

                case "3":
                    HandleComparison(LengthUnit.Yards, LengthUnit.Yards);
                    break;

                case "4":
                    HandleComparison(LengthUnit.Centimeters, LengthUnit.Centimeters);
                    break;

                case "5":
                    HandleComparison(LengthUnit.Feet, LengthUnit.Inches);
                    break;

                case "6":
                    HandleComparison(LengthUnit.Yards, LengthUnit.Inches);
                    break;

                case "7":
                    HandleComparison(LengthUnit.Centimeters, LengthUnit.Inches);
                    break;

                case "8":
                    HandleComparison(LengthUnit.Feet, LengthUnit.Yards);
                    break;

                case "9":
                    HandleComparison(LengthUnit.Centimeters, LengthUnit.Feet);
                    break;

                case "10":
                    HandleComparison(LengthUnit.Yards, LengthUnit.Centimeters);
                    break;

                case "11":
                    stopProgram = true;
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    /// <summary>
    /// Reads two values from the user and compares them using the selected units.
    /// </summary>
    private void HandleComparison(LengthUnit firstUnit, LengthUnit secondUnit)
    {
        try
        {
            Console.Write($"Enter value1 in {firstUnit.GetSymbol()}: ");
            double firstValue = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Enter value2 in {secondUnit.GetSymbol()}: ");
            double secondValue = Convert.ToInt32(Console.ReadLine());

            Quantity quantityOne = new Quantity(firstValue, firstUnit);
            Quantity quantityTwo = new Quantity(secondValue, secondUnit);

            Console.WriteLine(
                measurementService.Compare(quantityOne, quantityTwo)
                ? "Measurement are Equal"
                : "Measurement are not Equal"
            );
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }
}
using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using QuantityMeasurementApp.models;

/// <summary>
/// Provides a console-based interface for the Quantity Measurement Application.
/// Handles user input, menu navigation, and coordinates the comparison of 
/// measurement units using service utilities.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private QuantityMeasurementService service = new QuantityMeasurementService();
    
    /// <summary>
    /// Starts the main application loop, displaying the menu options 
    /// and routing user choices to the appropriate logic.
    /// </summary>
    public void Run()
    {
        bool exit =  false;
        while (!exit)
        {
            Console.WriteLine("1. Compare Feet Equality");
            Console.WriteLine("2. Compare Inches Equality");
            Console.WriteLine("3. Compare Feet To Inch");
            Console.WriteLine("4. Exit");
            Console.Write("Please enter your choice number: ");
            string choice = Console.ReadLine()??"";
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                PerformComparison(LengthUnit.Feet,LengthUnit.Feet);
                break;

                case "2":
                PerformComparison(LengthUnit.Inches,LengthUnit.Inches);
                break;

                case "3":
                PerformComparison(LengthUnit.Feet,LengthUnit.Inches);
                break;

                case "4":
                exit = true;
                break;

                default:
                Console.WriteLine("Invalid Input");
                break;
            }
        }

    }

    /// <summary>
    /// Generic input handler that works for any combination of units.
    /// This eliminates the need for separate 'CompareFeet' and 'CompareInches' methods.
    /// </summary>
    private void PerformComparison(LengthUnit u1 , LengthUnit u2)
    {
        try
        {
            Console.Write($"Enter first value in {u1.GetSymbol()}: ");
            double val1 = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Enter second value in {u2.GetSymbol()}: ");
            double val2 = Convert.ToDouble(Console.ReadLine());

            Quantity q1 = new Quantity(val1, u1);
            Quantity q2 = new Quantity(val2, u2);

            Console.WriteLine(service.Compare(q1,q2) ? "\nMeasurement are Equal\n" : "\nMeasurement are not Equal\n");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }
    }

    
}
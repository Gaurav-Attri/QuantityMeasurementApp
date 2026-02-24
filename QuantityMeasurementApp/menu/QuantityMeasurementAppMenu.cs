using System;
using QuantityMeasurementApp.models;
using QuantityMeasurementApp.service;

/// <summary>
/// Console controller responsible for interacting with the user
/// and delegating measurement comparison tasks.
/// </summary>
public class QuantityMeasurementAppMenu
{
    private readonly QuantityMeasurementService _measurementService;

    public QuantityMeasurementAppMenu()
    {
        _measurementService = new QuantityMeasurementService();
    }

    /// <summary>
    /// Entry loop for menu interaction.
    /// Keeps running until user decides to terminate.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            DisplayOptions();

            string input = Console.ReadLine() ?? string.Empty;

            if (input == "1")
            {
                HandleFeetComparison();
            }
            else if (input == "2")
            {
                HandleInchesComparison();
            }
            else if (input == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }

    private void DisplayOptions()
    {
        Console.WriteLine("1. Compare Feet Equality");
        Console.WriteLine("2. Compare Inches Equality");
        Console.WriteLine("3. Exit");
    }

    private void HandleFeetComparison()
    {
        try
        {
            double first = ReadNumericValue("Enter first value in feet: ");
            double second = ReadNumericValue("Enter second value in feet: ");

            Feet firstFeet = new Feet(first);
            Feet secondFeet = new Feet(second);

            bool result = _measurementService.AreFeetEqual(firstFeet, secondFeet);

            DisplayComparisonResult(result);
        }
        catch (FormatException formatError)
        {
            Console.WriteLine("Format Exception " + formatError.Message);
        }
        catch (Exception generalError)
        {
            Console.WriteLine("General Exception: " + generalError.Message);
        }
    }

    private void HandleInchesComparison()
    {
        try
        {
            double first = ReadNumericValue("Enter first value in inches: ");
            double second = ReadNumericValue("Enter second value in inches: ");

            Inches firstInches = new Inches(first);
            Inches secondInches = new Inches(second);

            bool result = _measurementService.AreInchesEqual(firstInches, secondInches);

            DisplayComparisonResult(result);
        }
        catch (FormatException formatError)
        {
            Console.WriteLine("Format Exception " + formatError.Message);
        }
        catch (Exception generalError)
        {
            Console.WriteLine("General Exception: " + generalError.Message);
        }
    }

    private double ReadNumericValue(string prompt)
    {
        Console.Write(prompt);
        return Convert.ToDouble(Console.ReadLine());
    }

    private void DisplayComparisonResult(bool isEqual)
    {
        Console.WriteLine(isEqual
            ? "The Measurement are Equal"
            : "The Measurement are not Equal");
    }
}
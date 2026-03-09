using System;
using QuantityMeasurementApp.models;

// Handles operations related to quantity comparison and conversion.
public class QuantityMeasurementService
{
    /// <summary>
    /// Checks whether two measurements represent the same physical length.
    /// </summary>
    public bool Compare(Quantity firstQuantity, Quantity secondQuantity)
    {
        if (firstQuantity == null || secondQuantity == null)
        {
            return false;
        }

        bool result = firstQuantity.Equals(secondQuantity);
        return result;
    }

    /// <summary>
    /// Converts a raw numeric value from one unit to another.
    /// The actual conversion logic is handled inside the Quantity class.
    /// </summary>
    public double DemonstrateLengthConversion(double inputNumber, LengthUnit sourceUnit, LengthUnit destinationUnit)
    {
        double convertedNumber = Quantity.ConvertValue(inputNumber, sourceUnit, destinationUnit);
        return convertedNumber;
    }

    /// <summary>
    /// Converts a Quantity object into a different unit and returns the new object.
    /// </summary>
    public Quantity DemonstrateLengthConversion(Quantity originalQuantity, LengthUnit desiredUnit)
    {
        Quantity convertedQuantity = originalQuantity.ConvertTo(desiredUnit);
        return convertedQuantity;
    }

    /// <summary>
    /// Adds two Quantity objects and returns the result.
    /// The output unit will match the unit of the first quantity.
    /// </summary>
    public Quantity DemonstrateAddition(Quantity firstValue, Quantity secondValue)
    {
        Quantity sumResult = firstValue.Add(secondValue);
        return sumResult;
    }
}
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using QuantityMeasurementApp.models;


// Handles operations related to measurement comparison and conversion
public class QuantityMeasurementService
{
    /// <summary>
    /// Checks whether two Quantity objects represent the same measurement.
    /// </summary>
    public bool Compare(Quantity firstQuantity, Quantity secondQuantity)
    {
        if (firstQuantity == null || secondQuantity == null)
        {
            return false;
        }

        bool areEqual = firstQuantity.Equals(secondQuantity);
        return areEqual;
    }

    /// <summary>
    /// Converts a numeric value from one length unit to another.
    /// The actual conversion logic is handled inside the Quantity class.
    /// </summary>
    /// <param name="inputValue">Number to convert</param>
    /// <param name="sourceUnit">Original unit</param>
    /// <param name="targetUnit">Unit to convert into</param>
    /// <returns>Converted numeric value</returns>
    public double DemonstrateLengthConversion(double inputValue, LengthUnit sourceUnit, LengthUnit targetUnit)
    {
        double convertedNumber = Quantity.ConvertValue(inputValue, sourceUnit, targetUnit);
        return convertedNumber;
    }

    /// <summary>
    /// Converts an existing Quantity object to another length unit.
    /// </summary>
    /// <param name="originalQuantity">Quantity object to convert</param>
    /// <param name="desiredUnit">Target unit</param>
    /// <returns>New Quantity object in the requested unit</returns>
    public Quantity DemonstrateLengthConversion(Quantity originalQuantity, LengthUnit desiredUnit)
    {
        Quantity updatedQuantity = originalQuantity.ConvertTo(desiredUnit);
        return updatedQuantity;
    }
}
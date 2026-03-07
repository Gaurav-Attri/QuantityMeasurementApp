using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using QuantityMeasurementApp.models;


// Handles operations like comparing, converting and adding quantities
public class QuantityMeasurementService
{
    /// <summary>
    /// Checks whether two quantity objects represent the same measurement.
    /// </summary>
    public bool Compare(Quantity firstItem, Quantity secondItem)
    {
        if (firstItem == null || secondItem == null)
        {
            return false;
        }

        bool sameValue = firstItem.Equals(secondItem);
        return sameValue;
    }

    /// <summary>
    /// Converts a numeric value from one unit to another.
    /// Uses the conversion logic defined inside the Quantity class.
    /// </summary>
    /// <param name="inputValue">number to convert</param>
    /// <param name="sourceUnit">original unit</param>
    /// <param name="targetUnit">destination unit</param>
    /// <returns>converted numeric result</returns>
    public double DemonstrateLengthConversion(double inputValue, LengthUnit sourceUnit, LengthUnit targetUnit)
    {
        double resultNumber = Quantity.ConvertValue(inputValue, sourceUnit, targetUnit);
        return resultNumber;
    }

    /// <summary>
    /// Converts a Quantity object into another unit.
    /// </summary>
    /// <param name="originalQuantity">quantity that needs conversion</param>
    /// <param name="desiredUnit">target unit</param>
    /// <returns>new Quantity object in requested unit</returns>
    public Quantity DemonstrateLengthConversion(Quantity originalQuantity, LengthUnit desiredUnit)
    {
        Quantity convertedQuantity = originalQuantity.ConvertTo(desiredUnit);
        return convertedQuantity;
    }

    /// <summary>
    /// Adds two quantities and returns the result in the unit of the first quantity.
    /// </summary>
    /// <param name="firstQuantity">first operand</param>
    /// <param name="secondQuantity">second operand</param>
    /// <returns>sum as a Quantity object</returns>
    public Quantity DemonstrateAddition(Quantity firstQuantity, Quantity secondQuantity)
    {
        Quantity total = firstQuantity.Add(secondQuantity);
        return total;
    }
}
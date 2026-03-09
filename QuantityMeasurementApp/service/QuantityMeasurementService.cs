using QuantityMeasurementApp.models;

// Handles operations such as comparison, conversion and addition
// for Quantity objects.
public class QuantityMeasurementService
{
    /// <summary>
    /// Checks whether two measurements represent the same length.
    /// Actual conversion and equality logic is handled inside Quantity.
    /// </summary>
    public bool Compare(Quantity firstMeasurement, Quantity secondMeasurement)
    {
        if (firstMeasurement == null || secondMeasurement == null)
        {
            return false;
        }

        bool result = firstMeasurement.Equals(secondMeasurement);
        return result;
    }

    /// <summary>
    /// Converts a numeric value from one unit to another
    /// by using the conversion utility from the Quantity class.
    /// </summary>
    public double DemonstrateLengthConversion(double inputValue, LengthUnit sourceUnit, LengthUnit targetUnit)
    {
        double converted = Quantity.ConvertValue(inputValue, sourceUnit, targetUnit);
        return converted;
    }

    /// <summary>
    /// Converts a Quantity object into the specified unit
    /// and returns a new converted Quantity.
    /// </summary>
    public Quantity DemonstrateLengthConversion(Quantity sourceQuantity, LengthUnit desiredUnit)
    {
        Quantity convertedQuantity = sourceQuantity.ConvertTo(desiredUnit);
        return convertedQuantity;
    }

    /// <summary>
    /// Adds two Quantity objects together and returns
    /// the result using the unit of the first quantity.
    /// </summary>
    public Quantity DemonstrateAddition(Quantity firstQuantity, Quantity secondQuantity)
    {
        Quantity total = firstQuantity.Add(secondQuantity);
        return total;
    }
}
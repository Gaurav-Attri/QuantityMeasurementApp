using QuantityMeasurementApp.models;

/// <summary>
/// Service layer that coordinates comparison, conversion,
/// and addition operations for quantity objects.
/// </summary>
public class QuantityMeasurementService
{
    /// <summary>
    /// Checks whether two quantity objects represent the same measurement.
    /// </summary>
    public bool Compare(Quantity firstQuantity, Quantity secondQuantity)
    {
        if (firstQuantity == null || secondQuantity == null)
        {
            return false;
        }

        return firstQuantity.Equals(secondQuantity);
    }

    /// <summary>
    /// Converts a numeric length value from one unit to another.
    /// </summary>
    /// <param name="inputValue">numeric value to convert</param>
    /// <param name="sourceUnit">unit of the given value</param>
    /// <param name="targetUnit">unit we want the result in</param>
    /// <returns>converted numeric value</returns>
    public double DemonstrateLengthConversion(double inputValue, LengthUnit sourceUnit, LengthUnit targetUnit)
    {
        return Quantity.ConvertValue(inputValue, sourceUnit, targetUnit);
    }

    /// <summary>
    /// Converts a Quantity object into another length unit.
    /// </summary>
    /// <param name="originalQuantity">quantity object to convert</param>
    /// <param name="targetUnit">desired unit</param>
    /// <returns>converted Quantity object</returns>
    public Quantity DemonstrateLengthConversion(Quantity originalQuantity, LengthUnit targetUnit)
    {
        return originalQuantity.ConvertTo(targetUnit);
    }

    /// <summary>
    /// Adds two quantities and returns the result.
    /// The result uses the unit of the first quantity.
    /// </summary>
    public Quantity DemonstrateAddition(Quantity firstQuantity, Quantity secondQuantity)
    {
        return firstQuantity.Add(secondQuantity);
    }
}
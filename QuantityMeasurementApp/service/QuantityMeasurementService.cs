using System.Security.Cryptography.X509Certificates;
using QuantityMeasurementApp.models;

// Handles operations related to comparing measurement quantities.
public class QuantityMeasurementService
{
    /// <summary>
    /// Checks whether two Quantity objects represent the same measurement.
    /// Actual unit conversion is managed inside the Quantity class.
    /// </summary>
    public bool Compare(Quantity firstQuantity, Quantity secondQuantity)
    {
        if (firstQuantity == null || secondQuantity == null)
        {
            return false;
        }

        return firstQuantity.Equals(secondQuantity);
    }
}
using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Service layer that performs common quantity operations
    /// like comparison, conversion, and addition.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Checks whether two quantities represent the same value.
        /// </summary>
        public bool Compare<U>(Quantity<U> firstQuantity, Quantity<U> secondQuantity) where U : struct, Enum
        {
            if (firstQuantity == null || secondQuantity == null)
                return false;

            return firstQuantity.Equals(secondQuantity);
        }

        /// <summary>
        /// Converts a raw numeric value from one unit to another.
        /// </summary>
        public double DemonstrateConversion<U>(double amount, U fromUnit, U toUnit) where U : struct, Enum
        {
            Quantity<U> original = new Quantity<U>(amount, fromUnit);
            Quantity<U> converted = original.ConvertTo(toUnit);

            return converted.Value;
        }

        /// <summary>
        /// Converts an existing quantity into another unit.
        /// </summary>
        public Quantity<U> DemonstrateConversion<U>(Quantity<U> sourceQuantity, U destinationUnit) where U : struct, Enum
        {
            Quantity<U> result = sourceQuantity.ConvertTo(destinationUnit);
            return result;
        }

        /// <summary>
        /// Adds two quantities and keeps the result in the first quantity's unit.
        /// </summary>
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> firstQuantity, Quantity<U> secondQuantity) where U : struct, Enum
        {
            return firstQuantity.Add(secondQuantity);
        }

        /// <summary>
        /// Adds two quantities and converts the result to a chosen unit.
        /// </summary>
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> firstQuantity, Quantity<U> secondQuantity, U resultUnit) where U : struct, Enum
        {
            return firstQuantity.Add(secondQuantity, resultUnit);
        }
    }
}
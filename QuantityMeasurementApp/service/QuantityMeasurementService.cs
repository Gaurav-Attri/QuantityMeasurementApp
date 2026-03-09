using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Handles common operations for Quantity objects such as comparison,
    /// conversion between units, and addition. It simply delegates the work
    /// to the Quantity model while keeping the usage cleaner for callers.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Checks whether two quantities represent the same measurement.
        /// </summary>
        public bool Compare<U>(Quantity<U> firstItem, Quantity<U> secondItem) where U : struct, Enum
        {
            if (firstItem is null || secondItem is null)
                return false;

            bool areEqual = firstItem.Equals(secondItem);
            return areEqual;
        }

        /// <summary>
        /// Converts a numeric value from one unit to another.
        /// </summary>
        public double DemonstrateConversion<U>(double amount, U fromUnit, U toUnit) where U : struct, Enum
        {
            Quantity<U> original = new Quantity<U>(amount, fromUnit);
            Quantity<U> converted = original.ConvertTo(toUnit);

            double finalValue = converted.Value;
            return finalValue;
        }

        /// <summary>
        /// Converts a Quantity instance into a different unit.
        /// </summary>
        public Quantity<U> DemonstrateConversion<U>(Quantity<U> inputQuantity, U destinationUnit) where U : struct, Enum
        {
            Quantity<U> resultQuantity = inputQuantity.ConvertTo(destinationUnit);
            return resultQuantity;
        }

        /// <summary>
        /// Adds two quantities and keeps the unit of the first parameter.
        /// </summary>
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> firstValue, Quantity<U> secondValue) where U : struct, Enum
        {
            Quantity<U> sum = firstValue.Add(secondValue);
            return sum;
        }

        /// <summary>
        /// Adds two quantities and converts the result to a specific unit.
        /// </summary>
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> firstValue, Quantity<U> secondValue, U resultUnit) where U : struct, Enum
        {
            Quantity<U> total = firstValue.Add(secondValue, resultUnit);
            return total;
        }
    }
}
using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Service layer that exposes common operations for Quantity objects.
    /// It simply delegates work to the Quantity model while keeping the API clean.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Checks whether two quantities represent the same value.
        /// </summary>
        public bool Compare<U>(Quantity<U> first, Quantity<U> second) where U : struct, Enum
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        /// <summary>
        /// Converts a raw numeric value from one unit to another.
        /// </summary>
        public double DemonstrateConversion<U>(double inputValue, U fromUnit, U toUnit) where U : struct, Enum
        {
            Quantity<U> original = new Quantity<U>(inputValue, fromUnit);
            Quantity<U> result = original.ConvertTo(toUnit);

            return result.Value;
        }

        /// <summary>
        /// Converts an already created Quantity instance to another unit.
        /// </summary>
        public Quantity<U> DemonstrateConversion<U>(Quantity<U> quantityObj, U destinationUnit) where U : struct, Enum
        {
            return quantityObj.ConvertTo(destinationUnit);
        }

        /// <summary>
        /// Adds two quantities and returns the result in the first quantity's unit.
        /// </summary>
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> left, Quantity<U> right) where U : struct, Enum
        {
            return left.Add(right);
        }

        /// <summary>
        /// Adds two quantities but converts the result to the chosen unit.
        /// </summary>
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> left, Quantity<U> right, U resultUnit) where U : struct, Enum
        {
            return left.Add(right, resultUnit);
        }

        /// <summary>
        /// Performs subtraction between two quantities and returns the result in the requested unit.
        /// </summary>
        public Quantity<U> Subtract<U>(Quantity<U> left, Quantity<U> right, U resultUnit) where U : struct, Enum
        {
            return left.Subtract(right, resultUnit);
        }

        /// <summary>
        /// Divides two quantities and returns the numeric ratio.
        /// </summary>
        public double Divide<T>(double firstValue, T firstUnit, double secondValue, T secondUnit) where T : struct, Enum
        {
            Quantity<T> dividend = new Quantity<T>(firstValue, firstUnit);
            Quantity<T> divisor = new Quantity<T>(secondValue, secondUnit);

            return dividend.Divide(divisor);
        }
    }
}
using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Service layer responsible for coordinating quantity operations
    /// such as comparison, conversion and arithmetic calculations.
    /// </summary>
    public class QuantityMeasurementService
    {
        // Compare two quantities belonging to the same measurement category
        public bool Compare<U>(Quantity<U> first, Quantity<U> second) where U : struct, Enum
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        // Converts a raw value from one unit to another
        public double DemonstrateConversion<U>(double number, U fromUnit, U toUnit) where U : struct, Enum
        {
            Quantity<U> original = new Quantity<U>(number, fromUnit);
            Quantity<U> converted = original.ConvertTo(toUnit);
            return converted.Value;
        }

        // Converts an already created Quantity object
        public Quantity<U> DemonstrateConversion<U>(Quantity<U> sourceQuantity, U target) where U : struct, Enum
        {
            return sourceQuantity.ConvertTo(target);
        }

        // Adds two quantities and keeps the unit of the first operand
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> left, Quantity<U> right) where U : struct, Enum
        {
            return left.Add(right);
        }

        // Addition with explicit result unit
        public Quantity<U> DemonstrateAddition<U>(Quantity<U> left, Quantity<U> right, U desiredUnit) where U : struct, Enum
        {
            return left.Add(right, desiredUnit);
        }

        // Performs subtraction
        public Quantity<U> Subtract<U>(Quantity<U> left, Quantity<U> right, U resultUnit) where U : struct, Enum
        {
            return left.Subtract(right, resultUnit);
        }

        // Divides two quantities and returns a scalar ratio
        public double Divide<T>(double firstValue, T firstUnit, double secondValue, T secondUnit) where T : struct, Enum
        {
            Quantity<T> qA = new Quantity<T>(firstValue, firstUnit);
            Quantity<T> qB = new Quantity<T>(secondValue, secondUnit);

            return qA.Divide(qB);
        }
    }
}
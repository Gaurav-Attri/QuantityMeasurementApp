using System;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a measurable quantity that can work with different unit types
    /// such as Length or Weight. Only Enum types are allowed as units.
    /// </summary>
    public sealed class Quantity<TUnit>
        where TUnit : struct, Enum
    {
        // Used to compare floating-point values safely
        private const double Tolerance = 1e-6;

        /// <summary> Numeric value of the measurement. </summary>
        public double Value { get; }

        /// <summary> Unit associated with the value. </summary>
        public TUnit Unit { get; }

        /// <summary>
        /// Creates a new quantity with a given value and unit.
        /// </summary>
        public Quantity(double amount, TUnit measurementUnit)
        {
            if (!double.IsFinite(amount))
                throw new ArgumentException("Value must be a valid number.");

            Value = amount;
            Unit = measurementUnit;
        }

        /// <summary>
        /// Converts the current quantity into its base unit form.
        /// </summary>
        private double GetBaseValue()
        {
            if (Unit is LengthUnit lengthType)
                return lengthType.ConvertToBase(Value);

            if (Unit is WeightUnit weightType)
                return weightType.ConvertToBase(Value);

            throw new InvalidOperationException("Unit type not supported.");
        }

        /// <summary>
        /// Converts this quantity into another unit within the same category.
        /// </summary>
        public Quantity<TUnit> ConvertTo(TUnit destinationUnit)
        {
            double baseVal = GetBaseValue();
            double resultValue;

            if (destinationUnit is LengthUnit len)
                resultValue = LengthUnitExtensions.ConvertFromBase(len, baseVal);
            else if (destinationUnit is WeightUnit wt)
                resultValue = WeightUnitExtension.ConvertFromBase(wt, baseVal);
            else
                throw new InvalidOperationException("Unit type not supported.");

            return new Quantity<TUnit>(resultValue, destinationUnit);
        }

        /// <summary>
        /// Adds another quantity and returns the result in the current unit.
        /// </summary>
        public Quantity<TUnit> Add(Quantity<TUnit> otherQuantity)
        {
            return Add(otherQuantity, Unit);
        }

        /// <summary>
        /// Adds two quantities and returns the result in the specified unit.
        /// </summary>
        public Quantity<TUnit> Add(Quantity<TUnit> otherQuantity, TUnit outputUnit)
        {
            double combinedBase = GetBaseValue() + otherQuantity.GetBaseValue();
            double convertedResult;

            if (outputUnit is LengthUnit len)
                convertedResult = LengthUnitExtensions.ConvertFromBase(len, combinedBase);
            else if (outputUnit is WeightUnit wt)
                convertedResult = WeightUnitExtension.ConvertFromBase(wt, combinedBase);
            else
                throw new InvalidOperationException("Unit type not supported.");

            return new Quantity<TUnit>(convertedResult, outputUnit);
        }

        /// <summary>
        /// Compares two quantities by converting both to their base units.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not Quantity<TUnit> otherQuantity)
                return false;

            double difference = Math.Abs(GetBaseValue() - otherQuantity.GetBaseValue());
            return difference < Tolerance;
        }

        /// <summary>
        /// Hash code based on the base unit value.
        /// </summary>
        public override int GetHashCode()
        {
            return GetBaseValue().GetHashCode();
        }

        /// <summary>
        /// Returns a readable string with value and unit symbol.
        /// </summary>
        public override string ToString()
        {
            string unitLabel = "";

            if (Unit is LengthUnit len)
                unitLabel = len.GetSymbol();
            else if (Unit is WeightUnit wt)
                unitLabel = wt.GetSymbol();

            return $"{Value} {unitLabel}";
        }
    }
}
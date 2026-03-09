using System;
using QuantityMeasurementApp.models;
using QuantityMeasurementApp.Interface;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic representation of a measurable value.  
    /// Works with different unit enums like Length, Weight, and Volume.
    /// Only enum types are allowed as units.
    /// </summary>
    public sealed class Quantity<TUnit> where TUnit : struct, Enum
    {
        // Small tolerance used when comparing floating-point numbers
        private const double Precision = 1e-6;

        public double Value { get; }
        public TUnit Unit { get; }

        /// <summary>
        /// Creates a new quantity with the given value and unit.
        /// </summary>
        public Quantity(double amount, TUnit measurementUnit)
        {
            if (!double.IsFinite(amount))
                throw new ArgumentException("Value must be a valid number.");

            Value = amount;
            Unit = measurementUnit;
        }

        /// <summary>
        /// Converts the current value into its base representation
        /// (for example: feet → inches, kg → grams).
        /// </summary>
        private double ConvertCurrentToBase()
        {
            if (Unit is LengthUnit lengthType)
                return lengthType.ConvertToBase(Value);

            if (Unit is WeightUnit weightType)
                return weightType.ConvertToBase(Value);

            if (Unit is VolumeUnit volumeType)
                return volumeType.ConvertToBase(Value);

            throw new InvalidOperationException("Unit type not supported.");
        }

        /// <summary>
        /// Converts this quantity into another unit of the same category.
        /// </summary>
        public Quantity<TUnit> ConvertTo(TUnit destinationUnit)
        {
            double baseAmount = ConvertCurrentToBase();
            double convertedValue = 0;

            if (destinationUnit is LengthUnit lengthType)
                convertedValue = LengthUnitExtensions.ConvertFromBase(lengthType, baseAmount);
            else if (destinationUnit is WeightUnit weightType)
                convertedValue = WeightUnitExtension.ConvertFromBase(weightType, baseAmount);
            else if (destinationUnit is VolumeUnit volumeType)
                convertedValue = VolumeUnitExtension.ConvertFromBase(volumeType, baseAmount);

            return new Quantity<TUnit>(convertedValue, destinationUnit);
        }

        /// <summary>
        /// Adds another quantity and returns the result in the current unit.
        /// </summary>
        public Quantity<TUnit> Add(Quantity<TUnit> otherQuantity)
        {
            return Add(otherQuantity, Unit);
        }

        /// <summary>
        /// Adds two quantities and converts the result to a chosen unit.
        /// </summary>
        public Quantity<TUnit> Add(Quantity<TUnit> otherQuantity, TUnit outputUnit)
        {
            double combinedBase = ConvertCurrentToBase() + otherQuantity.ConvertCurrentToBase();
            double finalValue = 0;

            if (outputUnit is LengthUnit lengthType)
                finalValue = LengthUnitExtensions.ConvertFromBase(lengthType, combinedBase);
            else if (outputUnit is WeightUnit weightType)
                finalValue = WeightUnitExtension.ConvertFromBase(weightType, combinedBase);
            else if (outputUnit is VolumeUnit volumeType)
                finalValue = VolumeUnitExtension.ConvertFromBase(volumeType, combinedBase);

            return new Quantity<TUnit>(finalValue, outputUnit);
        }

        /// <summary>
        /// Checks equality by comparing values in their base unit.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not Quantity<TUnit> otherQuantity)
                return false;

            double difference = Math.Abs(ConvertCurrentToBase() - otherQuantity.ConvertCurrentToBase());
            return difference < Precision;
        }

        public override int GetHashCode()
        {
            return ConvertCurrentToBase().GetHashCode();
        }

        /// <summary>
        /// Returns the quantity formatted with its unit symbol.
        /// </summary>
        public override string ToString()
        {
            string unitSymbol = "";

            if (Unit is LengthUnit lengthType)
                unitSymbol = lengthType.GetSymbol();
            else if (Unit is WeightUnit weightType)
                unitSymbol = weightType.GetSymbol();
            else if (Unit is VolumeUnit volumeType)
                unitSymbol = volumeType.GetSymbol();

            return $"{Value} {unitSymbol}";
        }
    }
}
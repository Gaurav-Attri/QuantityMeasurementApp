using System;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic representation of a measurable value with its unit.
    /// Supports conversions and arithmetic between compatible units.
    /// </summary>
    public sealed class Quantity<TUnit> where TUnit : struct, Enum
    {
        private const double tolerance = 1e-6;

        public double Value { get; }

        public TUnit Unit { get; }

        public Quantity(double numericValue, TUnit unitType)
        {
            if (!double.IsFinite(numericValue))
                throw new ArgumentException("Invalid numeric value");

            Value = numericValue;
            Unit = unitType;
        }

        // Converts the quantity into its base representation
        private double ConvertCurrentToBase()
        {
            if (Unit is LengthUnit length)
                return length.ConvertToBase(Value);

            if (Unit is WeightUnit weight)
                return weight.ConvertToBase(Value);

            if (Unit is VolumeUnit volume)
                return volume.ConvertToBase(Value);

            throw new InvalidOperationException("Unsupported unit category");
        }

        public Quantity<TUnit> ConvertTo(TUnit desiredUnit)
        {
            double baseVal = ConvertCurrentToBase();
            double result = 0;

            if (desiredUnit is LengthUnit l)
                result = l.ConvertFromBase(baseVal);

            else if (desiredUnit is WeightUnit w)
                result = w.ConvertFromBase(baseVal);

            else if (desiredUnit is VolumeUnit v)
                result = v.ConvertFromBase(baseVal);

            return new Quantity<TUnit>(result, desiredUnit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other)
        {
            return Add(other, Unit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other, TUnit targetUnit)
        {
            EnsureCompatible(other);

            double combinedBase = ConvertCurrentToBase() + other.ConvertCurrentToBase();
            double finalValue = 0;

            if (targetUnit is LengthUnit l)
                finalValue = l.ConvertFromBase(combinedBase);

            else if (targetUnit is WeightUnit w)
                finalValue = w.ConvertFromBase(combinedBase);

            else if (targetUnit is VolumeUnit v)
                finalValue = v.ConvertFromBase(combinedBase);

            return new Quantity<TUnit>(finalValue, targetUnit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> other)
        {
            return Subtract(other, Unit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> other, TUnit resultUnit)
        {
            EnsureCompatible(other);

            double differenceBase = ConvertCurrentToBase() - other.ConvertCurrentToBase();
            double converted = 0;

            if (resultUnit is LengthUnit l)
                converted = l.ConvertFromBase(differenceBase);

            else if (resultUnit is WeightUnit w)
                converted = w.ConvertFromBase(differenceBase);

            else if (resultUnit is VolumeUnit v)
                converted = v.ConvertFromBase(differenceBase);

            return new Quantity<TUnit>(Math.Round(converted, 2), resultUnit);
        }

        public double Divide(Quantity<TUnit> other)
        {
            EnsureCompatible(other);

            double denominator = other.ConvertCurrentToBase();

            if (Math.Abs(denominator) < tolerance)
                throw new ArithmeticException("Division by zero quantity");

            return ConvertCurrentToBase() / denominator;
        }

        private void EnsureCompatible(Quantity<TUnit> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (!Unit.GetType().Equals(other.Unit.GetType()))
                throw new ArgumentException("Units belong to different categories");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quantity<TUnit> other)
                return false;

            double delta = Math.Abs(ConvertCurrentToBase() - other.ConvertCurrentToBase());
            return delta < tolerance;
        }

        public override int GetHashCode()
        {
            return ConvertCurrentToBase().GetHashCode();
        }

        public override string ToString()
        {
            string label = "";

            if (Unit is LengthUnit l)
                label = l.GetSymbol();

            else if (Unit is WeightUnit w)
                label = w.GetSymbol();

            else if (Unit is VolumeUnit v)
                label = v.GetSymbol();

            return $"{Value} {label}";
        }
    }
}
using System;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic class representing a measurable quantity with a unit.
    /// Handles conversion and arithmetic between compatible units.
    /// </summary>
    public sealed class Quantity<TUnit>
        where TUnit : struct, Enum
    {
        private const double precisionLimit = 1e-6;

        public double Value { get; }

        public TUnit Unit { get; }

        public Quantity(double number, TUnit unitType)
        {
            if (!double.IsFinite(number))
                throw new ArgumentException("Invalid value provided.");

            Value = number;
            Unit = unitType;
        }

        private enum OperationType
        {
            Add,
            Subtract,
            Divide
        }

        private double HandleBaseOperation(Quantity<TUnit> second, OperationType operation)
        {
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            if (!Unit.GetType().Equals(second.Unit.GetType()))
                throw new ArgumentException("Unit types are incompatible.");

            double baseFirst = ConvertToBaseValue();
            double baseSecond = second.ConvertToBaseValue();

            switch (operation)
            {
                case OperationType.Add:
                    return baseFirst + baseSecond;

                case OperationType.Subtract:
                    return baseFirst - baseSecond;

                case OperationType.Divide:
                    if (Math.Abs(baseSecond) < precisionLimit)
                        throw new ArithmeticException("Cannot divide by zero.");
                    return baseFirst / baseSecond;

                default:
                    throw new InvalidOperationException();
            }
        }

        private double ConvertToBaseValue()
        {
            if (Unit is LengthUnit l)
                return l.ConvertToBase(Value);

            if (Unit is WeightUnit w)
                return w.ConvertToBase(Value);

            if (Unit is VolumeUnit v)
                return v.ConvertToBase(Value);

            throw new InvalidOperationException("Unsupported unit type.");
        }

        public Quantity<TUnit> ConvertTo(TUnit target)
        {
            double baseVal = ConvertToBaseValue();
            double convertedVal = 0;

            if (target is LengthUnit l)
                convertedVal = l.ConvertFromBase(baseVal);

            else if (target is WeightUnit w)
                convertedVal = w.ConvertFromBase(baseVal);

            else if (target is VolumeUnit v)
                convertedVal = v.ConvertFromBase(baseVal);

            return new Quantity<TUnit>(convertedVal, target);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other)
        {
            return Add(other, Unit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other, TUnit? targetUnit = null)
        {
            double result = HandleBaseOperation(other, OperationType.Add);
            return CreateFromBase(result, targetUnit ?? Unit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> other)
        {
            return Subtract(other, Unit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> other, TUnit? targetUnit = null)
        {
            double result = HandleBaseOperation(other, OperationType.Subtract);
            double rounded = Math.Round(result, 2);
            return CreateFromBase(rounded, targetUnit ?? Unit);
        }

        public double Divide(Quantity<TUnit> other)
        {
            return HandleBaseOperation(other, OperationType.Divide);
        }

        private Quantity<TUnit> CreateFromBase(double baseValue, TUnit target)
        {
            double converted = 0;

            if (target is LengthUnit l)
                converted = l.ConvertFromBase(baseValue);

            else if (target is WeightUnit w)
                converted = w.ConvertFromBase(baseValue);

            else if (target is VolumeUnit v)
                converted = v.ConvertFromBase(baseValue);

            return new Quantity<TUnit>(converted, target);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quantity<TUnit> other)
                return false;

            return Math.Abs(ConvertToBaseValue() - other.ConvertToBaseValue()) < precisionLimit;
        }

        public override int GetHashCode()
        {
            return ConvertToBaseValue().GetHashCode();
        }

        public override string ToString()
        {
            string unitSymbol = "";

            if (Unit is LengthUnit l)
                unitSymbol = l.GetSymbol();

            else if (Unit is WeightUnit w)
                unitSymbol = w.GetSymbol();

            else if (Unit is VolumeUnit v)
                unitSymbol = v.GetSymbol();

            return $"{Value} {unitSymbol}";
        }
    }
}
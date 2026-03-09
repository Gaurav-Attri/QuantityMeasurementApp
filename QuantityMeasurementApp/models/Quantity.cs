using System;

namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents a measurement consisting of a numeric value
    /// and the unit associated with that value.
    /// </summary>
    public class Quantity
    {
        public readonly double amount;
        public readonly LengthUnit lengthType;

        public Quantity(double amount, LengthUnit lengthType)
        {
            this.amount = amount;
            this.lengthType = lengthType;
        }

        // Convert numeric value from one unit to another
        public static double ConvertValue(double input, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            double baseAmount = sourceUnit.ConvertToBase(input);
            double result = targetUnit.ConvertFromBase(baseAmount);
            return result;
        }

        // Convert this Quantity to another unit
        public Quantity ConvertTo(LengthUnit targetUnit)
        {
            double baseAmount = lengthType.ConvertToBase(amount);
            double convertedValue = targetUnit.ConvertFromBase(baseAmount);

            return new Quantity(convertedValue, targetUnit);
        }

        /// <summary>
        /// Adds another quantity and returns the result
        /// in the unit of the current instance.
        /// </summary>
        public Quantity Add(Quantity otherQuantity)
        {
            if (otherQuantity == null)
            {
                throw new ArgumentNullException("otherQuantity cannot be null");
            }

            return Add(otherQuantity, this.lengthType);
        }

        /// <summary>
        /// Adds two quantities using a specified target unit.
        /// </summary>
        public Quantity Add(Quantity otherQuantity, LengthUnit resultUnit)
        {
            return PerformAddition(this, otherQuantity, resultUnit);
        }

        private Quantity PerformAddition(Quantity firstQuantity, Quantity secondQuantity, LengthUnit resultUnit)
        {
            double firstBase = firstQuantity.lengthType.ConvertToBase(firstQuantity.amount);
            double secondBase = secondQuantity.lengthType.ConvertToBase(secondQuantity.amount);

            double totalBase = firstBase + secondBase;

            double finalValue = resultUnit.ConvertFromBase(totalBase);

            return new Quantity(finalValue, resultUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Quantity other)
            {
                return false;
            }

            double thisBase = lengthType.ConvertToBase(amount);
            double otherBase = other.lengthType.ConvertToBase(other.amount);

            return Math.Abs(thisBase - otherBase) < 0.001;
        }

        public override int GetHashCode()
        {
            double baseValue = lengthType.ConvertToBase(amount);
            return baseValue.GetHashCode();
        }

        public override string ToString()
        {
            return $"{amount} {lengthType.GetSymbol()}";
        }
    }
}
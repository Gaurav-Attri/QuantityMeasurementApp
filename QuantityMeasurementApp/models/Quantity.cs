using System;

namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents a measurement that contains a numeric amount
    /// along with its associated unit. It is designed to handle
    /// operations like conversion, comparison and addition.
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

        // Converts a raw value from one unit to another and returns the numeric result
        public static double ConvertValue(double inputValue, LengthUnit sourceUnit, LengthUnit destinationUnit)
        {
            double inchesValue = inputValue * sourceUnit.GetConversionFactor();
            double convertedResult = inchesValue / destinationUnit.GetConversionFactor();
            return convertedResult;
        }

        // Returns a new Quantity object converted into the specified unit
        public Quantity ConvertTo(LengthUnit destination)
        {
            double resultValue = ConvertValue(this.amount, this.lengthType, destination);
            return new Quantity(resultValue, destination);
        }

        // Converts the current measurement into the base representation (inches)
        private double ConvertToBaseUnit()
        {
            double baseValue = amount * lengthType.GetConversionFactor();
            return baseValue;
        }

        /// <summary>
        /// Adds another measurement to the current instance.
        /// The output unit defaults to the unit of the first quantity.
        /// </summary>
        public Quantity Add(Quantity anotherQuantity)
        {
            if (anotherQuantity == null)
            {
                throw new ArgumentNullException("The quantity to add cannot be null");
            }

            return Add(anotherQuantity, this.lengthType);
        }

        /// <summary>
        /// Adds two quantities and returns the result in the chosen unit.
        /// </summary>
        public Quantity Add(Quantity anotherQuantity, LengthUnit resultUnit)
        {
            return ExecuteAddition(this, anotherQuantity, resultUnit);
        }

        /// <summary>
        /// Internal helper used to perform the addition logic.
        /// Both values are converted to the base unit first.
        /// </summary>
        private Quantity ExecuteAddition(Quantity firstQuantity, Quantity secondQuantity, LengthUnit desiredUnit)
        {
            double firstBase = firstQuantity.amount * firstQuantity.lengthType.GetConversionFactor();
            double secondBase = secondQuantity.amount * secondQuantity.lengthType.GetConversionFactor();

            double totalBase = firstBase + secondBase;

            double convertedTotal = totalBase / desiredUnit.GetConversionFactor();

            return new Quantity(convertedTotal, desiredUnit);
        }

        /// <summary>
        /// Compares two Quantity objects by converting them into the base unit.
        /// This allows values with different units to still be compared correctly.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Quantity otherQuantity)
            {
                return false;
            }

            double difference = Math.Abs(this.ConvertToBaseUnit() - otherQuantity.ConvertToBaseUnit());
            return difference < 0.001;
        }

        public override int GetHashCode()
        {
            return ConvertToBaseUnit().GetHashCode();
        }

        public override string ToString()
        {
            return $"{amount} {lengthType.GetSymbol()}";
        }
    }
}
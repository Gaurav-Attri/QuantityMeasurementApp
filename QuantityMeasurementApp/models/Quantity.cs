using System.Runtime.Serialization.Formatters;

namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents a measurement with a numeric amount and a length unit.
    /// It avoids creating separate classes like Feet or Inches by keeping
    /// everything inside one reusable structure.
    /// </summary>
    public class Quantity
    {
        private readonly double amount;
        private readonly LengthUnit lengthType;

        public Quantity(double amount, LengthUnit lengthType)
        {
            this.amount = amount;
            this.lengthType = lengthType;
        }

        // Converts a numeric value from one unit to another
        public static double ConvertValue(double inputNumber, LengthUnit startUnit, LengthUnit endUnit)
        {
            if (startUnit == null || endUnit == null)
            {
                throw new ArgumentException("unit cannot be null");
            }

            double valueInBase = inputNumber * startUnit.GetConversionFactor();
            double finalValue = valueInBase / endUnit.GetConversionFactor();

            return finalValue;
        }

        // Converts the current Quantity object into another unit
        public Quantity ConvertTo(LengthUnit newUnit)
        {
            double updatedAmount = ConvertValue(this.amount, this.lengthType, newUnit);
            Quantity convertedQuantity = new Quantity(updatedAmount, newUnit);

            return convertedQuantity;
        }

        // Converts the stored value into the base unit (inches)
        private double toBaseUnit()
        {
            double baseNumber = amount * lengthType.GetConversionFactor();
            return baseNumber;
        }

        /// <summary>
        /// Checks whether two Quantity objects represent the same physical length.
        /// Comparison is done after converting both values to a base unit.
        /// </summary>
        public override bool Equals(object? obj)
        {
            // Check if both references point to the same object
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // Ensure object is of the correct type
            if (obj is not Quantity otherQuantity)
            {
                return false;
            }

            double difference = Math.Abs(this.toBaseUnit() - otherQuantity.toBaseUnit());

            return difference < 0.001;
        }

        public override int GetHashCode()
        {
            double baseRepresentation = toBaseUnit();
            return baseRepresentation.GetHashCode();
        }

        public override string ToString()
        {
            return $"{amount} {lengthType.GetSymbol()}";
        }
    }
}
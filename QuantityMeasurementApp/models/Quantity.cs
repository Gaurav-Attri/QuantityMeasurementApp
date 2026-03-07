using System.Runtime.Serialization.Formatters;

namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents a measurement containing a numeric amount and a length unit.
    /// Instead of separate classes like Feet or Inches, this single class
    /// handles all supported units.
    /// </summary>
    public class Quantity
    {
        private readonly double amount;
        private readonly LengthUnit unitType;

        public Quantity(double amount, LengthUnit unitType)
        {
            this.amount = amount;
            this.unitType = unitType;
        }

        // UC5: Converts a numeric value from one unit to another
        public static double ConvertValue(double inputNumber, LengthUnit fromUnit, LengthUnit toUnit)
        {
            double valueInBaseUnit = inputNumber * fromUnit.GetConversionFactor();
            double convertedNumber = valueInBaseUnit / toUnit.GetConversionFactor();

            return convertedNumber;
        }

        // UC5: Returns a new Quantity object converted into another unit
        public Quantity ConvertTo(LengthUnit destinationUnit)
        {
            double updatedAmount = ConvertValue(this.amount, this.unitType, destinationUnit);
            Quantity newQuantity = new Quantity(updatedAmount, destinationUnit);

            return newQuantity;
        }

        // Converts the stored value to the base unit (inches)
        private double ToBaseValue()
        {
            double baseNumber = amount * unitType.GetConversionFactor();
            return baseNumber;
        }

        /// <summary>
        /// UC6: Adds another quantity to the current object.
        /// The final result is returned in the unit of the first quantity.
        /// </summary>
        public Quantity Add(Quantity anotherQuantity)
        {
            if (anotherQuantity == null)
            {
                throw new ArgumentNullException("anotherQuantity cannot be null");
            }

            // convert both quantities into base unit
            double firstBase = this.amount * this.unitType.GetConversionFactor();
            double secondBase = anotherQuantity.amount * anotherQuantity.unitType.GetConversionFactor();

            // add base values
            double combinedBase = firstBase + secondBase;

            // convert result back into the original unit
            double resultValue = combinedBase / this.unitType.GetConversionFactor();

            return new Quantity(resultValue, this.unitType);
        }

        /// <summary>
        /// UC1: Checks if two quantities represent the same physical length.
        /// Both values are converted to a base unit before comparison.
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

            double difference = Math.Abs(this.ToBaseValue() - otherQuantity.ToBaseValue());
            return difference < 0.001;
        }

        public override int GetHashCode()
        {
            double baseRepresentation = ToBaseValue();
            return baseRepresentation.GetHashCode();
        }

        public override string ToString()
        {
            return $"{amount} {unitType.GetSymbol()}";
        }
    }
}
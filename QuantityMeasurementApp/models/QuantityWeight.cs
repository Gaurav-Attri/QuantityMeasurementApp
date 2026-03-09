namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents a weight measurement consisting of a numeric value
    /// along with its corresponding unit.
    /// </summary>
    public class QuantityWeight
    {
        public readonly double amount;
        public readonly WeightUnit unitType;

        public QuantityWeight(double amount, WeightUnit unitType)
        {
            this.amount = amount;
            this.unitType = unitType;
        }

        // Performs direct numeric conversion between two units
        public static double ConvertValue(double input, WeightUnit fromUnit, WeightUnit toUnit)
        {
            double valueInBase = input * fromUnit.GetConversionFactor();
            return valueInBase / toUnit.GetConversionFactor();
        }

        // Converts the current object into another unit and returns a new object
        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            double baseVal = unitType.ConvertToBase(amount);
            double converted = targetUnit.ConvertFromBase(baseVal);

            return new QuantityWeight(converted, targetUnit);
        }

        /// <summary>
        /// Adds another weight to the current instance.
        /// The result will use the unit of the current object.
        /// </summary>
        public QuantityWeight Add(QuantityWeight otherWeight)
        {
            if (otherWeight == null)
            {
                throw new ArgumentNullException("otherWeight cannot be null");
            }

            return Add(otherWeight, unitType);
        }

        /// <summary>
        /// Adds two weights and returns the result in the chosen unit.
        /// </summary>
        public QuantityWeight Add(QuantityWeight otherWeight, WeightUnit resultUnit)
        {
            return CombineWeights(this, otherWeight, resultUnit);
        }

        /// <summary>
        /// Internal helper used to handle addition logic in one place.
        /// </summary>
        private QuantityWeight CombineWeights(QuantityWeight first, QuantityWeight second, WeightUnit outputUnit)
        {
            double baseSum =
                first.unitType.ConvertToBase(first.amount) +
                second.unitType.ConvertToBase(second.amount);

            double convertedResult = outputUnit.ConvertFromBase(baseSum);

            return new QuantityWeight(convertedResult, outputUnit);
        }

        /// <summary>
        /// Checks whether two weight measurements represent the same quantity.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not QuantityWeight otherWeight)
            {
                return false;
            }

            double baseA = unitType.ConvertToBase(amount);
            double baseB = otherWeight.unitType.ConvertToBase(otherWeight.amount);

            return Math.Abs(baseA - baseB) < 0.001;
        }

        public override int GetHashCode()
        {
            return unitType.ConvertToBase(amount).GetHashCode();
        }

        public override string ToString()
        {
            return $"{amount} {unitType.GetSymbol()}";
        }
    }
}
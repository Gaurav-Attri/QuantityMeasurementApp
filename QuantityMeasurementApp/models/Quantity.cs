
namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents a generic measurement consisting of a value and a specific unit.
    /// This class replaces the separate Feet and Inches classes to follow the DRY principle.
    /// </summary>
    public class Quantity
    {
        private readonly double magnitude;
        private readonly LengthUnit unit;

        
        public Quantity(double magnitude , LengthUnit unit)
        {
            this.magnitude = magnitude;
            this.unit = unit;
        }

        /// <summary>
        /// Uses a base-unit conversion strategy to allow cross-unit comparison (e.g., 1ft == 12in).
        /// </summary>
        private double convertToBase()
        {
            return magnitude*unit.GetConversionFactor();
        }

        /// <summary>
        /// Determines if two Quantity objects are equal.
        /// </summary>
        public override bool Equals(object? obj)
        {
            // 1. Checks for reference equality
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            // 2. Checks for null and type safety
            if(obj is not Quantity other)
            {
                return false;
            }


            // Comparing the two with a tolerance of < 0.0001            
            return Math.Abs(this.convertToBase() - other.convertToBase()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return convertToBase().GetHashCode();
        }

        public override string ToString()
        {
            return $"{magnitude} {unit.GetSymbol()}";
        }
    }
}
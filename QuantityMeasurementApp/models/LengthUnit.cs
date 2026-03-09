namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents different units that can be used for measuring length.
    /// The position of each value corresponds to its index in the conversion table.
    /// </summary>
    public enum LengthUnit
    {
        Inches,      // 0
        Feet,        // 1
        Yards,       // 2
        Centimeters  // 3
    }

    /// <summary>
    /// Utility methods related to LengthUnit.
    /// Handles conversion and symbol retrieval.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Conversion multipliers with Inches treated as the base reference
        private static readonly double[] inchReference =
        {
            1.0,        // Inches
            12.0,       // Feet
            36.0,       // Yards
            0.393701    // Centimeters
        };

        /// <summary>
        /// Returns the factor used to convert a unit into inches.
        /// </summary>
        public static double GetConversionFactor(this LengthUnit type)
        {
            int index = (int)type;
            return inchReference[index];
        }

        /// <summary>
        /// Converts a given value into the base unit (inches).
        /// </summary>
        public static double ConvertToBase(this LengthUnit type, double amount)
        {
            double factor = type.GetConversionFactor();
            return amount * factor;
        }

        /// <summary>
        /// Converts a value from the base unit (inches) back to the target unit.
        /// </summary>
        public static double ConvertFromBase(this LengthUnit type, double baseAmount)
        {
            double factor = type.GetConversionFactor();
            return baseAmount / factor;
        }

        /// <summary>
        /// Provides the short label used when displaying the unit.
        /// </summary>
        public static string GetSymbol(this LengthUnit type)
        {
            switch (type)
            {
                case LengthUnit.Inches:
                    return "in";

                case LengthUnit.Feet:
                    return "ft";

                case LengthUnit.Yards:
                    return "yd";

                case LengthUnit.Centimeters:
                    return "cm";

                default:
                    return type.ToString().ToLower();
            }
        }
    }
}
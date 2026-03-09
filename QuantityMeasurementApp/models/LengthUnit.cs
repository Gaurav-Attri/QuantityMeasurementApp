namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents the length units supported in the application.
    /// The numeric position of each value is important because
    /// it is used to map conversion factors.
    /// </summary>
    public enum LengthUnit
    {
        Inches,        // 0
        Feet,          // 1
        Yards,         // 2
        Centimeters    // 3
    }

    /// <summary>
    /// Utility methods that extend LengthUnit.
    /// These methods help with unit conversions and display formatting.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Conversion reference table: each index corresponds to a LengthUnit value
        // and stores the multiplier required to convert that unit into inches.
        private static readonly double[] inchesMultiplier =
        {
            1.0,        // Inches
            12.0,       // Feet
            36.0,       // Yards
            0.393701    // Centimeters
        };

        /// <summary>
        /// Returns the multiplier required to convert the given unit to inches.
        /// </summary>
        public static double GetConversionFactor(this LengthUnit lengthType)
        {
            int indexPosition = (int)lengthType;
            return inchesMultiplier[indexPosition];
        }

        /// <summary>
        /// Provides a short text symbol for the unit.
        /// Used mainly for displaying values in the console.
        /// </summary>
        public static string GetSymbol(this LengthUnit lengthType)
        {
            switch (lengthType)
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
                    return lengthType.ToString().ToLower();
            }
        }
    }
}
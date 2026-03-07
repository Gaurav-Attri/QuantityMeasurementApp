namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Lists all length units supported by the application.
    /// The order matters because it matches the conversion lookup table.
    /// </summary>
    public enum LengthUnit
    {
        Inches,       // position 0
        Feet,         // position 1
        Yards,        // position 2
        Centimeters   // position 3
    }

    /// <summary>
    /// Utility methods that extend the LengthUnit enum.
    /// These helpers keep conversion factors and display symbols in one place.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Table used to convert any unit to the base unit (inches)
        private static readonly double[] conversionTable =
        {
            1.0,        // Inches
            12.0,       // Feet
            36.0,       // Yards
            0.393701    // Centimeters
        };

        /// <summary>
        /// Returns the factor required to convert the given unit into inches.
        /// </summary>
        public static double GetConversionFactor(this LengthUnit unitType)
        {
            int index = (int)unitType;
            double factor = conversionTable[index];
            return factor;
        }

        /// <summary>
        /// Returns the short text symbol used for displaying the unit.
        /// </summary>
        public static string GetSymbol(this LengthUnit unitType)
        {
            switch (unitType)
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
                    string name = unitType.ToString().ToLower();
                    return name;
            }
        }
    }
}
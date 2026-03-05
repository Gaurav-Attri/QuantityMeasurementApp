namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Lists all the length units supported in the application.
    /// The order of the units matters because it matches the
    /// position used in the conversion array.
    /// </summary>
    public enum LengthUnit
    {
        Inches,     
        Feet,       
        Yards,      
        Centimeters 
    }

    /// <summary>
    /// Contains utility methods related to the LengthUnit enum,
    /// mainly used for conversion and displaying unit symbols.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Conversion values used to convert each unit to inches
        private static readonly double[] conversionValues =
        {
            1.0,        // Inches
            12.0,       // Feet (1 ft = 12 inches)
            36.0,       // Yards (1 yd = 36 inches)
            0.393701    // Centimeters (1 cm ≈ 0.393701 inches)
        };

        /// <summary>
        /// Returns the conversion value for the given unit.
        /// </summary>
        public static double GetConversionFactor(this LengthUnit lengthType)
        {
            return conversionValues[(int)lengthType];
        }

        /// <summary>
        /// Returns the short symbol used to represent the unit.
        /// </summary>
        public static string GetSymbol(this LengthUnit lengthType)
        {
            switch (lengthType)
            {
                case LengthUnit.Feet:
                    return "ft";

                case LengthUnit.Inches:
                    return "in";

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
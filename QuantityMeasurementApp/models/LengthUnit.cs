namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents the different units used for length measurement.
    /// The order is used internally for conversion calculations.
    /// </summary>
    public enum LengthUnit
    {
        Inches,
        Feet,
        Yards,
        Centimeters
    }

    public static class LengthUnitExtensions
    {
        // Conversion multipliers relative to inches
        private static readonly double[] conversionValues =
        {
            1.0,
            12.0,
            36.0,
            0.393701
        };

        public static double GetConversionFactor(this LengthUnit current)
        {
            return conversionValues[(int)current];
        }

        public static double ConvertToBase(this LengthUnit current, double number)
        {
            double factor = current.GetConversionFactor();
            return number * factor;
        }

        public static double ConvertFromBase(this LengthUnit current, double baseNumber)
        {
            double factor = current.GetConversionFactor();
            return baseNumber / factor;
        }

        public static string GetSymbol(this LengthUnit current)
        {
            switch (current)
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
                    return current.ToString().ToLower();
            }
        }
    }
}
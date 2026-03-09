namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Lists the length units supported in the system.
    /// The order matters because the enum index maps to the conversion table.
    /// </summary>
    public enum LengthUnit
    {
        Inches,
        Feet,
        Yards,
        Centimeters
    }

    /// <summary>
    /// Helper utilities related to LengthUnit conversions and formatting.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Conversion multipliers relative to Inches (base unit)
        private static readonly double[] inchMultiplier =
        {
            1.0,
            12.0,
            36.0,
            0.393701
        };

        public static double GetConversionFactor(this LengthUnit type)
        {
            int index = (int)type;
            return inchMultiplier[index];
        }

        public static double ConvertToBase(this LengthUnit type, double amount)
        {
            double factor = type.GetConversionFactor();
            return amount * factor;
        }

        public static double ConvertFromBase(this LengthUnit type, double baseAmount)
        {
            double factor = type.GetConversionFactor();
            return baseAmount / factor;
        }

        // Returns readable symbol for display
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
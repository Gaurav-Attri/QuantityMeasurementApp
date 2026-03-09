namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents the length units supported by the application.
    /// The order matters because each value is used as an index
    /// when accessing conversion factors.
    /// </summary>
    public enum LengthUnit
    {
        Inches,      // 0
        Feet,        // 1
        Yards,       // 2
        Centimeters  // 3
    }

    /// <summary>
    /// Utility methods that extend the LengthUnit enum.
    /// These helpers handle unit conversion and provide
    /// display symbols for each measurement type.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Array storing how each unit relates to the base unit (inches)
        private static readonly double[] conversionToInches =
        {
            1.0,        // Inches
            12.0,       // Feet
            36.0,       // Yards
            0.393701    // Centimeters
        };

        /// <summary>
        /// Returns the numeric factor required to convert
        /// the selected unit into inches.
        /// </summary>
        public static double GetConversionFactor(this LengthUnit measurementUnit)
        {
            int index = (int)measurementUnit;
            return conversionToInches[index];
        }

        public static double ConvertToBase(this LengthUnit measurementUnit, double amount)
        {
            double factor = measurementUnit.GetConversionFactor();
            return amount * factor;
        }

        public static double ConvertFromBase(this LengthUnit measurementUnit, double inchesValue)
        {
            double factor = measurementUnit.GetConversionFactor();
            return inchesValue / factor;
        }

        /// <summary>
        /// Provides a short string representation of the unit
        /// mainly used for displaying results in the console.
        /// </summary>
        public static string GetSymbol(this LengthUnit measurementUnit)
        {
            switch (measurementUnit)
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
                    return measurementUnit.ToString().ToLower();
            }
        }
    }
}
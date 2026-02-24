namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Lists the available measurement units.
    /// The order matters: position 0 represents Inches, position 1 represents Feet.
    /// </summary>
    public enum LengthUnit
    {
        Inches,
        Feet
    }

    /// <summary>
    /// Contains utility functions for the LengthUnit enum to keep all conversion logic in one place.
    /// </summary>
    public static class LengthUnitHelper
    {
        // Base Unit: Inches
        // Table: Maps the enum index to its multiplier for the base unit.
        private static readonly double[] ToInchesFactor = {1.0, 12.0};

        // <summary>
        /// Returns the multiplier needed to convert the unit to the base unit.
        /// </summary>
        public static double GetConversionFactor(this LengthUnit unit)
        {
            return ToInchesFactor[(int)unit];
        }

        // Returns the symbol for the unit for displaying on the console.
        public static string GetSymbol(this LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Feet:
                    return "feet";
                
                case LengthUnit.Inches:
                    return "inches";

                default:
                    return unit.ToString().ToLower();
            }
        }
    }
}
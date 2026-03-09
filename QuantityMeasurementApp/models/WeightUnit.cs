namespace QuantityMeasurementApp.models
{
    public enum WeightUnit
    {
        Grams,       // 0
        Kilograms,   // 1
        Pound        // 2
    }

    /// <summary>
    /// Utility functions related to weight units.
    /// Handles conversion logic and symbol lookup.
    /// </summary>
    public static class WeightUnitExtension
    {
        // Conversion multipliers where kilogram acts as the base reference
        private static readonly double[] baseKgMap =
        {
            0.001,      // Grams
            1.0,        // Kilograms
            0.453592    // Pound
        };

        /// <summary>
        /// Returns the multiplier used to convert a unit to kilograms.
        /// </summary>
        public static double GetConversionFactor(this WeightUnit weightType)
        {
            int idx = (int)weightType;
            return baseKgMap[idx];
        }

        /// <summary>
        /// Converts a value from the current unit to kilograms.
        /// </summary>
        public static double ConvertToBase(this WeightUnit weightType, double amount)
        {
            double factor = weightType.GetConversionFactor();
            return amount * factor;
        }

        /// <summary>
        /// Converts a kilogram value to the given weight unit.
        /// </summary>
        public static double ConvertFromBase(this WeightUnit weightType, double kgValue)
        {
            double factor = weightType.GetConversionFactor();
            return kgValue / factor;
        }

        /// <summary>
        /// Returns a short label used for displaying the unit.
        /// </summary>
        public static string GetSymbol(this WeightUnit weightType)
        {
            switch (weightType)
            {
                case WeightUnit.Grams:
                    return "g";

                case WeightUnit.Kilograms:
                    return "Kg";

                case WeightUnit.Pound:
                    return "lb";

                default:
                    return weightType.ToString().ToLower();
            }
        }
    }
}
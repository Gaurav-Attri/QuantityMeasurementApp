namespace QuantityMeasurementApp.models
{
    public enum WeightUnit
    {
        Grams,
        Kilograms,
        Pound
    }

    /// <summary>
    /// Utility methods for handling weight unit conversions.
    /// </summary>
    public static class WeightUnitExtension
    {
        // Conversion multipliers relative to Kilograms (base)
        private static readonly double[] kgMultiplier =
        {
            0.001,
            1.0,
            0.453592
        };

        public static double GetConversionFactor(this WeightUnit unitType)
        {
            return kgMultiplier[(int)unitType];
        }

        public static double ConvertToBase(this WeightUnit unitType, double amount)
        {
            double factor = unitType.GetConversionFactor();
            return amount * factor;
        }

        public static double ConvertFromBase(this WeightUnit unitType, double baseAmount)
        {
            double factor = unitType.GetConversionFactor();
            return baseAmount / factor;
        }

        public static string GetSymbol(this WeightUnit unitType)
        {
            switch (unitType)
            {
                case WeightUnit.Grams:
                    return "g";

                case WeightUnit.Kilograms:
                    return "Kg";

                case WeightUnit.Pound:
                    return "lb";

                default:
                    return unitType.ToString().ToLower();
            }
        }
    }
}
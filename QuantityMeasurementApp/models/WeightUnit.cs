namespace QuantityMeasurementApp.models
{
    public enum WeightUnit
    {
        Grams,
        Kilograms,
        Pound
    }

    /// <summary>
    /// Contains helper methods for weight unit conversion.
    /// </summary>
    public static class WeightUnitExtension
    {
        private static readonly double[] kgMultipliers =
        {
            0.001,
            1.0,
            0.453592
        };

        public static double GetConversionFactor(this WeightUnit unit)
        {
            return kgMultipliers[(int)unit];
        }

        public static double ConvertToBase(this WeightUnit unit, double value)
        {
            double factor = unit.GetConversionFactor();
            return value * factor;
        }

        public static double ConvertFromBase(this WeightUnit unit, double baseValue)
        {
            double factor = unit.GetConversionFactor();
            return baseValue / factor;
        }

        public static string GetSymbol(this WeightUnit unit)
        {
            switch (unit)
            {
                case WeightUnit.Kilograms:
                    return "Kg";

                case WeightUnit.Grams:
                    return "g";

                case WeightUnit.Pound:
                    return "lb";

                default:
                    return unit.ToString().ToLower();
            }
        }
    }
}
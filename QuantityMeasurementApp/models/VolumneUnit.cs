namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Units available for measuring volume.
    /// </summary>
    public enum VolumeUnit
    {
        Litre,
        MilliLiter,
        Gallon
    }

    public static class VolumeUnitExtension
    {
        private static readonly double[] litreMultipliers =
        {
            1.0,
            0.001,
            3.78541
        };

        public static double GetConversionFactor(this VolumeUnit unit)
        {
            return litreMultipliers[(int)unit];
        }

        public static double ConvertToBase(this VolumeUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double ConvertFromBase(this VolumeUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetSymbol(this VolumeUnit unit)
        {
            switch (unit)
            {
                case VolumeUnit.Litre:
                    return "L";

                case VolumeUnit.MilliLiter:
                    return "ML";

                case VolumeUnit.Gallon:
                    return "gal";

                default:
                    return unit.ToString().ToLower();
            }
        }
    }
}
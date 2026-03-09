namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents the volume units used in the system.
    /// The enum position is used to fetch the correct conversion multiplier.
    /// </summary>
    public enum VolumeUnit
    {
        Litre,
        MilliLiter,
        Gallon
    }

    /// <summary>
    /// Utility functions for converting and formatting VolumeUnit values.
    /// </summary>
    public static class VolumeUnitExtension
    {
        // Conversion multipliers relative to the base unit (Litre)
        private static readonly double[] litreScale =
        {
            1.0,       // Litre
            0.001,     // Milliliter
            3.78541    // Gallon
        };

        public static double GetConversionFactor(this VolumeUnit unitType)
        {
            int position = (int)unitType;
            return litreScale[position];
        }

        // Convert a given value to the base unit (Litre)
        public static double ConvertToBase(this VolumeUnit unitType, double amount)
        {
            double factor = unitType.GetConversionFactor();
            return amount * factor;
        }

        // Convert a base unit value back into the desired unit
        public static double ConvertFromBase(this VolumeUnit unitType, double baseAmount)
        {
            double factor = unitType.GetConversionFactor();
            return baseAmount / factor;
        }

        // Returns a short unit label used for display
        public static string GetSymbol(this VolumeUnit unitType)
        {
            switch (unitType)
            {
                case VolumeUnit.Litre:
                    return "L";

                case VolumeUnit.MilliLiter:
                    return "ML";

                case VolumeUnit.Gallon:
                    return "gal";

                default:
                    return unitType.ToString().ToLower();
            }
        }
    }
}
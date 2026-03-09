namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Represents the volume measurement units used in the system.
    /// The position of each value is important because it maps to the
    /// conversion factor stored in the array below.
    /// </summary>
    public enum VolumeUnit
    {
        Litre,        // position 0
        MilliLiter,   // position 1
        Gallon        // position 2
    }

    public static class VolumeUnitExtension
    {
        // Conversion values to convert a unit into litres
        private static readonly double[] conversionValues =
        {
            1.0,      // Litre
            0.001,    // Millilitre
            3.78541   // Gallon
        };

        /// <summary>
        /// Returns the factor required to convert a unit into litres.
        /// </summary>
        public static double GetConversionFactor(this VolumeUnit currentUnit)
        {
            int index = (int)currentUnit;
            return conversionValues[index];
        }

        // Converts a given value into the base unit (litre)
        public static double ConvertToBase(this VolumeUnit currentUnit, double inputAmount)
        {
            double factor = currentUnit.GetConversionFactor();
            double result = inputAmount * factor;
            return result;
        }

        // Converts a value from litre to the requested unit
        public static double ConvertFromBase(this VolumeUnit currentUnit, double litreValue)
        {
            double factor = currentUnit.GetConversionFactor();
            return litreValue / factor;
        }

        // Provides the display symbol for the unit
        public static string GetSymbol(this VolumeUnit currentUnit)
        {
            if (currentUnit == VolumeUnit.Litre)
                return "L";

            if (currentUnit == VolumeUnit.MilliLiter)
                return "ML";

            if (currentUnit == VolumeUnit.Gallon)
                return "gal";

            return currentUnit.ToString().ToLower();
        }
    }
}
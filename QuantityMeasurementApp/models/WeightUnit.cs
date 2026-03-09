namespace QuantityMeasurementApp.models
{
    public enum WeightUnit
    {
        Grams,      // Index 0
        Kilograms,  // Index 1
        Pound       // Index 2
    }

    /// <summary>
    /// Utility methods related to the WeightUnit enum.
    /// Handles conversion factors and formatting helpers.
    /// </summary>
    public static class WeightUnitExtension
    {
        // Conversion values relative to kilograms
        private static readonly double[] factorToKg =
        {
            0.001,     // grams
            1.0,       // kilograms
            0.453592   // pounds
        };

        // Returns the multiplier used to convert a unit into kilograms
        public static double GetConversionFactor(this WeightUnit unitType)
        {
            int index = (int)unitType;
            return factorToKg[index];
        }

        // Converts a given value into the base unit (kilograms)
        public static double ConvertToBase(this WeightUnit unitType, double inputValue)
        {
            double multiplier = unitType.GetConversionFactor();
            return inputValue * multiplier;
        }

        // Converts a value from kilograms back into the requested unit
        public static double ConvertFromBase(this WeightUnit unitType, double baseAmount)
        {
            double multiplier = unitType.GetConversionFactor();
            return baseAmount / multiplier;
        }

        // Provides a short symbol used when displaying the unit
        public static string GetSymbol(this WeightUnit unitType)
        {
            if (unitType == WeightUnit.Kilograms)
            {
                return "Kg";
            }
            else if (unitType == WeightUnit.Grams)
            {
                return "g";
            }
            else if (unitType == WeightUnit.Pound)
            {
                return "lb";
            }

            return unitType.ToString().ToLower();
        }
    }
}
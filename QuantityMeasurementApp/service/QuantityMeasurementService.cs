using System;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.service{
    /// <summary>
    /// Provides operations related to measurement comparisons.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Checks whether two Feet objects hold identical values.
        /// </summary>
        public bool AreFeetEqual(Feet firstValue, Feet secondValue)
        {
            if (firstValue is null || secondValue is null)
                throw new ArgumentNullException("Feet inputs cannot be null.");

            return firstValue.Equals(secondValue);
        }

        /// <summary>
        /// Checks whether two Inches objects hold identical values.
        /// </summary>
        public bool AreInchesEqual(Inches leftValue, Inches rightValue)
        {
            if (leftValue is null || rightValue is null)
                throw new ArgumentNullException("Inches inputs cannot be null.");

            return leftValue.Equals(rightValue);
        }
    }
}
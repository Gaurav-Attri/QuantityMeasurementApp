using System;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.service
{
    /// <summary>
    /// Handles comparison logic for measurement entities.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Determines whether two Feet instances represent the same value.
        /// </summary>
        public bool CompareFeet(Feet left, Feet right)
        {
            if (left is null || right is null)
                throw new ArgumentNullException("Feet objects cannot be null");

            return left.Equals(right);
        }
    }
}
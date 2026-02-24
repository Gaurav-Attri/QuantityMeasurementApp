using System;

namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Immutable representation of a length measured in feet.
    /// Supports equality comparison based on numeric value.
    /// </summary>
    public sealed class Feet
    {
        private readonly double _feetValue;

        /// <summary>
        /// Creates a new Feet instance with the given numeric length.
        /// </summary>
        public Feet(double measurement)
        {
            _feetValue = measurement;
        }

        /// <summary>
        /// Compares this instance with another object for value equality.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not Feet otherInstance)
                return false;

            if (ReferenceEquals(this, otherInstance))
                return true;

            return _feetValue.Equals(otherInstance._feetValue);
        }

        /// <summary>
        /// Generates a hash code derived from the numeric value.
        /// </summary>
        public override int GetHashCode() => _feetValue.GetHashCode();
    }
}
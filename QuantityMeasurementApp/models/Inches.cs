using System;

namespace QuantityMeasurementApp.models
{
    /// <summary>
    /// Immutable representation of a length expressed in inches.
    /// </summary>
    public sealed class Inches
    {
        private readonly double _inchMagnitude;

        /// <summary>
        /// Creates a new Inches instance with the provided numeric magnitude.
        /// </summary>
        public Inches(double magnitude)
        {
            _inchMagnitude = magnitude;
        }

        /// <summary>
        /// Determines equality based on numeric magnitude.
        /// </summary>
        public override bool Equals(object? candidate)
        {
            if (candidate is not Inches otherInstance)
                return false;

            if (ReferenceEquals(this, otherInstance))
                return true;

            return _inchMagnitude.Equals(otherInstance._inchMagnitude);
        }

        /// <summary>
        /// Generates a hash code derived from the stored magnitude.
        /// </summary>
        public override int GetHashCode() => _inchMagnitude.GetHashCode();
    }
}
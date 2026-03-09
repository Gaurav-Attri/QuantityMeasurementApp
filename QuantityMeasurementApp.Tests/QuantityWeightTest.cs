using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Test
{
    /// <summary>
    /// Test suite validating equality, conversion
    /// and addition behaviour for weight quantities.
    /// </summary>
    [TestClass]
    public class QuantityWeightTests
    {
        private const double tolerance = 0.001;

        // ------------------ COMPARISON TESTS ------------------

        [TestMethod]
        public void Equality_KgVsKg_SameValue()
        {
            QuantityWeight first = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight second = new QuantityWeight(1.0, WeightUnit.Kilograms);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equality_KgVsKg_DifferentValue()
        {
            QuantityWeight first = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight second = new QuantityWeight(2.0, WeightUnit.Kilograms);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equality_KgVsGram_Equivalent()
        {
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight gram = new QuantityWeight(1000.0, WeightUnit.Grams);

            Assert.IsTrue(kilo.Equals(gram));
        }

        [TestMethod]
        public void Equality_GramVsKg_Equivalent()
        {
            QuantityWeight gram = new QuantityWeight(1000.0, WeightUnit.Grams);
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);

            Assert.IsTrue(gram.Equals(kilo));
        }

        [TestMethod]
        public void Equality_WeightComparedWithLength()
        {
            QuantityWeight weight = new QuantityWeight(1.0, WeightUnit.Kilograms);
            Quantity length = new Quantity(1.0, LengthUnit.Feet);

            Assert.IsFalse(weight.Equals(length));
        }

        [TestMethod]
        public void Equality_WithNull()
        {
            QuantityWeight value = new QuantityWeight(1.0, WeightUnit.Kilograms);

            Assert.IsFalse(value.Equals(null));
        }

        [TestMethod]
        public void Equality_SameInstance()
        {
            QuantityWeight weight = new QuantityWeight(1.0, WeightUnit.Kilograms);

            Assert.IsTrue(weight.Equals(weight));
        }

        [TestMethod]
        public void Equality_ZeroWeight()
        {
            QuantityWeight first = new QuantityWeight(0.0, WeightUnit.Kilograms);
            QuantityWeight second = new QuantityWeight(0.0, WeightUnit.Grams);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equality_NegativeWeight()
        {
            QuantityWeight first = new QuantityWeight(-1.0, WeightUnit.Kilograms);
            QuantityWeight second = new QuantityWeight(-1000.0, WeightUnit.Grams);

            Assert.IsTrue(first.Equals(second));
        }

        // ------------------ CONVERSION TESTS ------------------

        [TestMethod]
        public void Convert_PoundToKilogram()
        {
            QuantityWeight poundValue = new QuantityWeight(2.20462, WeightUnit.Pound);

            QuantityWeight result = poundValue.ConvertTo(WeightUnit.Kilograms);

            Assert.AreEqual(1.0, result.amount, tolerance);
        }

        [TestMethod]
        public void Convert_KilogramToPound()
        {
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);

            QuantityWeight result = kilo.ConvertTo(WeightUnit.Pound);

            Assert.AreEqual(2.20462, result.amount, tolerance);
        }

        [TestMethod]
        public void Convert_SameUnit()
        {
            QuantityWeight initial = new QuantityWeight(5.0, WeightUnit.Kilograms);

            QuantityWeight converted = initial.ConvertTo(WeightUnit.Kilograms);

            Assert.AreEqual(5.0, converted.amount);
            Assert.AreEqual(WeightUnit.Kilograms, converted.unitType);
        }

        [TestMethod]
        public void Convert_RoundTrip()
        {
            QuantityWeight original = new QuantityWeight(1.5, WeightUnit.Kilograms);

            QuantityWeight result = original
                .ConvertTo(WeightUnit.Grams)
                .ConvertTo(WeightUnit.Kilograms);

            Assert.AreEqual(1.5, result.amount, tolerance);
        }

        // ------------------ ADDITION TESTS ------------------

        [TestMethod]
        public void Addition_KgPlusKg()
        {
            QuantityWeight first = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight second = new QuantityWeight(2.0, WeightUnit.Kilograms);

            QuantityWeight total = first.Add(second);

            Assert.AreEqual(3.0, total.amount);
            Assert.AreEqual(WeightUnit.Kilograms, total.unitType);
        }

        [TestMethod]
        public void Addition_KgPlusGram()
        {
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight gram = new QuantityWeight(1000.0, WeightUnit.Grams);

            QuantityWeight total = kilo.Add(gram);

            Assert.AreEqual(2.0, total.amount);
        }

        [TestMethod]
        public void Addition_PoundPlusKilogram()
        {
            QuantityWeight pound = new QuantityWeight(2.20462, WeightUnit.Pound);
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);

            QuantityWeight total = pound.Add(kilo);

            Assert.AreEqual(4.40924, total.amount, tolerance);
        }

        [TestMethod]
        public void Addition_TargetUnitGram()
        {
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight gram = new QuantityWeight(1000.0, WeightUnit.Grams);

            QuantityWeight total = kilo.Add(gram, WeightUnit.Grams);

            Assert.AreEqual(2000.0, total.amount);
            Assert.AreEqual(WeightUnit.Grams, total.unitType);
        }

        [TestMethod]
        public void Addition_CommutativeCheck()
        {
            QuantityWeight kilo = new QuantityWeight(1.0, WeightUnit.Kilograms);
            QuantityWeight gram = new QuantityWeight(1000.0, WeightUnit.Grams);

            QuantityWeight result1 = kilo.Add(gram, WeightUnit.Kilograms);
            QuantityWeight result2 = gram.Add(kilo, WeightUnit.Kilograms);

            Assert.AreEqual(result1.amount, result2.amount, tolerance);
        }

        [TestMethod]
        public void Addition_WithZeroWeight()
        {
            QuantityWeight value = new QuantityWeight(5.0, WeightUnit.Kilograms);
            QuantityWeight zero = new QuantityWeight(0.0, WeightUnit.Grams);

            QuantityWeight result = value.Add(zero);

            Assert.AreEqual(5.0, result.amount);
        }
    }
}
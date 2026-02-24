using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class FeetEqualityValidationTests
    {
        [TestMethod]
        public void DifferentNumericValues_ShouldNotMatch()
        {
            Feet expected = new Feet(5.5);
            Feet actual = new Feet(8.2);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void IdenticalNumericValues_ShouldMatch()
        {
            Feet expected = new Feet(3.3);
            Feet actual = new Feet(3.3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComparingWithNull_ShouldReturnFalse()
        {
            Feet actual = new Feet(10.0);

            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public void SameInstanceReference_ShouldBeSameObject()
        {
            Feet expected = new Feet(7.7);
            Feet actual = expected;

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void MatchingNegativeNumbers_ShouldBeEqual()
        {
            Feet expected = new Feet(-12.4);
            Feet actual = new Feet(-12.4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LargeEquivalentValues_ShouldBeEqual()
        {
            Feet expected = new Feet(12345678);
            Feet actual = new Feet(12345678);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LargeDifferentValues_ShouldNotBeEqual()
        {
            Feet notExpected = new Feet(44444444);
            Feet actual = new Feet(99999999);

            Assert.AreNotEqual(notExpected, actual);
        }
    }
}
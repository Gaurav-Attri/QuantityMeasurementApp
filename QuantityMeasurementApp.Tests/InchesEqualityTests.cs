using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    /// <summary>
    /// Validates equality behavior of the Inches entity.
    /// </summary>
    [TestClass]
    public class InchesEqualityTests
    {
        [TestMethod]
        public void DistinctValues_ShouldReturnFalse()
        {
            Inches expected = new Inches(4.5);
            Inches actual = new Inches(9.1);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void IdenticalValues_ShouldReturnTrue()
        {
            Inches expected = new Inches(6.6);
            Inches actual = new Inches(6.6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComparingWithNull_ShouldBeFalse()
        {
            Inches actual = new Inches(12.3);

            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public void SameReference_ShouldBeSameInstance()
        {
            Inches expected = new Inches(2.2);
            Inches actual = expected;

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void EqualNegativeNumbers_ShouldMatch()
        {
            Inches expected = new Inches(-7.8);
            Inches actual = new Inches(-7.8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DifferentNegativeNumbers_ShouldNotMatch()
        {
            Inches expected = new Inches(-15.0);
            Inches actual = new Inches(-22.0);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void VeryLargeMatchingNumbers_ShouldMatch()
        {
            Inches expected = new Inches(5555555555);
            Inches actual = new Inches(5555555555);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VeryLargeDifferentNumbers_ShouldNotMatch()
        {
            Inches notExpected = new Inches(8888888888);
            Inches actual = new Inches(1111111111);

            Assert.AreNotEqual(notExpected, actual);
        }
    }
}
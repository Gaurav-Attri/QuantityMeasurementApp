using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityTest
    {
        // test two equal quantities with different unit
        [TestMethod]
        public void GivenOneFeetAndTwelveInches_WhenCompared_ReturnTrue()
        {
            Quantity feet = new Quantity(1.0, LengthUnit.Feet);
            Quantity inches = new Quantity(12.0, LengthUnit.Inches);

            Assert.AreEqual(feet, inches);
        }

        // test two equal quantities with different unit
        [TestMethod]
        public void GivenTwelveInchesAndOneFeet_WhenCompared_ReturnTrue()
        {
            Quantity inches = new Quantity(12.0, LengthUnit.Inches);
            Quantity feet = new Quantity(1.0, LengthUnit.Feet);

            Assert.AreEqual(inches, feet);
        }

        // test two unequal quantities with same unit
        [TestMethod]
        public void GivenOneFeetAndTwoFeet_WhenCompared_ReturnFalse()
        {
            Quantity feet1 = new Quantity(1.0, LengthUnit.Feet);
            Quantity feet2 = new Quantity(2.0, LengthUnit.Feet);

            Assert.AreNotEqual(feet1, feet2);
        }

        // test same quantity and compare to itself
        [TestMethod]
        public void GivenQuantityObject_WhenComparedToSelf_ShouldReturnTrue()
        {
            Quantity feet = new Quantity(1.0, LengthUnit.Feet);

            Assert.IsTrue(feet.Equals(feet));
        }

        // test with null
        [TestMethod]
        public void GivenQuantityObject_WhenComparedWithNull_ShouldReturnFalse()
        {
            Quantity feet = new Quantity(1.0, LengthUnit.Feet);

            Assert.IsFalse(feet.Equals(null));
        }

        // compare zero inches with zero feet
        [TestMethod]
        public void GivenZeroFeetAndZeroInches_WhenCompared_ShouldReturnTrue()
        {
            Quantity zeroFeet = new Quantity(0.0, LengthUnit.Feet);
            Quantity zeroInches = new Quantity(0.0, LengthUnit.Inches);

            Assert.AreEqual(zeroFeet, zeroInches);
        }
    }
}
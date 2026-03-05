using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Unit tests to verify equality of quantities
/// across different measurement units.
/// </summary>
[TestClass]
public class QuantityTest
{

    // checks if 1 foot equals 12 inches
    [TestMethod]
    public void GivenOneFootAndTwelveInches_WhenCompared_ShouldBeEqual()
    {
        Quantity footValue = new Quantity(1.0, LengthUnit.Feet);
        Quantity inchValue = new Quantity(12.0, LengthUnit.Inches);

        Assert.AreEqual(footValue, inchValue);
    }

    // verifies comparison when order is reversed
    [TestMethod]
    public void GivenTwelveInchesAndOneFoot_WhenCompared_ShouldBeEqual()
    {
        Quantity inchAmount = new Quantity(12.0, LengthUnit.Inches);
        Quantity footAmount = new Quantity(1.0, LengthUnit.Feet);

        Assert.AreEqual(inchAmount, footAmount);
    }

    // verifies unequal values with same unit
    [TestMethod]
    public void GivenOneFootAndTwoFeet_WhenCompared_ShouldReturnFalse()
    {
        Quantity firstFoot = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondFoot = new Quantity(2.0, LengthUnit.Feet);

        Assert.AreNotEqual(firstFoot, secondFoot);
    }

    // comparing object with itself
    [TestMethod]
    public void GivenQuantityObject_WhenComparedWithItself_ShouldReturnTrue()
    {
        Quantity sampleFeet = new Quantity(1.0, LengthUnit.Feet);

        Assert.IsTrue(sampleFeet.Equals(sampleFeet));
    }

    // comparison with null
    [TestMethod]
    public void GivenQuantityObject_WhenComparedWithNull_ShouldReturnFalse()
    {
        Quantity sampleFeet = new Quantity(1.0, LengthUnit.Feet);

        Assert.AreNotEqual(sampleFeet, null);
    }

    // check zero values across units
    [TestMethod]
    public void GivenZeroFeetAndZeroInches_WhenCompared_ShouldReturnTrue()
    {
        Quantity feetZero = new Quantity(0.0, LengthUnit.Feet);
        Quantity inchesZero = new Quantity(0.0, LengthUnit.Inches);

        Assert.AreEqual(feetZero, inchesZero);
    }

    // 1 yard should equal 3 feet
    [TestMethod]
    public void GivenOneYardAndThreeFeet_WhenCompared_ShouldReturnTrue()
    {
        Quantity yardValue = new Quantity(1.0, LengthUnit.Yards);
        Quantity feetValue = new Quantity(3.0, LengthUnit.Feet);

        Assert.AreEqual(yardValue, feetValue);
    }

    // 1 yard equals 36 inches
    [TestMethod]
    public void GivenOneYardAndThirtySixInches_WhenCompared_ShouldReturnTrue()
    {
        Quantity yardLength = new Quantity(1.0, LengthUnit.Yards);
        Quantity inchLength = new Quantity(36.0, LengthUnit.Inches);

        Assert.AreEqual(yardLength, inchLength);
    }

    // centimeter and inch comparison
    [TestMethod]
    public void GivenOneCentimeterAndPoint3937Inches_WhenCompared_ShouldReturnTrue()
    {
        Quantity centimeterValue = new Quantity(1.0, LengthUnit.Centimeters);
        Quantity inchEquivalent = new Quantity(0.393701, LengthUnit.Inches);

        Assert.AreEqual(centimeterValue, inchEquivalent);
    }

    // testing transitive equality property
    [TestMethod]
    public void EqualityCheck_MultipleUnits_TransitiveProperty()
    {
        Quantity yardMeasure = new Quantity(1.0, LengthUnit.Yards);
        Quantity feetMeasure = new Quantity(3.0, LengthUnit.Feet);
        Quantity inchesMeasure = new Quantity(36.0, LengthUnit.Inches);

        Assert.AreEqual(yardMeasure, feetMeasure);
        Assert.AreEqual(feetMeasure, inchesMeasure);
        Assert.AreEqual(yardMeasure, inchesMeasure);
    }

    [TestMethod]
    public void CompareYardToYard_SameValue_ShouldReturnTrue()
    {
        Quantity firstYard = new Quantity(1.0, LengthUnit.Yards);
        Quantity secondYard = new Quantity(1.0, LengthUnit.Yards);

        Assert.AreEqual(firstYard, secondYard);
    }

    [TestMethod]
    public void CompareYardToYard_DifferentValue_ShouldReturnFalse()
    {
        Quantity firstYard = new Quantity(1.0, LengthUnit.Yards);
        Quantity secondYard = new Quantity(2.0, LengthUnit.Yards);

        Assert.AreNotEqual(firstYard, secondYard);
    }

    [TestMethod]
    public void EqualityAcrossUnits_ComplexScenario()
    {
        // example: 2 yards = 6 feet = 72 inches
        Quantity yardData = new Quantity(2.0, LengthUnit.Yards);
        Quantity feetData = new Quantity(6.0, LengthUnit.Feet);
        Quantity inchData = new Quantity(72.0, LengthUnit.Inches);

        Assert.AreEqual(yardData, feetData);
        Assert.AreEqual(feetData, inchData);
        Assert.AreEqual(yardData, inchData);
    }
}
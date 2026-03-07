using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Tests to verify equality logic between quantities across different units.
/// </summary>
[TestClass]
public class QuantityTest
{

    // verify 1 foot equals 12 inches
    [TestMethod]
    public void Compare_Feet_And_Inches_ShouldReturnTrue()
    {
        Quantity first = new Quantity(1.0, LengthUnit.Feet);
        Quantity second = new Quantity(12.0, LengthUnit.Inches);

        Assert.AreEqual(first, second);
    }

    // verify reverse comparison also works
    [TestMethod]
    public void Compare_Inches_And_Feet_ShouldReturnTrue()
    {
        Quantity qA = new Quantity(12.0, LengthUnit.Inches);
        Quantity qB = new Quantity(1.0, LengthUnit.Feet);

        Assert.AreEqual(qA, qB);
    }

    // compare unequal quantities in same unit
    [TestMethod]
    public void Compare_DifferentFeetValues_ShouldReturnFalse()
    {
        Quantity value1 = new Quantity(1.0, LengthUnit.Feet);
        Quantity value2 = new Quantity(2.0, LengthUnit.Feet);

        Assert.AreNotEqual(value1, value2);
    }

    // comparing object with itself should be true
    [TestMethod]
    public void Compare_Object_With_Itself_ShouldReturnTrue()
    {
        Quantity item = new Quantity(1.0, LengthUnit.Feet);

        Assert.IsTrue(item.Equals(item));
    }

    // comparing with null should return false
    [TestMethod]
    public void Compare_Object_With_Null_ShouldReturnFalse()
    {
        Quantity element = new Quantity(1.0, LengthUnit.Feet);

        Assert.AreNotEqual(element, null);
    }

    // check zero values across units
    [TestMethod]
    public void Compare_ZeroFeet_And_ZeroInches_ShouldReturnTrue()
    {
        Quantity zeroA = new Quantity(0.0, LengthUnit.Feet);
        Quantity zeroB = new Quantity(0.0, LengthUnit.Inches);

        Assert.AreEqual(zeroA, zeroB);
    }

    // verify yard and feet equality
    [TestMethod]
    public void Compare_Yard_And_Feet_ShouldReturnTrue()
    {
        Quantity yardValue = new Quantity(1.0, LengthUnit.Yards);
        Quantity feetValue = new Quantity(3.0, LengthUnit.Feet);

        Assert.AreEqual(yardValue, feetValue);
    }

    // verify yard and inches equality
    [TestMethod]
    public void Compare_Yard_And_Inches_ShouldReturnTrue()
    {
        Quantity yardValue = new Quantity(1.0, LengthUnit.Yards);
        Quantity inchValue = new Quantity(36.0, LengthUnit.Inches);

        Assert.AreEqual(yardValue, inchValue);
    }

    // centimeter to inch comparison
    [TestMethod]
    public void Compare_Cm_And_Inches_ShouldReturnTrue()
    {
        Quantity cmValue = new Quantity(1.0, LengthUnit.Centimeters);
        Quantity inchValue = new Quantity(0.393701, LengthUnit.Inches);

        Assert.AreEqual(cmValue, inchValue);
    }

    // transitive equality check
    [TestMethod]
    public void Equality_TransitiveAcrossUnits()
    {
        Quantity yard = new Quantity(1.0, LengthUnit.Yards);
        Quantity feet = new Quantity(3.0, LengthUnit.Feet);
        Quantity inches = new Quantity(36.0, LengthUnit.Inches);

        Assert.AreEqual(yard, feet);
        Assert.AreEqual(feet, inches);
        Assert.AreEqual(yard, inches);
    }

    // equal yard values
    [TestMethod]
    public void Compare_SameYardValues_ShouldReturnTrue()
    {
        Quantity y1 = new Quantity(1.0, LengthUnit.Yards);
        Quantity y2 = new Quantity(1.0, LengthUnit.Yards);

        Assert.AreEqual(y1, y2);
    }

    // unequal yard values
    [TestMethod]
    public void Compare_DifferentYardValues_ShouldReturnFalse()
    {
        Quantity y1 = new Quantity(1.0, LengthUnit.Yards);
        Quantity y2 = new Quantity(2.0, LengthUnit.Yards);

        Assert.AreNotEqual(y1, y2);
    }

    // complex equality across three units
    [TestMethod]
    public void Compare_MultipleUnitScenario_ShouldMatch()
    {
        Quantity item1 = new Quantity(2.0, LengthUnit.Yards);
        Quantity item2 = new Quantity(6.0, LengthUnit.Feet);
        Quantity item3 = new Quantity(72.0, LengthUnit.Inches);

        Assert.AreEqual(item1, item2);
        Assert.AreEqual(item2, item3);
        Assert.AreEqual(item1, item3);
    }
}
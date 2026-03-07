using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Tests verifying addition behaviour between quantities with different units.
/// </summary>
[TestClass]
public class QuantityAdditionTest
{
    [TestMethod]
    public void Add_Feet_To_Feet_ShouldReturnSum()
    {
        Quantity firstValue = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondValue = new Quantity(2.0, LengthUnit.Feet);

        Quantity result = firstValue.Add(secondValue);

        Assert.AreEqual(new Quantity(3.0, LengthUnit.Feet), result);
    }

    [TestMethod]
    public void Add_Inches_To_Inches_ShouldReturnCorrectValue()
    {
        Quantity numberA = new Quantity(6.0, LengthUnit.Inches);
        Quantity numberB = new Quantity(6.0, LengthUnit.Inches);

        Quantity output = numberA.Add(numberB);

        Assert.AreEqual(new Quantity(12.0, LengthUnit.Inches), output);
    }

    [TestMethod]
    public void Add_Feet_And_Inches_ShouldReturnFeetResult()
    {
        Quantity left = new Quantity(1.0, LengthUnit.Feet);
        Quantity right = new Quantity(12.0, LengthUnit.Inches);

        Quantity result = left.Add(right);

        Assert.AreEqual(new Quantity(2.0, LengthUnit.Feet), result);
    }

    [TestMethod]
    public void Add_Inches_And_Feet_ShouldReturnInchesResult()
    {
        Quantity first = new Quantity(12.0, LengthUnit.Inches);
        Quantity second = new Quantity(1.0, LengthUnit.Feet);

        Quantity sum = first.Add(second);

        Assert.AreEqual(new Quantity(24.0, LengthUnit.Inches), sum);
    }

    [TestMethod]
    public void Add_Yards_And_Feet_ShouldReturnYards()
    {
        Quantity yardValue = new Quantity(1.0, LengthUnit.Yards);
        Quantity feetValue = new Quantity(3.0, LengthUnit.Feet);

        Quantity total = yardValue.Add(feetValue);

        Assert.AreEqual(new Quantity(2.0, LengthUnit.Yards), total);
    }

    [TestMethod]
    public void Add_Centimeters_And_Inches_ShouldReturnCentimeters()
    {
        Quantity cmValue = new Quantity(2.54, LengthUnit.Centimeters);
        Quantity inchValue = new Quantity(1.0, LengthUnit.Inches);

        Quantity result = cmValue.Add(inchValue);

        Assert.AreEqual(new Quantity(5.08, LengthUnit.Centimeters), result);
    }

    [TestMethod]
    public void Addition_ShouldBeCommutativeAcrossUnits()
    {
        Quantity firstItem = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondItem = new Quantity(12.0, LengthUnit.Inches);

        Quantity resultA = firstItem.Add(secondItem);
        Quantity resultB = secondItem.Add(firstItem);

        Assert.AreEqual(resultA, resultB);
    }

    [TestMethod]
    public void Addition_WithZero_ShouldReturnOriginalValue()
    {
        Quantity mainValue = new Quantity(5.0, LengthUnit.Feet);
        Quantity zeroValue = new Quantity(0.0, LengthUnit.Inches);

        Quantity sum = mainValue.Add(zeroValue);

        Assert.AreEqual(new Quantity(5.0, LengthUnit.Feet), sum);
    }

    [TestMethod]
    public void Addition_WithNegativeNumber_ShouldWorkCorrectly()
    {
        Quantity positive = new Quantity(5.0, LengthUnit.Feet);
        Quantity negative = new Quantity(-2.0, LengthUnit.Feet);

        Quantity result = positive.Add(negative);

        Assert.AreEqual(new Quantity(3.0, LengthUnit.Feet), result);
    }

    [TestMethod]
    public void Addition_WithNullOperand_ShouldThrowException()
    {
        Quantity value = new Quantity(1.0, LengthUnit.Feet);

        bool exceptionThrown = false;

        try
        {
            value.Add(null!);
        }
        catch (ArgumentNullException)
        {
            exceptionThrown = true;
        }

        Assert.IsTrue(exceptionThrown);
    }

    [TestMethod]
    public void Addition_WithLargeNumbers_ShouldWork()
    {
        Quantity big1 = new Quantity(1e6, LengthUnit.Feet);
        Quantity big2 = new Quantity(1e6, LengthUnit.Feet);

        Quantity result = big1.Add(big2);

        Assert.AreEqual(new Quantity(2e6, LengthUnit.Feet), result);
    }

    [TestMethod]
    public void Addition_WithSmallNumbers_ShouldWork()
    {
        Quantity small1 = new Quantity(0.001, LengthUnit.Feet);
        Quantity small2 = new Quantity(0.002, LengthUnit.Feet);

        Quantity result = small1.Add(small2);

        Assert.AreEqual(new Quantity(0.003, LengthUnit.Feet), result);
    }
}
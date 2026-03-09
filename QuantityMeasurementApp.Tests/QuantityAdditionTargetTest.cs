using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Tests verifying addition of quantities when the caller
/// explicitly chooses the unit of the result.
/// </summary>
[TestClass]
public class QuantityAdditionTargetTest
{
    [TestMethod]
    public void Addition_WithTargetFeet_ShouldReturnCorrectValue()
    {
        Quantity firstMeasure = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondMeasure = new Quantity(12.0, LengthUnit.Inches);

        Quantity output = firstMeasure.Add(secondMeasure, LengthUnit.Feet);

        Assert.AreEqual(new Quantity(2.0, LengthUnit.Feet), output);
    }

    [TestMethod]
    public void Addition_WithTargetInches_ShouldReturnCorrectValue()
    {
        Quantity firstMeasure = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondMeasure = new Quantity(12.0, LengthUnit.Inches);

        Quantity output = firstMeasure.Add(secondMeasure, LengthUnit.Inches);

        Assert.AreEqual(new Quantity(24.0, LengthUnit.Inches), output);
    }

    [TestMethod]
    public void Addition_WithTargetYards_ShouldProduceExpectedResult()
    {
        Quantity firstValue = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondValue = new Quantity(12.0, LengthUnit.Inches);

        Quantity resultQuantity = firstValue.Add(secondValue, LengthUnit.Yards);

        Assert.AreEqual(0.667, resultQuantity.amount, 0.001);
        Assert.AreEqual(LengthUnit.Yards, resultQuantity.lengthType);
    }

    [TestMethod]
    public void Addition_WithTargetCentimeters_ShouldWorkCorrectly()
    {
        Quantity firstValue = new Quantity(1.0, LengthUnit.Inches);
        Quantity secondValue = new Quantity(1.0, LengthUnit.Inches);

        Quantity output = firstValue.Add(secondValue, LengthUnit.Centimeters);

        Assert.AreEqual(5.08, output.amount, 0.001);
        Assert.AreEqual(LengthUnit.Centimeters, output.lengthType);
    }

    [TestMethod]
    public void Addition_TargetMatchesFirstOperandUnit()
    {
        Quantity left = new Quantity(2.0, LengthUnit.Yards);
        Quantity right = new Quantity(3.0, LengthUnit.Feet);

        Quantity result = left.Add(right, LengthUnit.Yards);

        Assert.AreEqual(new Quantity(3.0, LengthUnit.Yards), result);
    }

    [TestMethod]
    public void Addition_TargetMatchesSecondOperandUnit()
    {
        Quantity left = new Quantity(2.0, LengthUnit.Yards);
        Quantity right = new Quantity(3.0, LengthUnit.Feet);

        Quantity result = left.Add(right, LengthUnit.Feet);

        Assert.AreEqual(new Quantity(9.0, LengthUnit.Feet), result);
    }

    [TestMethod]
    public void Addition_CommutativeProperty_ShouldHold()
    {
        Quantity first = new Quantity(2.0, LengthUnit.Yards);
        Quantity second = new Quantity(3.0, LengthUnit.Feet);

        Quantity res1 = first.Add(second, LengthUnit.Yards);
        Quantity res2 = second.Add(first, LengthUnit.Yards);

        Assert.AreEqual(res1.amount, res2.amount);
        Assert.AreEqual(res1.lengthType, res2.lengthType);
    }

    [TestMethod]
    public void Addition_WithZeroOperand_ShouldRemainSame()
    {
        Quantity baseValue = new Quantity(5.0, LengthUnit.Feet);
        Quantity zeroValue = new Quantity(0.0, LengthUnit.Inches);

        Quantity output = baseValue.Add(zeroValue, LengthUnit.Yards);

        Assert.AreEqual(1.667, output.amount, 0.001);
        Assert.AreEqual(LengthUnit.Yards, output.lengthType);
    }

    [TestMethod]
    public void Addition_WithNegativeValues_ShouldWork()
    {
        Quantity firstValue = new Quantity(5.0, LengthUnit.Feet);
        Quantity secondValue = new Quantity(-2.0, LengthUnit.Feet);

        Quantity result = firstValue.Add(secondValue, LengthUnit.Inches);

        Assert.AreEqual(new Quantity(36.0, LengthUnit.Inches), result);
    }

    [TestMethod]
    public void Addition_LargeScaleUnits_ShouldConvertCorrectly()
    {
        Quantity bigValue = new Quantity(1000.0, LengthUnit.Feet);
        Quantity anotherValue = new Quantity(500.0, LengthUnit.Feet);

        Quantity result = bigValue.Add(anotherValue, LengthUnit.Inches);

        Assert.AreEqual(new Quantity(18000.0, LengthUnit.Inches), result);
    }

    [TestMethod]
    public void Addition_SmallUnitsConvertedToLargeUnit()
    {
        Quantity a = new Quantity(12.0, LengthUnit.Inches);
        Quantity b = new Quantity(12.0, LengthUnit.Inches);

        Quantity output = a.Add(b, LengthUnit.Yards);

        Assert.AreEqual(0.667, output.amount, 0.001);
        Assert.AreEqual(LengthUnit.Yards, output.lengthType);
    }

    [DataTestMethod]
    [DataRow(1.0, 1, 12.0, 0, 1, 2.0)]
    [DataRow(1.0, 1, 12.0, 0, 0, 24.0)]
    [DataRow(1.0, 1, 12.0, 0, 2, 0.667)]
    [DataRow(1.0, 0, 2.54, 3, 0, 2.0)]
    [DataRow(1.0, 0, 1.0, 0, 3, 5.08)]
    [DataRow(1.0, 2, 3.0, 1, 2, 2.0)]
    public void Addition_AllUnitCases_ShouldMatchExpected(
        double firstValue,
        int firstUnit,
        double secondValue,
        int secondUnit,
        int targetUnit,
        double expectedResult)
    {
        LengthUnit unitA = (LengthUnit)firstUnit;
        LengthUnit unitB = (LengthUnit)secondUnit;
        LengthUnit desiredUnit = (LengthUnit)targetUnit;

        Quantity firstQuantity = new Quantity(firstValue, unitA);
        Quantity secondQuantity = new Quantity(secondValue, unitB);

        Quantity output = firstQuantity.Add(secondQuantity, desiredUnit);

        Assert.AreEqual(desiredUnit, output.lengthType);
        Assert.AreEqual(expectedResult, output.amount, 0.001);
    }

    [TestMethod]
    public void Addition_PrecisionCheck_WhenConvertingFromCentimeters()
    {
        Quantity first = new Quantity(30.48, LengthUnit.Centimeters);
        Quantity second = new Quantity(30.48, LengthUnit.Centimeters);

        Quantity result = first.Add(second, LengthUnit.Feet);

        Assert.AreEqual(2.0, result.amount, 0.001);
    }
}
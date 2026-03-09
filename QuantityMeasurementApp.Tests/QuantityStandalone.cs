using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Unit tests that validate the behavior of LengthUnit conversions
/// and Quantity operations independently.
/// </summary>
[TestClass]
public class QuantityStandalone
{
    [TestMethod]
    public void VerifyFeetConversionFactor()
    {
        double conversion = LengthUnit.Feet.GetConversionFactor();

        Assert.AreEqual(12.0, conversion);
    }

    [TestMethod]
    public void VerifyInchesConversionFactor()
    {
        double conversion = LengthUnit.Inches.GetConversionFactor();

        Assert.AreEqual(1.0, conversion);
    }

    [TestMethod]
    public void VerifyYardsConversionFactor()
    {
        double conversion = LengthUnit.Yards.GetConversionFactor();

        Assert.AreEqual(36.0, conversion);
    }

    [TestMethod]
    public void VerifyCentimeterConversionFactor()
    {
        double conversion = LengthUnit.Centimeters.GetConversionFactor();

        Assert.AreEqual(0.393701, conversion);
    }

    [TestMethod]
    public void ConvertInchesToBaseUnit_ShouldRemainSame()
    {
        double resultValue = LengthUnit.Inches.ConvertToBase(5.0);

        Assert.AreEqual(5.0, resultValue);
    }

    [TestMethod]
    public void ConvertFeetIntoBaseUnit_ShouldReturnInches()
    {
        double resultValue = LengthUnit.Feet.ConvertToBase(1.0);

        Assert.AreEqual(12.0, resultValue);
    }

    [TestMethod]
    public void ConvertYardsIntoBaseUnit_ShouldReturnInches()
    {
        double resultValue = LengthUnit.Yards.ConvertToBase(1.0);

        Assert.AreEqual(36.0, resultValue);
    }

    [TestMethod]
    public void ConvertCentimeterIntoBaseUnit()
    {
        double converted = LengthUnit.Centimeters.ConvertToBase(2.54);

        Assert.AreEqual(1.0, converted, 0.01);
    }

    [TestMethod]
    public void ConvertBaseToBase_ShouldRemainUnchanged()
    {
        double resultValue = LengthUnit.Inches.ConvertToBase(1.0);

        Assert.AreEqual(1.0, resultValue);
    }

    [TestMethod]
    public void ConvertFromBase_InchesToFeet()
    {
        double resultValue = LengthUnit.Feet.ConvertFromBase(12.0);

        Assert.AreEqual(1.0, resultValue);
    }

    [TestMethod]
    public void ConvertFromBase_InchesToYards()
    {
        double resultValue = LengthUnit.Yards.ConvertFromBase(36.0);

        Assert.AreEqual(1.0, resultValue);
    }

    [TestMethod]
    public void ConvertFromBase_InchesToCentimeters()
    {
        double converted = LengthUnit.Centimeters.ConvertFromBase(1.0);

        Assert.AreEqual(2.54, converted, 0.001);
    }

    [TestMethod]
    public void QuantityObjects_WithEquivalentValues_ShouldBeEqual()
    {
        Quantity firstMeasurement = new Quantity(1.0, LengthUnit.Feet);
        Quantity secondMeasurement = new Quantity(12.0, LengthUnit.Inches);

        Assert.AreEqual(firstMeasurement, secondMeasurement);
    }

    [TestMethod]
    public void QuantityConversion_FromFeetToInches()
    {
        Quantity original = new Quantity(1.0, LengthUnit.Feet);

        Quantity converted = original.ConvertTo(LengthUnit.Inches);

        Assert.AreEqual(new Quantity(12.0, LengthUnit.Inches), converted);
    }
}
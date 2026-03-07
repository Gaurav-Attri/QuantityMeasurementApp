using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Tests to confirm that unit conversion between different measurements works correctly.
/// </summary>
[TestClass]
public class QuantityConversionTest
{

    // verify feet to inches conversion
    [TestMethod]
    public void Convert_Feet_To_Inches_ShouldReturn12()
    {
        double resultValue = Quantity.ConvertValue(1.0, LengthUnit.Feet, LengthUnit.Inches);

        Assert.AreEqual(12.0, resultValue);
    }

    // verify inches to feet conversion
    [TestMethod]
    public void Convert_Inches_To_Feet_ShouldReturn2()
    {
        double converted = Quantity.ConvertValue(24.0, LengthUnit.Inches, LengthUnit.Feet);

        Assert.AreEqual(2.0, converted);
    }

    // verify yards to inches conversion
    [TestMethod]
    public void Convert_Yards_To_Inches_ShouldReturn36()
    {
        double output = Quantity.ConvertValue(1.0, LengthUnit.Yards, LengthUnit.Inches);

        Assert.AreEqual(36.0, output);
    }

    // verify inches to yards conversion
    [TestMethod]
    public void Convert_Inches_To_Yards_ShouldReturn2()
    {
        double answer = Quantity.ConvertValue(72.0, LengthUnit.Inches, LengthUnit.Yards);

        Assert.AreEqual(2.0, answer);
    }

    // centimeter to inch conversion with tolerance
    [TestMethod]
    public void Convert_Centimeter_To_Inches_ShouldBeApproximatelyOne()
    {
        double value = Quantity.ConvertValue(2.54, LengthUnit.Centimeters, LengthUnit.Inches);

        Assert.AreEqual(1.0, value, 0.001);
    }

    // feet to yards conversion
    [TestMethod]
    public void Convert_Feet_To_Yards_ShouldReturn2()
    {
        double result = Quantity.ConvertValue(6.0, LengthUnit.Feet, LengthUnit.Yards);

        Assert.AreEqual(2.0, result);
    }

    // conversion of zero value
    [TestMethod]
    public void Convert_ZeroValue_ShouldRemainZero()
    {
        double output = Quantity.ConvertValue(0.0, LengthUnit.Feet, LengthUnit.Inches);

        Assert.AreEqual(0.0, output);
    }

    // negative value conversion
    [TestMethod]
    public void Convert_NegativeFeet_ToInches_ShouldReturnNegative12()
    {
        double convertedNumber = Quantity.ConvertValue(-1.0, LengthUnit.Feet, LengthUnit.Inches);

        Assert.AreEqual(-12.0, convertedNumber);
    }

    // round trip conversion check
    [TestMethod]
    public void Conversion_RoundTrip_ShouldReturnOriginalNumber()
    {
        double startValue = 100.0;
        LengthUnit firstUnit = LengthUnit.Yards;
        LengthUnit secondUnit = LengthUnit.Inches;

        double stepOne = Quantity.ConvertValue(startValue, firstUnit, secondUnit);
        double stepTwo = Quantity.ConvertValue(stepOne, secondUnit, firstUnit);

        Assert.AreEqual(startValue, stepTwo);
    }
}
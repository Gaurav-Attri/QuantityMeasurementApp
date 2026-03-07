using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.models;

/// <summary>
/// Tests that verify whether unit conversion is working correctly.
/// </summary>
[TestClass]
public class QuantityConversionTest
{
    // Verify conversion from feet to inches
    [TestMethod]
    public void Convert_Feet_To_Inches_ShouldReturn12()
    {
        double resultValue = Quantity.ConvertValue(1.0, LengthUnit.Feet, LengthUnit.Inches);

        Assert.AreEqual(12.0, resultValue);
    }

    // Verify conversion from inches to feet
    [TestMethod]
    public void Convert_Inches_To_Feet_ShouldReturn2()
    {
        double output = Quantity.ConvertValue(24.0, LengthUnit.Inches, LengthUnit.Feet);

        Assert.AreEqual(2.0, output);
    }

    // Check yard to inches conversion
    [TestMethod]
    public void Convert_Yards_To_Inches_ShouldReturn36()
    {
        double converted = Quantity.ConvertValue(1.0, LengthUnit.Yards, LengthUnit.Inches);

        Assert.AreEqual(36.0, converted);
    }

    // Check inches to yard conversion
    [TestMethod]
    public void Convert_Inches_To_Yards_ShouldReturn2()
    {
        double conversionResult = Quantity.ConvertValue(72.0, LengthUnit.Inches, LengthUnit.Yards);

        Assert.AreEqual(2.0, conversionResult);
    }

    // Validate centimeter to inch conversion with floating precision tolerance
    [TestMethod]
    public void Convert_Centimeter_To_Inches_ShouldBeApproximately1()
    {
        double answer = Quantity.ConvertValue(2.54, LengthUnit.Centimeters, LengthUnit.Inches);

        Assert.AreEqual(1.0, answer, 0.001);
    }

    // Verify feet to yard conversion
    [TestMethod]
    public void Convert_Feet_To_Yards_ShouldReturn2()
    {
        double yardValue = Quantity.ConvertValue(6.0, LengthUnit.Feet, LengthUnit.Yards);

        Assert.AreEqual(2.0, yardValue);
    }

    // Ensure zero value conversion remains zero
    [TestMethod]
    public void Convert_ZeroValue_ShouldRemainZero()
    {
        double result = Quantity.ConvertValue(0.0, LengthUnit.Feet, LengthUnit.Inches);

        Assert.AreEqual(0.0, result);
    }

    // Verify negative number conversion
    [TestMethod]
    public void Convert_NegativeFeet_ToInches_ShouldReturnNegativeValue()
    {
        double outputValue = Quantity.ConvertValue(-1.0, LengthUnit.Feet, LengthUnit.Inches);

        Assert.AreEqual(-12.0, outputValue);
    }

    // Convert A → B → A and confirm original value is preserved
    [TestMethod]
    public void Conversion_RoundTrip_ShouldReturnOriginalValue()
    {
        double startValue = 100.0;
        LengthUnit firstUnit = LengthUnit.Yards;
        LengthUnit secondUnit = LengthUnit.Inches;

        double stepOne = Quantity.ConvertValue(startValue, firstUnit, secondUnit);
        double stepTwo = Quantity.ConvertValue(stepOne, secondUnit, firstUnit);

        Assert.AreEqual(startValue, stepTwo);
    }
}
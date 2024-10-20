using System;
using System.Globalization;
using Xunit;

public class TestDataGenerator
{
    [Fact]
    public void TestGenerateRandomDate()
    {
        string dateStr = Program.GenerateRandomDate();
        DateTime dateObj;
        bool parsed = DateTime.TryParseExact(dateStr, "yyyy. MMMM dd.", new CultureInfo("hu-HU"), DateTimeStyles.None, out dateObj);

        Assert.True(parsed, "Generated date string is not in the expected format.");
        Assert.True(dateObj >= new DateTime(2024, 1, 1), "Generated date is before the start of the expected range.");
        Assert.True(dateObj <= new DateTime(2025, 12, 28), "Generated date is after the end of the expected range.");
    }

    [Fact]
    public void TestGenerateRandomAmount()
    {
        string amountStr = Program.GenerateRandomAmount();
        Assert.False(string.IsNullOrWhiteSpace(amountStr), "Amount string is null or empty.");
        Assert.Contains(' ', amountStr);
        string amountWithoutSpaces = amountStr.Replace(" ", "");
        int amountNumeric;
        bool isNumeric = int.TryParse(amountWithoutSpaces, out amountNumeric);

        Assert.True(isNumeric, "Amount string is not a valid number.");
        Assert.True(amountNumeric >= 100000 && amountNumeric <= 999990, "Amount is out of expected range.");
        Assert.True(amountWithoutSpaces.EndsWith("990"), "Amount does not end with '990'.");
    }

    [Fact]
    public void TestGenerateRandomReference()
    {
        string referenceStr = Program.GenerateRandomReference();
        Assert.StartsWith("ADÓ", referenceStr, StringComparison.InvariantCulture);
        string referenceNumber = referenceStr.Substring(3);
        Assert.True(referenceNumber.Length == 6, "Reference number is not 6 digits long.");
        Assert.True(int.TryParse(referenceNumber, out _), "Reference number is not numeric.");
        Assert.Equal(9, referenceStr.Length);
    }
}

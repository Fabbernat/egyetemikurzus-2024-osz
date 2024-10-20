using System;
using System.Globalization;

class Program {
    static readonly DateTime BeginDate = new DateTime(2024, 1, 1);
    static readonly DateTime EndDate = new DateTime(2025, 12, 28);

    static readonly int Minimum = 0;
    static readonly int Maximum = 999990;

    static string GenerateRandomDate()
    {
        Random random = new Random();
        int range = (EndDate - BeginDate).Days;
        DateTime randomDate = BeginDate.AddDays(random.Next(range));
        return randomDate.ToString("yyyy. MMMM dd.", new CultureInfo("hu-HU"));
    }

    static string GenerateRandomAmount()
    {
        Random random = new Random();
        int baseAmount = random.Next(100000, 999990);
        int adjustedAmount = baseAmount - (baseAmount % 1000) + 990;
        return adjustedAmount.ToString("N0", new CultureInfo("hu-HU")).Replace(",", " ");
    }

    static string GenerateRandomReference()
    {
        Random random = new Random();
        return $"ADÓ{random.Next(100000, 999999)}";
    }

    static void Main(string[] args)
    {
        Console.WriteLine($"*Random dátum, {BeginDate.Year}.01.01. - {EndDate.Year}.12.28.*:");
        Console.WriteLine(GenerateRandomDate());
        Console.WriteLine();
        Console.WriteLine($"*Random összeg, {Minimum} - {Maximum}*:");
        Console.WriteLine(GenerateRandomAmount());
        Console.WriteLine();
        Console.WriteLine("*Random referencia*:");
        Console.WriteLine(GenerateRandomReference());
    }
}

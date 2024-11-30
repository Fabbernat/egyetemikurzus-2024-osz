using System.Globalization;

namespace NAVEmailApp;

public class CsvLoader
{
    public static List<AdosData>? LoadCsv(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Skip(1) // Skip header
                .Select(line =>
                {
                    var parts = line.Split(',');
                    return new AdosData(
                        Nev: parts[0],
                        Cim: parts[1].Trim('"'),
                        Osszeg: decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                        Hatarido: DateTime.Parse(parts[3]),
                        Kozlemeny: parts[4]
                    );
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt a CSV betöltésekor: {ex.Message}");
            return null;
        }
    }
}
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
                    var adosData = new AdosData(
                        nev: "Minta Név",
                        cim: new Address(6720, "Szeged", "Fő utca", "utca", 12, "-", "-", "-")
                        {
                            Telepules = null,
                            KozteruletNeve = null,
                            KozteruletJellege = null
                        },
                        osszeg: 1000.50m,
                        hatarido: DateTime.Now.AddDays(30),
                        kozlemeny: "Fizetési felszólítás"
                    );
                    return adosData;
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt a CSV betöltésekor: {ex.Message}");
            return null;
        }
    }

    private static Address ParseAddress(string cimString)
    {
        // Példa: "6720 Szeged, Fő utca 10. Emelet 2."
        var cimParts = cimString.Split(',');
        var firstPart = cimParts[0].Trim(); // "6720 Szeged"
        var secondPart = cimParts[1].Trim(); // "Fő utca 10. Emelet 2."

        var iranyitoszam = int.Parse(firstPart.Split(' ')[0]);
        var telepules = firstPart.Substring(firstPart.IndexOf(' ') + 1);

        var addressParts = secondPart.Split(' ');
        var kozteruletNeve = string.Join(' ', addressParts[..^2]); // "Fő utca"
        var kozteruletJellege = addressParts[^2].Trim('.'); // "utca"
        var hazszam = short.Parse(addressParts[^1].Trim('.')); // "10"

        return new Address(
            iranyitoszam,
            telepules,
            kozteruletNeve,
            kozteruletJellege,
            hazszam,
            "-", "-", "-"
        )
        {
            Telepules = telepules,
            KozteruletNeve = kozteruletNeve,
            KozteruletJellege = kozteruletJellege
        };
    }
}
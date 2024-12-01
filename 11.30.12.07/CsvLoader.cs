using System.Globalization;

namespace NAVEmailApp;

public class CsvLoader
{
    public static List<AdosData?> LoadCsv(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Skip(1) // Skip header
                .Where(line => !string.IsNullOrWhiteSpace(line)) // Skip empty lines
                .Select(line =>
                {
                    var parts = line.Split(',');

                    if (parts.Length < 2)
                    {
                        Console.WriteLine($"Hibás sor: {line}");
                        return null;
                    }

                    var cim = ParseAddress(parts[1].Trim('"'));

                    return new AdosData(
                        nev: parts[0].Trim('"'), // Név
                        cim: cim,
                        osszeg: 1000.50m,
                        hatarido: DateTime.Now.AddDays(30),
                        kozlemeny: "Fizetési felszólítás"
                    );
                })
                .Where(data => data != null) // Csak az érvényes adatokat tartsuk meg
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
        try
        {
            // Példa: "6720 Szeged, Fő utca 10. Emelet 2."
            var cimParts = cimString.Split(',');

            if (cimParts.Length < 2)
                // Hiba kezelése: nem megfelelő formátumú cím
                throw new FormatException($"Érvénytelen cím formátum: {cimString} ({nameof(cimString)})");

            var firstPart = cimParts[0].Trim(); // "6720 Szeged"
            var secondPart = cimParts[1].Trim(); // "Fő utca 10. Emelet 2."

            var iranyitoszam = int.Parse(firstPart.Split(' ')[0]);
            var telepules = firstPart.Substring(firstPart.IndexOf(' ') + 1);

            var addressParts = secondPart.Split(' ');
            if (addressParts.Length < 3)
            {
                // Hiba kezelése: nem megfelelő formátumú cím
                throw new FormatException($"Érvénytelen cím formátum: {cimString} ({nameof(cimString)})");
            }
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
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba a cím feldolgozása közben: {ex.Message}");
            throw; // Dobja tovább a kivételt, vagy térjen vissza egy alapértelmezett címmel
        }
    }
}
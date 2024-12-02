namespace NAVEmailApp;

public class CsvLoader
{
    public static List<AdosData?> LoadCsv(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line)) // Üres sorok kiszűrése
                .ToList();
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
                        parts[0].Trim('"'), // Név
                        cim,
                        1000.50m,
                        DateTime.Now.AddDays(30),
                        "Fizetési felszólítás"
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
            // Ellenőrzés: tartalmaz-e vesszőt
            if (!cimString.Contains(',')) throw new FormatException($"Érvénytelen cím formátum: {cimString}");

            // Példa: "6720 Szeged, Fő utca 10. Emelet 2."
            // Szétbontás a vessző alapján
            var cimParts = cimString.Split(',', StringSplitOptions.TrimEntries);
            if (cimParts.Length < 2)
                // Hiba kezelése: nem megfelelő formátumú cím
                throw new FormatException($"Érvénytelen cím formátum: {cimString} ({nameof(cimString)})");

            var firstPart = cimParts[0].Trim(); // "6720 Szeged"
            var secondPart = cimParts[1].Trim(); // "Fő utca 10. Emelet 2."

            var iranyitoszam = int.Parse(firstPart.Split(' ')[0]);
            var telepules = firstPart[(firstPart.IndexOf(' ') + 1)..];

            var addressParts = secondPart.Split(' ');
            if (addressParts.Length < 3)
                // Hiba kezelése: nem megfelelő formátumú cím
                throw new FormatException($"Érvénytelen cím formátum: {cimString} ({nameof(cimString)})");
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
                Iranyitoszam = int.MinValue,
                Telepules = "ismeretlen",
                KozteruletNeve = "ismeretlen",
                KozteruletJellege = "ismeretlen",
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba a cím feldolgozása közben: {ex.Message}");
            return new Address
            {
                Iranyitoszam = int.MinValue,
                Telepules = "ismeretlen",
                KozteruletNeve = "ismeretlen",
                KozteruletJellege = "ismeretlen",
            };
        }
    }
}
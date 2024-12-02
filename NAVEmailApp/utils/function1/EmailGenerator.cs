namespace NAVEmailApp;

public class EmailGenerator
{
    public static string GenerateEmail(AdosData data)
    {
        return $@"
Tárgy: Fizetési felszólítás - Adótartozás

Kedves {data.Nev},

A következő adótartozás került rögzítésre az Ön nevéhez:

Összeg: {data.Osszeg:C}
Határidő: {data.Hatarido:yyyy. MMMM dd.}
Közlemény: {data.Kozlemeny}

Kérjük, haladéktalanul intézkedjen a tartozás rendezéséről. Amennyiben már rendezte a tartozását, kérjük, tekintse ezt az üzenetet tárgytalannak.

Üdvözlettel,
NAV
";
    }

    public static int PrepareEmailGeneration()
    {
        try
        {
            var csvFilePath = Path.Combine("csv", "../../../../csv/database.csv");
            List<AdosData?> data = CsvLoader.LoadCsv(csvFilePath);
            if (data == null || data.Count == 0)
            {
                Console.WriteLine(data);
                return 1;
            }

            Console.WriteLine("Adatok sikeresen betöltve:");
            foreach (var item in data) Console.WriteLine(item);
            return 0;
        }
        catch (FormatException e)
        {
            Console.WriteLine("Jelenleg nem működik az 1. email sablon.");
        }

        return 2;
    }

    public static void GenerateEmailFile()
    {
        var sourceFilePath = @"../../../tex/sample.tex"; // A feltöltött fájl elérési útja
        var outputDirectory = Path.Combine(Environment.CurrentDirectory, "OutputEmails");
        var outputFilePath = Path.Combine(outputDirectory, "FizetesiFelszolitas.tex");

        try
        {
            // Kimeneti mappa létrehozása, ha nem létezik
            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);

            // Sablon szöveg másolása
            File.Copy(sourceFilePath, outputFilePath, true);

            Console.WriteLine($"Az email sikeresen generálva. Elérési út: {outputFilePath}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Hiba: A sablonfájl nem található.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Hiba: Nincs engedély a fájl írására.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ismeretlen hiba történt a fájl generálása közben: {ex.Message}");
        }
    }
}
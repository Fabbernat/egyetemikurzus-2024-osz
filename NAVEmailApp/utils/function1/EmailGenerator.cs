using System.Globalization;
using System.Text;

namespace NAVEmailApp;

public class EmailGenerator
{
    public static int PrepareEmailGeneration()
    {
        try
        {
            var csvFilePath = Path.Combine("csv", "../../../../csv/personaldata.csv");
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
    
    public static void GenerateMarkdownEmailFile(AdosData? data = null, string to = "", string cc = "", string bcc = "", string subject = "NAV ügyfélmegkeresés")
    {
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        var sb = new StringBuilder();
        sb.AppendLine($"**To:** {to}");
        sb.AppendLine($"**Cc:** {cc}");
        sb.AppendLine($"**Bcc:** {bcc}");
        sb.AppendLine($"**Subject:** {subject}");
        sb.AppendLine($"**Date:** {currentDate}");
        sb.AppendLine();
        sb.AppendLine($"**Tisztelt {data?.Nev},**");
        sb.AppendLine();
        sb.AppendLine($"A következő adótartozás került rögzítésre az Ön nevéhez:");
        sb.AppendLine();
        if (data != null)
        {
            sb.AppendLine($"- **Összeg:** {data.Osszeg:C}");
            sb.AppendLine($"- **Határidő:** {data.Hatarido:yyyy. MMMM dd.}");
            sb.AppendLine($"- **Közlemény:** {data.Kozlemeny}");
        }

        sb.AppendLine();
        sb.AppendLine("Kérjük, haladéktalanul intézkedjen a tartozás rendezéséről. Amennyiben már rendezte a tartozását, kérjük, tekintse ezt az üzenetet tárgytalannak.");
        sb.AppendLine();
        sb.AppendLine("Üdvözlettel,");
        sb.AppendLine("**NAV**");

        string emailContent = sb.ToString();
    
        var outputDirectory = Path.Combine(Environment.CurrentDirectory, "OutputMarkdownEmails");
        var outputFilePath = Path.Combine(outputDirectory, "FizetesiFelszolitas.md");

        try
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Markdown tartalom írása a fájlba
            File.WriteAllText(outputFilePath, emailContent);

            Console.WriteLine($"Az email sikeresen generálva. Elérési út: {outputFilePath}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Hiba: A fájl nem található.");
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

    public static void GenerateTeXEmailFile()
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
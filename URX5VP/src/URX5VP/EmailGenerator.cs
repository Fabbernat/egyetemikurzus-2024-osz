using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Text.Json;

namespace URX5VP
{
    internal class EmailGenerator
    {
        public record UserData(string Nev, string Cim, string Osszeg, string Hatarido, string Kozlemeny);

        public string GenerateEmail(string texFilePath, string JSONDataFilePath)
        {
            try
            {
                string sablon = File.ReadAllText(texFilePath);
                string JSONData = File.ReadAllText(JSONDataFilePath);
                List<UserData> users = JsonSerializer.Deserialize<List<UserData>>(JSONData);

                List<string> Emails = new List<string>();
                foreach (var user in users)
                {
                    string Email = sablon
                        .Replace(@"\\nev", user.Nev)
                        .Replace(@"\\cim", user.Cim)
                        .Replace(@"\\osszeg", user.Osszeg)
                        .Replace(@"\\hatarido", user.Hatarido)
                        .Replace(@"\\kozlemeny", user.Kozlemeny);

                    string fileName = $"../tex_outputs/new/{user.Nev.Replace(" ", "_")}.tex";
                    File.WriteAllText(fileName, Email);
                    Emails.Add(Email);
                }
                return $"Levelek generálva: {Emails.ToString()}";
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Váratlan hiba történt: {ex.Message}");
                return "";
            }
        }
    }
}
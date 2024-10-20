using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LetterGenerator
{
    public record UserData(string Nev, string Cim, string Osszeg, string Hatarido, string Kozlemeny);

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sablon = File.ReadAllText("../sample.tex");
                string jsonData = File.ReadAllText("../data/database.json");
                List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(jsonData);

                foreach (var user in users)
                {
                    string letter = sablon
                        .Replace(@"\\nev", user.Nev)
                        .Replace(@"\\cim", user.Cim)
                        .Replace(@"\\osszeg", user.Osszeg)
                        .Replace(@"\\hatarido", user.Hatarido)
                        .Replace(@"\\kozlemeny", user.Kozlemeny);

                    string fileName = $"../tex_outputs/new/{user.Nev.Replace(" ", "_")}.tex";
                    File.WriteAllText(fileName, letter);

                    Console.WriteLine($"Levél generálva: {fileName}");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Váratlan hiba történt: {ex.Message}");
            }
        }
    }
}

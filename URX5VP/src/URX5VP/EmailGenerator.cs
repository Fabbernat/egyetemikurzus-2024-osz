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
        
        Email InitializeEmail()
        {
            Console.WriteLine("Adja meg az email-címét!");
            string Sender = "";
            do
            {

                Sender = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Sender))
                {
                    Console.WriteLine("Hiba: Az email-címe nem lehet üres.");
                    continue;
                }
                else if (!Sender.Contains('@'))
                {
                    Console.WriteLine("Hiba: Érvénytelen email cím.");
                }
                else
                {
                    break;
                }
            } while (string.IsNullOrWhiteSpace(Sender) || !Sender.Contains('@'));

            string[] recipientsEncriptionMode = { "To", "Cc", "Bcc" };
            foreach (var mode in recipientsEncriptionMode)
            {
                Console.WriteLine(
                    $"Adja meg a {recipientsEncriptionMode} címzettek email címeit! Ha végzett, nyomja meg az Esc (escape) gombot!")
            }

            ;
            String key = null;
            int i = 0;
            string[] emailAddresses = [];
            do
            {
                ++i;
                System.Console.WriteLine($"{i}. címzett email-címe:");
                string emailAddress = Console.ReadLine();
                emailAddresses.append(emailAddress);
            } while (key != "Esc");



            Console.WriteLine("Adja meg az email tárgyát! ");
            string Subject = Console.ReadLine();

            Console.WriteLine("Adja meg az üzenetet sztringként!");
            string message = Console.ReadLine();

            Email email = new Email(Sender, Recipients, Subject, DateTime.Now, message);
            
            return email;
        }
    }
}
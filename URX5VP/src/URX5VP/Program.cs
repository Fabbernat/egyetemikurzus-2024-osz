using System.Numerics;
using System.Reflection;

using DataGenerator;
using EmailGenerator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace URX5VP
{
    public class Program
    {
        private Dictionary<string, Action> commands = new()
        {
            {"exit", () => OnExit() },
            {"hello", () => OnHello()},
            {"write", () => {
                Console.WriteLine("Add meg a generálandó email típusát! A - [A]dótartozás C - [C]ancel");
                var key = Console.ReadKey();
                if (key == 'A')
                {
                    
                } else if (key == 'C')
                {
                    
                }
                OnWriteType();
                Console.WriteLine("Add meg a levélhat szükséges változókat!");
                
            }
            }
        };

        void OnExit()
        {
            Environment.Exit(Environment.ExitCode);
        }

        void OnHello()
        {
            Console.WriteLine("Hello, World!");
        }

        void OnWriteType()
        {
            int n;
            string? s = Console.ReadLine();
            try
            {
                n = (int)BigInteger.Parse(s);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hibás formátum! Nem egy szamot adtál meg");
            }

            while (true)
            {
                string? line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (commands.ContainsKey(line))
                    {
                        commands[line].Invoke();
                    }
                    else { Console.WriteLine("??"); }
                }
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
        }
    }
            
            Console.WriteLine("Adja meg az email tárgyát! ");
            string Subject = Console.ReadLine();

            Console.WriteLine("Adja meg az üzenetet sztringként!");
            string Message = Console.ReadLine();

            Email Email = new Email(Sender, Recipients, Subject, DateTime.Now, Message);
            return Email;
        }

        void DoCommand(string line)
        {
            switch (line)
            {
                case "exit":
                    Environment.Exit(0);
                    break;
                case "helo":
                    Console.WriteLine("Hello, World!");
                    break;
                default:
                    Console.WriteLine("Érvénytelen parancs");
                    break;
            }
        }

        public static int Main()
        {
            EmailGenerator emailGenerator = new EmailGenerator();
            Email templateEmail = InitializeEmail();
            DataGenerator dataGenerator = new DataGenerator();
            RecipientData data = dataGenerator.getData();
            Email generatedEmail = emailGenerator.generateEmail(templateEmail, data);
            ISerializable iSer = new ISerializable();
            iSer.serializeemail(generatedEmail);
            with open("outputs/result.pdf" as res)
            {
                res.write(generatedEmail);
            }
            _ = Console.ReadKey(); // Tetszőleges gomb lenyomásával kilépünk a programból
            return 0;
        }
    }
}
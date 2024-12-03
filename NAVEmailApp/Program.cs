// Program.cs
using NAVEmailApp.utils.function2;
using NAVEmailApp.utils.function3;
using NAVEmailApp.utils.function4;
using NAVEmailApp.utils.function5;
using static NAVEmailApp.EmailGenerator;

namespace NAVEmailApp;

internal class Program
{
    public static int Main(string[] args)
    {
        Console.WriteLine("Üdvözöljük a NAV Automatikus Email Kibocsátó Alkalmazásban!");

        string input = "";
        do
        {
            DisplayMenu(); // Display the menu options

            try
            {
                // Felhasználói input
                input = (Console.ReadLine() ?? string.Empty);
                int choice = int.Parse(input);
                switch (choice)
                {
                    case < 0:
                    case > 5:
                        Console.WriteLine("Hiba: Érvénytelen választás! Kérjük, próbálja újra.");
                        break;
                    case 1:
                    {
                        int retval = PrepareEmailGeneration();
                        if (retval == 0)
                        {
                            GenerateEmailFile();
                        }
                        else
                        {
                            Console.WriteLine("A választott sablon jelenleg nem támogatott.");
                        }

                        break;
                    }
                    case 2:
                        var rulesService = new RulesService();
                        var rulesView = new RulesView(rulesService);
                        rulesView.DisplayRules();
                        break;
                    case 3:
                        var notificationService = new NotificationService();
                        var notificationView = new NotificationView(notificationService);
                        notificationView.DisplayNotifications();
                        break;
                    case 4:
                        var reminderService = new ReminderService();
                        var reminderView = new ReminderView(reminderService);
                        reminderView.DisplayReminders();
                        break;
                    case 5:
                        var queryService = new QueryService();
                        var queryView = new QueryView(queryService);
                        queryView.DisplayQueryResults();
                        break;
                    default:
                        continue; // Continue to the next iteration of the loop
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hiba: A megadott érték nem szám! Kérjük, csak számot adjon meg.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ismeretlen hiba történt: {ex.Message}");
            }

            Console.WriteLine("\nNyomjon meg egy billentyűt a folytatáshoz vagy 0-t a kilépéshez...");
            input = Console.ReadKey().KeyChar.ToString();

        } while (input != "0");

        Console.WriteLine("\nViszlát!");
        return 0;
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\nKérjük, válasszon az alábbi műveletek közül:");

        // Sablonok listája
        string[] templates =
        {
            "0. - Mégse",
            "1. - Fizetési felszólítás",
            "2. - Tájékoztató az új szabályokról",
            "3. - Ellenőrzési értesítés",
            "4. - Adóbevallási emlékeztető",
            "5. - Egyéni lekérdezés válasz, megadott id alapján"
        };

        // Sablonok megjelenítése
        foreach (var template in templates) Console.WriteLine(template);

        Console.Write($"\nAdja meg a választott művelet számát (0-5): ");
    }
}
// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using static NAVEmailApp.CsvLoader;

namespace NAVEmailApp;

    class Program
    {
            
        public static int Main(string[] args)
        {
            
            
            string csvFilePath = Path.Combine("csv", "../../../../csv/database.csv");
            List<AdosData>? data = LoadCsv(csvFilePath);
            if (data == null || data.Count == 0)
            {
                Console.WriteLine(data);
                Console.WriteLine("Nem sikerült betölteni az adatokat a CSV fájlból.");
                return 1;
            }
            
            Console.WriteLine("Adatok sikeresen betöltve:");
            foreach (var item in data)
            {
                Console.WriteLine(item); // Assuming AdosData has a meaningful ToString override
            }
            
            Console.WriteLine("Üdvözöljük a NAV Automatikus Email Kibocsátó Alkalmazásban!");
            Console.WriteLine("Kérjük, válasszon az alábbi email sablonok közül:");

            // Sablonok listája
            string[] templates = 
            {
                "1. - Fizetési felszólítás",
                "2. - Adóbevallási emlékeztető",
                "3. - Ellenőrzési értesítés",
                "4. - Tájékoztató az új szabályokról",
                "5. - Egyéni lekérdezés válasz",
                "6. - Mégse"
            };

            // Sablonok megjelenítése
            foreach (var template in templates)
            {
                Console.WriteLine(template);
            }

            Console.Write("\nAdja meg a választott sablon számát (1-6): ");

            try
            {
                // Felhasználói input
                int choice = int.Parse(Console.ReadLine());

                if (choice < 1 || choice > 6)
                {
                    Console.WriteLine("Hiba: Érvénytelen választás! Kérjük, próbálja újra.");
                }
                else if (choice == 1)
                {
                    GenerateEmailFile();
                    string adatok = "";
                    for (int i = 0; i < data.Count; i++)
                    {
                    Console.WriteLine($"A(z) {i + 1}. email szövege: {EmailGenerator.GenerateEmail(data[i])}");
                    }
                }
                else if (choice == 6)
                {
                    return 0;
                }
                {
                    Console.WriteLine("A választott sablon jelenleg nem támogatott.");
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

            Console.WriteLine("\nNyomjon meg egy billentyűt a kilépéshez...");
            Console.ReadKey();
            return 0;

        }

        static void GenerateEmailFile()
        {
            string sourceFilePath = @"../../../tex/sample.tex"; // A feltöltött fájl elérési útja
            string outputDirectory = Path.Combine(Environment.CurrentDirectory, "OutputEmails");
            string outputFilePath = Path.Combine(outputDirectory, "FizetesiFelszolitas.tex");

            try
            {
                // Kimeneti mappa létrehozása, ha nem létezik
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Sablon szöveg másolása
                File.Copy(sourceFilePath, outputFilePath, overwrite: true);

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


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

using static URX5VP.models.PersonalData;
using CsvHelper;
using URX5VP.models;

public class Program
{
    public static int Main(string[] args)
    {
        string pathToCsv = "csv/database.csv";
        List<PersonalData> records = new List<PersonalData>();
        
        string dataFromCsv = records.ToString();
        try
        {


        using (var reader = new StreamReader(pathToCsv))
        // Use CsvReader to parse the CSV data
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Read the data and store it in the list
            records = csv.GetRecords<PersonalData>().ToList();
        }
        } catch (Exception e)
        {
            Console.WriteLine("Sajnos hibába ütköztünk a csv beolvasása során =(");
            return -1;
        }

        // Now you can work with the data in the 'records' list
        foreach (var record in records)
        {
            Console.WriteLine($"VezetekNev: {record.VezetekNev}, KeresztNev: {record.KeresztNev}, TeljesCim: {record.TeljesCim}, : Osszeg{record.Osszeg}, : Hatarido{record.Hatarido}, : Kozlemeny{record.Kozlemeny}.");
        }

        return 0;
    }
}
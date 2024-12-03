namespace NAVEmailApp.utils.function5;

using System;
using System.Collections.Generic;

public class QueryService
{
    public IEnumerable<string> ProcessQuery(string userInput)
    {
        // Itt statikus adatokat használunk, TODO adatok csv-bol
        var sampleData = new Dictionary<string, string>
        {
            { "1", "Adós: Tóth Béla, Hátralék: 5000 HUF" },
            { "2", "Adós: Kovács Anna, Hátralék: 12000 HUF" },
            { "3", "Adós: Nagy Péter, Hátralék: 3000 HUF" }
        };

        if (sampleData.ContainsKey(userInput))
        {
            yield return sampleData[userInput];
        }
        else
        {
            yield return "Nincs találat a megadott azonosítóra.";
        }
    }
}

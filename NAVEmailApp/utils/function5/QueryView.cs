namespace NAVEmailApp.utils.function5;

using System;

public class QueryView
{
    private readonly QueryService _queryService;

    public QueryView(QueryService queryService)
    {
        _queryService = queryService;
    }

    public void DisplayQueryResults()
    {
        Console.WriteLine("\nKérjük, adja meg az adós azonosítóját:");
        var userInput = Console.ReadLine();
        

        Console.WriteLine("\nLekérdezési eredmények:");
        foreach (var result in _queryService.ProcessQuery(userInput))
        {
            Console.WriteLine($"- {result}");
        }
    }
}

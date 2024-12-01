namespace NAVEmailApp.utils.function2;

using System;

public class RulesView
{
    private readonly RulesService _rulesService;

    public RulesView(RulesService rulesService)
    {
        _rulesService = rulesService;
    }

    public void DisplayRules()
    {
        Console.WriteLine("Tájékoztató az új szabályokról:");
        foreach (var rule in _rulesService.GetUpdatedRules())
        {
            Console.WriteLine($"- {rule}");
        }
    }
}

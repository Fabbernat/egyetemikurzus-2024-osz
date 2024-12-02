namespace NAVEmailApp.utils.function4;

public class ReminderView
{
    private readonly ReminderService _reminderService;

    public ReminderView(ReminderService reminderService)
    {
        _reminderService = reminderService;
    }

    public void DisplayReminders()
    {
        Console.WriteLine("\nAdóbevallási emlékeztetők:");
        var reminders = _reminderService.GetReminders();
        
        if (reminders.Count == 0)
        {
            Console.WriteLine("Nincs elérhető emlékeztető.");
        }
        else
        {
            foreach (var reminder in reminders)
            {
                Console.WriteLine($"- {reminder}");
            }
        }
    }
}
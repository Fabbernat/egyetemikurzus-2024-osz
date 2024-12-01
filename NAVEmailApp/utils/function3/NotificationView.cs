namespace NAVEmailApp.utils.function3;

using System;

public class NotificationView
{
    private readonly NotificationService _notificationService;

    public NotificationView(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void DisplayNotifications()
    {
        Console.WriteLine("Ellenőrzési értesítések:");
        foreach (var notification in _notificationService.GetInspectionNotifications())
        {
            Console.WriteLine($"- {notification}");
        }
    }
}

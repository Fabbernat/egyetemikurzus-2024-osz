namespace NAVEmailApp.utils.function3;

using System;
using System.Collections.Generic;

public class NotificationService
{
    public IEnumerable<string> GetInspectionNotifications()
    {
        // Mock data, could be fetched from a database or file in a real application.
        return new List<string>
        {
            "Tóth Béla: Ellenőrzés szükséges 2024. október 31-én.",
            "Kovács János: Ellenőrzés szükséges 2024. november 5-én.",
            "Szabó Anna: Ellenőrzés szükséges 2024. december 19-én.",
            "Nagy Péter: Ellenőrzés szükséges 2024. november 29-én."
        };
    }
}

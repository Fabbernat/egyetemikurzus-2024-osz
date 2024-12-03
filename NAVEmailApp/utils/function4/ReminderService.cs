namespace NAVEmailApp.utils.function4;

public class ReminderService
{
    public List<string> GetReminders()
    {
        // Példa adatok helyett tényleges adatbázis lekérdezések kellenének.
        return new List<string>
        {
            "Tisztelt Ügyfél, ne feledje, hogy adóbevallása határideje közeleg: 2024.12.20.",
            "Figyelmeztetés: Az Ön adóbevallása még nincs beküldve.",
            "Kérjük, ellenőrizze a bevallás státuszát a NAV portálján."
        };
    }
}
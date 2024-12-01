namespace NAVEmailApp.utils.function2;

public class RulesService
{
    public IEnumerable<string> GetUpdatedRules()
    {
        return new List<string>
        {
            "1. Az új szabály érvénybe lép 2024. december 1-től.",
            "2. Kérjük, minden befizetést időben teljesítsen.",
            "3. Az új dokumentumok letölthetők a portálon.",
            "4. Késedelmes fizetések esetén új kamatláb lesz érvényes."
        };
    }
}
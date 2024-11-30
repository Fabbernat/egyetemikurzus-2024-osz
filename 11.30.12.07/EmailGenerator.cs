namespace NAVEmailApp;

public class EmailGenerator
{
    public static string GenerateEmail(AdosData data)
    {
        return $@"
Tárgy: Fizetési felszólítás - Adótartozás

Kedves {data.Nev},

A következő adótartozás került rögzítésre az Ön nevéhez:

Összeg: {data.Osszeg:C}
Határidő: {data.Hatarido:yyyy. MMMM dd.}
Közlemény: {data.Kozlemeny}

Kérjük, haladéktalanul intézkedjen a tartozás rendezéséről. Amennyiben már rendezte a tartozását, kérjük, tekintse ezt az üzenetet tárgytalannak.

Üdvözlettel,
NAV
";
    }
}
namespace NAVEmailApp;

public class AdosData
{
    public AdosData(string nev, Address cim, decimal osszeg, DateTime hatarido, string kozlemeny)
    {
        Nev = nev;
        Cim = cim;
        Osszeg = osszeg;
        Hatarido = hatarido;
        Kozlemeny = kozlemeny;
    }

    public string Nev { get; }
    public Address Cim { get; }
    public decimal Osszeg { get; }
    public DateTime Hatarido { get; }
    public string Kozlemeny { get; }

    public override string ToString()
    {
        return $"Név: {Nev}, Cím: {Cim}, Összeg: {Osszeg:C}, Határidő: {Hatarido:yyyy. MMMM dd.}, Közlemény: {Kozlemeny}";
    }
    
}
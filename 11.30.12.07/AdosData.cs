namespace NAVEmailApp;

public class AdosData
{
    public string Nev { get; }
    public Address Cim { get; }
    public decimal Osszeg { get; }
    public DateTime Hatarido { get; }
    public string Kozlemeny { get; }

    public AdosData(string nev, Address cim, decimal osszeg, DateTime hatarido, string kozlemeny)
    {
        Nev = nev;
        Cim = cim;
        Osszeg = osszeg;
        Hatarido = hatarido;
        Kozlemeny = kozlemeny;
    }

    public override string ToString()
    {
        return $"{Nev}, {Cim}, {Osszeg}, {Hatarido}, {Kozlemeny}";
    }
}

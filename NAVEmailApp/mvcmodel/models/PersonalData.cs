namespace NAVEmailApp.mvcmodel;

public class PersonalData
{
    public PersonalData()
    {
    }

    public PersonalData(string vezetekNev, string keresztNev, Address teljesCim, int osszeg, DateTime hatarido,
        string kozlemeny)
    {
        VezetekNev = vezetekNev;
        KeresztNev = keresztNev;
        TeljesCim = teljesCim;
        Osszeg = osszeg;
        Hatarido = hatarido;
        Kozlemeny = kozlemeny;
    }

    public required string VezetekNev { get; set; }
    public required string KeresztNev { get; set; }
    public Address TeljesCim { get; set; }
    public int Osszeg { get; set; }
    public DateTime Hatarido { get; set; }
    public string Kozlemeny { get; set; }
}
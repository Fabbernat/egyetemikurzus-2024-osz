using static NAVEmailApp.mvcmodel.Address;

namespace NAVEmailApp.mvcmodel;


public class PersonalData
{
    public string VezetekNev { get; set; }
    public string KeresztNev { get; set; }
    public Address TeljesCim { get; set; }
    public int Osszeg { get; set; } 
    public DateTime Hatarido { get; set; }
    public string Kozlemeny { get; set; }
    
    public PersonalData() {}

    public PersonalData(string vezetekNev, string keresztNev, NAVEmailApp.mvcmodel.Address teljesCim, int osszeg, DateTime hatarido, string kozlemeny)
    {
        VezetekNev = vezetekNev;
        KeresztNev = keresztNev;
        TeljesCim = teljesCim;
        Osszeg = osszeg;
        Hatarido = hatarido;
        Kozlemeny = kozlemeny;
    }
}
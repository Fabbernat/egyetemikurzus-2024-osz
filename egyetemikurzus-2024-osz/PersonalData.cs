using static URX5VP.models.Address;
namespace URX5VP.models
{

    public class PersonalData
    {
        public string VezetekNev { get; set; }
        public string KeresztNev { get; set; }
        public Address TeljesCim { get; set; }
        public int Osszeg { get; set; }
        public DateTime Hatarido { get; set; }
        public string Kozlemeny { get; set; }

        public PersonalData() { }

        public PersonalData(string vezetekNev, string keresztNev, Address teljesCim, int osszeg, DateTime hatarido, string kozlemeny)
        {
            VezetekNev = vezetekNev;
            KeresztNev = keresztNev;
            TeljesCim = teljesCim;
            Osszeg = osszeg;
            Hatarido = hatarido;
            Kozlemeny = kozlemeny;
        }
    }
}
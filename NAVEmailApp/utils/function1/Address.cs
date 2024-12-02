namespace NAVEmailApp;

public class Address
{
    public Address()
    {
    }

    public Address(int iranyitoszam, string? telepules, string? kozteruletNeve, string? kozteruletJellege, int hazszam)
    {
        Iranyitoszam = iranyitoszam;
        Telepules = telepules;
        KozteruletNeve = kozteruletNeve;
        KozteruletJellege = kozteruletJellege;
        Hazszam = hazszam;
    }

    public Address(int iranyitoszam, string? telepules, string? kozteruletNeve, string? kozteruletJellege,
        int hazszam, string? reszleg = null, string? emelet = null, string? ajto = null)
    {
        Iranyitoszam = iranyitoszam;
        Telepules = telepules;
        KozteruletNeve = kozteruletNeve;
        KozteruletJellege = kozteruletJellege;
        Hazszam = hazszam;
        Reszleg = reszleg;
        Emelet = emelet;
        Ajto = ajto;
    }

    public required int Iranyitoszam { get; set; }
    public required string? Telepules { get; set; }
    public required string? KozteruletNeve { get; set; }
    public required string? KozteruletJellege { get; set; }
    public int Hazszam { get; set; }

    public string? Reszleg { get; set; }
    public string? Emelet { get; set; }
    public string? Ajto { get; set; }
}
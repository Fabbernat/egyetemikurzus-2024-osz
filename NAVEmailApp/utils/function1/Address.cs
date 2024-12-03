using System.Text.RegularExpressions;

namespace NAVEmailApp;

public class Address
{
    public Address()
    {
    }

    public Address(string fullAddress)
    {
        if (string.IsNullOrWhiteSpace(fullAddress) || !IsValid(fullAddress))
            throw new ArgumentException($"Érvénytelen cím formátum: {fullAddress}");

        FullAddress = fullAddress;
    }

    public Address(int iranyitoszam, string? telepules, string? kozteruletNeve, string? kozteruletJellege, int hazszam)
    {
        Iranyitoszam = iranyitoszam;
        Telepules = telepules ?? string.Empty;
        KozteruletNeve = kozteruletNeve ?? string.Empty;
        KozteruletJellege = kozteruletJellege ?? string.Empty;
        Hazszam = hazszam;
    }

    public Address(int iranyitoszam, string? telepules, string? kozteruletNeve, string? kozteruletJellege,
        int hazszam, string? reszleg = null, string? emelet = null, string? ajto = null)
    {
        Iranyitoszam = iranyitoszam;
        Telepules = telepules ?? string.Empty;
        KozteruletNeve = kozteruletNeve ?? string.Empty;
        KozteruletJellege = kozteruletJellege ?? string.Empty;
        Hazszam = hazszam;
        Reszleg = reszleg;
        Emelet = emelet;
        Ajto = ajto;
    }

    public string FullAddress { get; }


    public required int Iranyitoszam { get; set; }
    public required string Telepules { get; set; }
    public required string KozteruletNeve { get; set; }
    public required string KozteruletJellege { get; set; }
    public int Hazszam { get; set; }

    public string? Reszleg { get; set; }
    public string? Emelet { get; set; }
    public string? Ajto { get; set; }

    private bool IsValid(string address)
    {
        // Regex példa a magyar címekhez
        var regex = new Regex(@"^\d{4}\s+[A-Za-záéíóöőúüűÁÉÍÓÖŐÚÜŰ\s]+$");
        return regex.IsMatch(address);
    }

    public override string ToString()
    {
        return FullAddress;
    }
}
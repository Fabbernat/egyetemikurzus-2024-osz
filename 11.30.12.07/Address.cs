namespace NAVEmailApp;

public class Address
{
       
    private int Iranyitoszam { get; set; }
    private string? Telepules { get; set; }
    private string? KozteruletNeve { get; set; }
    private string? KozteruletJellege { get; set; }
    private int Hazszam { get; set; }

    // Nullable:
    private string? Reszleg { get; set; }
    private string? Emelet { get; set; }
    private string? Ajto { get; set; }

    /** default constructor
     *
     */
    public Address() { }

    /**
     * Constructor without the last 3 data attributes (nullable ones)
     */
    
    public Address(int iranyitoszam, string telepules, string kozteruletNeve, string kozteruletJellege, short hazszam)
    {
        Iranyitoszam = iranyitoszam;
        Telepules = telepules; 
        KozteruletNeve = kozteruletNeve;
        KozteruletJellege = kozteruletJellege;
        Hazszam = hazszam;
        Reszleg = "-"; // Example default value
        Emelet = "-";
        Ajto = "-";
    }

    /**
     *    Constructor with all data attributes
     */
    public Address(int iranyitoszam, string telepules, string kozteruletNeve, string kozteruletJellege,
        short hazszam, string? reszleg = null, string? emelet = null, string? ajto = null)
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
}

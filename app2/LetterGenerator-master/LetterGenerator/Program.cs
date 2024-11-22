using System.Numerics;
using System.Reflection;
using KorlevelGenerator.source;
using static System.Runtime.InteropServices.JavaScript.JSType;

Dictionary<string, Action> commands = new()
{
    {"exit", () => Environment.Exit(Environment.ExitCode) },
    {"hello", () => Console.WriteLine("Hello, World!") },
    {"write", () => {
        Console.WriteLine("Add meg a generálandó email típusát!");
        OnWriteType();
        Console.WriteLine("Add meg a levélhat szükséges változókat!");
    }
    }
};

void OnExit()
{
    Environment.Exit(Environment.ExitCode);
}

void OnHello()
{
    Console.WriteLine("Hello, World!");
}

void OnWriteType()
{
    int n;
    string? s = Console.ReadLine();
    try
    {
        n = (int)BigInteger.Parse(s);
    }
    catch (Exception e)
    {
        Console.WriteLine("Hibás formátum! Nem egy szamot adtál meg");
    }

    while (true)
    {
        string? line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
            if (commands.ContainsKey(line))
            {
                commands[line].Invoke();
            }
            else { Console.WriteLine("??"); }
        }
    }
}

Letter InitializeLetter()
{
    Console.WriteLine("Add meg a küldő email címét!");
    string Sender = "";
    do
    {

        Sender = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(Sender))
        {
            Console.WriteLine("Hiba: A küldő email címe nem lehet üres.");
            continue;
        }
        else if (!Sender.Contains('@'))
        {
            Console.WriteLine("Hiba: Érvénytelen email cím.");
        }
        else
        {
            break;
        }
    } while (string.IsNullOrWhiteSpace(Sender) || !Sender.Contains('@'));

    Console.WriteLine("Add meg a fogadók email címét! ilyen formátumban:" +
        "<recipient1@example.com>, <recipient2@example.com>, ...");
    string RecipientsInput = Console.ReadLine();
    string[] Recipients = RecipientsInput.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

    Console.WriteLine("Add meg az email tárgyát! ");
    string Subject = Console.ReadLine();

    Console.WriteLine("Add meg az üzenetet sztringként!");
    string Message = Console.ReadLine();

    Letter letter = new Letter(Sender, Recipients, Subject, DateTime.Now, Message);
    return letter;
}

void DoSomeThing(string line)
{
    switch (line)
    {
        case "exit":
            Environment.Exit(0);
            break;
        case "helo":
            Console.WriteLine("Hello, World!");
            break;
        default:
            Console.WriteLine("Érvénytelen parancs");
            break;
    }
}

delegate void Execute();




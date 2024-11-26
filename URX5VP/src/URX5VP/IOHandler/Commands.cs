namespace URX5VP.IOHandler;

public class Commands
{
    private Dictionary<string, Action> commands = new()
        {
            {"exit", () => OnExit() },
            {"hello", () => OnHello()},
            {"write", () => {
                Console.WriteLine("Add meg a generálandó email típusát! T - Adó[t]artozás, B - Adó[b]evallás C - [C]ancel");
                var key = Console.ReadKey();
                if (key == 'A')
                {
                    // TODO
                } else if (key == 'C')
                {
                    // TODO
                }
                // maybe_unused
                OnWriteType();
                Console.WriteLine("Add meg a levélhez szükséges változókat!");
                
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
        
        void DoCommand(string line)
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
}
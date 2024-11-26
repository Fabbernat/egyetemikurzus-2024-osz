namespace URX5VP.IOHandler;

public class IO
{
    private Dictionary<string, Action> commands = new()
        {
            {"exit", () => OnExit() },
            {"hello", () => OnHello()},
            {"write", () => {
                Console.WriteLine("Add meg a generálandó email típusát! \n T - Adó[t]artozás, \n B - SZja-[b]evallás, \n Adó[v]isszatérítés, \n M - [m]égse");
                var key = Console.ReadKey();
                if (key == 'A')
                {
                    // TODO
                } else if (key == 'C')
                {
                    // TODO
                }
                // [[maybe_unused]]
                OnWriteType();
                
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
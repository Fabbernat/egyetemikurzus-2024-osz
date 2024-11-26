using System;
using System.Numerics;
using System.Reflection;

using DataGenerator;
using EmailGenerator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace URX5VP;

public class Program
{
    


    public static int Main()
    {
        EmailGenerator emailGenerator = new EmailGenerator();
        Email templateEmail = InitializeEmail();
        DataGenerator dataGenerator = new DataGenerator();
        RecipientData data = dataGenerator.getData();
        DefaultParts defaultParts = new DefaultParts();
        Email generatedEmail = emailGenerator.generateEmail(templateEmail, data, defaultParts);
        ISerializable iSer = new ISerializable();
        iSer.serializeemail(generatedEmail);
        with open("outputs/result.pdf" as res)
        {
            res.write(generatedEmail);
        }
        _ = Console.ReadKey(); // Tetszőleges gomb lenyomásával kilépünk a programból
        return 0;
    }
}
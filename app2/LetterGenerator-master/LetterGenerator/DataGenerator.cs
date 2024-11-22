using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URX5VP
{
    internal class DataGenerator
    {

        static readonly DateTime BeginDate = new DateTime(2024, 1, 1);
        static readonly DateTime EndDate = new DateTime(2025, 12, 28);

        static readonly int Minimum = 0;
        static readonly int Maximum = 999990;


        public static DateTime GetBeginDate() => BeginDate;
        public static DateTime GetEndDate() => EndDate;

        public static int GetMinimum() => Minimum;
        public static int GetMaximum() => Maximum;

        public static string GenerateRandomDate()
        {
            Random random = new Random();
            int range = (EndDate - BeginDate).Days;
            DateTime randomDate = BeginDate.AddDays(random.Next(range));
            return randomDate.ToString("yyyy. MMMM dd.", new CultureInfo("hu-HU"));
        }

        public static string GenerateRandomAmount()
        {
            Random random = new Random();
            int baseAmount = random.Next(100000, 999990);
            int adjustedAmount = baseAmount - baseAmount % 1000 + 990;
            return adjustedAmount.ToString("N0", new CultureInfo("hu-HU")).Replace(",", " ");
        }

        public static string GenerateRandomReference()
        {
            Random random = new Random();
            return $"ADÓ{random.Next(100000, 999999)}";
        }
    }
}

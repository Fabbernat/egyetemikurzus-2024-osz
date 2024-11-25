using System;

using KorlevelGenerator.source;

namespace URX5VP
{
    public static class LINQOperations
    {
        public static IEnumerable<Email> FilterAndSortEmails(List<Email> Emails)
        {
            var result = Emails
                .Where(Email => Email.Date.Year == DateTime.Now.Year)
                .OrderBy(Email => Email.Date);


            return result;
        }
    }
}
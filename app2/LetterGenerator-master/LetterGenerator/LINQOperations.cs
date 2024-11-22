using System;

using KorlevelGenerator.source;

namespace URX5VP
{
    public static class LINQOperations
    {
        public static IEnumerable<Letter> FilterAndSortLetters(List<Letter> letters)
        {
            var result = letters
                .Where(letter => letter.Date.Year == DateTime.Now.Year)
                .OrderBy(letter => letter.Date);


            return result;
        }
    }
}
using System;
using System.Linq;

namespace LinQExample
{
    internal class Program
    {
        static void Main()
        {
            string[] teams = {"Бавария", "Боруссия", "Реал Мадрид", "Манчестер сити", "ПСЖ", "Барселона"};

            var selectTeams = teams.Where(t => t.ToUpper().StartsWith("Б")).OrderBy(t => t);

            foreach (var s in selectTeams)
            {
                Console.WriteLine(s);
            }
        }
    }
}

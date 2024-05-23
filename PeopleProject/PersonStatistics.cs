using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleProject
{
    public class PersonStatistics
    {
        private List<Person> Szemelyek { get; }

        public PersonStatistics(List<Person> szemelyek)
        {
            Szemelyek = szemelyek ?? throw new ArgumentNullException(nameof(szemelyek));
        }

        public double AtlagKor()
        {
            return Szemelyek.Any() ? Szemelyek.Average(p => p.Kor) : 0;
        }

        public int DiakokSzama()
        {
            return Szemelyek.Count(p => p.Diak);
        }

        public Person LegmagasabbPontszam()
        {
            return Szemelyek.OrderByDescending(p => p.Pontszam).FirstOrDefault();
        }

        public double DiakokAtlagPontszama()
        {
            var diakok = Szemelyek.Where(p => p.Diak).ToList();
            return diakok.Any() ? diakok.Average(p => p.Pontszam) : 0;
        }

        public Person LegidosebbDiak()
        {
            return Szemelyek.Where(p => p.Diak).OrderByDescending(p => p.Kor).FirstOrDefault();
        }

        public bool BarmelyikBukik()
        {
            return Szemelyek.Any(p => p.Pontszam < 40);
        }
    }
}

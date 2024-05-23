using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using PeopleProject;


namespace TestPeopleProject
{
    public class SzemelyStatisztikaTeszt
    {
        private List<Person> szemelyek;
        private PersonStatistics stat;

        [SetUp]
        public void Init()
        {
            szemelyek = new List<Person>
            {
                new Person { Id = 1, Nev = "John Doe", Kor = 25, Diak = true, Pontszam = 80 },
                new Person { Id = 2, Nev = "Jane Smith", Kor = 30, Diak = false, Pontszam = 70 },
                new Person { Id = 3, Nev = "Bob Brown", Kor = 22, Diak = true, Pontszam = 90 },
                new Person { Id = 4, Nev = "Alice Green", Kor = 35, Diak = false, Pontszam = 50 },
                new Person { Id = 5, Nev = "Charlie Black", Kor = 28, Diak = true, Pontszam = 30 }
            };
            stat = new PersonStatistics(szemelyek);
        }
 
        [Test]
        public void AtlagKor1()
        {
            double atlagKor = stat.AtlagKor();
            Assert.That(atlagKor, Is.EqualTo(28));

        }

        [Test]
        public void DiakokSzama1()
        {
            int diakok = stat.DiakokSzama();
            Assert.That(diakok, Is.EqualTo(3));
        }

        [Test]
        public void LegmagasabbPontszam1()
        {
            Person legjobb = stat.LegmagasabbPontszam();
            Assert.That(legjobb.Id, Is.EqualTo(3));
        }

        [Test]
        public void DiakokAtlagPontszama1()
        {
            double atlagPontszam = stat.DiakokAtlagPontszama();
            Assert.That(atlagPontszam, Is.EqualTo(66.67).Within(0.01));
        }

        [Test]
        public void LegidosebbDiak1()
        {
            Person legidosebbDiak = stat.LegidosebbDiak();
            Assert.That(legidosebbDiak.Id, Is.EqualTo(1));
        }

        [Test]
        public void BarmelyikBukik1()
        {
            bool vanBukott = stat.BarmelyikBukik();
            Assert.That(vanBukott, Is.True);
        } 

    }
}
 
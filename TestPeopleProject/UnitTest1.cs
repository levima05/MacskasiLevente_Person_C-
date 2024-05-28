using NUnit.Framework;
using System.Collections.Generic;
using PeopleProject;

namespace TestPeopleProject
{
    public class PersonStatisticsTests
    {
        private List<Person> people;
        private PersonStatistics stats;

        [SetUp]
        public void Init()
        {
            people = new List<Person>
            {
                new Person { Id = 1, Name = "John Doe", Age = 25, IsStudent = true, Score = 80 },
                new Person { Id = 2, Name = "Jane Smith", Age = 30, IsStudent = false, Score = 70 },
                new Person { Id = 3, Name = "Bob Brown", Age = 22, IsStudent = true, Score = 90 },
                new Person { Id = 4, Name = "Alice Green", Age = 35, IsStudent = false, Score = 50 },
                new Person { Id = 5, Name = "Charlie Black", Age = 28, IsStudent = true, Score = 30 }
            };
            stats = new PersonStatistics(people);
        }

        [Test]
        public void GetAverageAge()
        {
            double averageAge = stats.GetAverageAge();
            Assert.That(averageAge, Is.EqualTo(28));
        }

        [Test]
        public void GetAverageAge2()
        {
            stats.People = new List<Person>();
            double averageAge = stats.GetAverageAge();
            Assert.That(averageAge, Is.EqualTo(0));
        }

        [Test]
        public void GetNumberOfStudents()
        {
            int numberOfStudents = stats.GetNumberOfStudents();
            Assert.That(numberOfStudents, Is.EqualTo(3));
        }

        [Test]
        public void GetHighestScore()
        {
            Person highestScorer = stats.GetPersonWithHighestScore();
            Assert.That(highestScorer.Id, Is.EqualTo(3));
        }

        [Test]
        public void GetAverageScore()
        {
            double averageScore = stats.GetAverageScoreOfStudents();
            Assert.That(averageScore, Is.EqualTo(66.67).Within(0.01));
        }

        [Test]
        public void GetOldestStudent()
        {
            Person oldestStudent = stats.GetOldestStudent();
            Assert.That(oldestStudent.Id, Is.EqualTo(1));
        }

        [Test]
        public void IsAnyoneFailing()
        {
            bool isFailing = stats.IsAnyoneFailing();
            Assert.That(isFailing, Is.True);
        }

        [Test]
        public void IsAnyoneFailing2()
        {
            stats.People = new List<Person>
            {
                new Person { Id = 1, Name = "John Doe", Age = 25, IsStudent = true, Score = 80 },
                new Person { Id = 2, Name = "Jane Smith", Age = 30, IsStudent = false, Score = 70 }
            };
            bool isFailing = stats.IsAnyoneFailing();
            Assert.That(isFailing, Is.False);
        }
    }
}

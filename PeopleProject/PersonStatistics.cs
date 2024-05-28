using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleProject
{
    public class PersonStatistics
    {
        private List<Person> people;

        public List<Person> People
        {
            get => people;
            set => people = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PersonStatistics(List<Person> people)
        {
            People = people ?? throw new ArgumentNullException(nameof(people));
        }

        public double GetAverageAge()
        {
            return People.Any() ? People.Average(p => p.Age) : 0;
        }

        public int GetNumberOfStudents()
        {
            return People.Count(p => p.IsStudent);
        }

        public Person GetPersonWithHighestScore()
        {
            return People.OrderByDescending(p => p.Score).FirstOrDefault();
        }

        public double GetAverageScoreOfStudents()
        {
            var students = People.Where(p => p.IsStudent).ToList();
            return students.Any() ? students.Average(p => p.Score) : 0;
        }

        public Person GetOldestStudent()
        {
            return People.Where(p => p.IsStudent).OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public bool IsAnyoneFailing()
        {
            return People.Any(p => p.Score < 40);
        }
    }
}

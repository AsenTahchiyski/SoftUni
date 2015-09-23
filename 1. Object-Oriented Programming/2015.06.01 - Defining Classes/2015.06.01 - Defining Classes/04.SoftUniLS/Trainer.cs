using System;

namespace SULS.Trainers
{
    class Trainer : Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public void CreateCourse(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
	        {
		        throw new ArgumentNullException("Course name cannot be empty.");
	        }
            Console.WriteLine("Course \"{0}\" has been created.", courseName);
        }
    }
}

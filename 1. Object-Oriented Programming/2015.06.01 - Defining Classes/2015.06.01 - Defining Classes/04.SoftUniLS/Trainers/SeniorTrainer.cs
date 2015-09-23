using System;

namespace SULS.Trainers
{
    class SeniorTrainer : Trainer
    {
        private string firstName;
        private string lastName;
        private int age;

        public SeniorTrainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public void DeleteCourse(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
            {
                throw new ArgumentNullException("Course name cannot be empty.");
            }
            Console.WriteLine("Course \"{0}\" has been deleted.", courseName);
        }
    }
}

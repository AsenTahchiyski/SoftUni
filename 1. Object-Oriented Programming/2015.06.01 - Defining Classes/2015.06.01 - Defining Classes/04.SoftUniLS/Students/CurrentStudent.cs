using System;

namespace SULS.Students.Current
{
    class CurrentStudent : Student
    {
        private string currentCourse;
        private string studentNum;
        private double avgGrade;
        private string firstName;
        private string lastName;
        private int age;

        public CurrentStudent(string firstName, string lastName, int age, string studentNum, double avgGrade, string currCourse) 
            : base (firstName, lastName, age, studentNum, avgGrade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.StudentNumber = studentNum;
            this.AverageGrade = avgGrade;
            this.CurrentCourse = currCourse;
        }
        
        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Current course cannot be empty.");
                }
                this.currentCourse = value;
            }
        }
    }
}

namespace _1.StudentsAndCourses
{
    using System;

    public class Student : IComparable
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(object obj)
        {
            return string.Compare(LastName, ((Student) obj).LastName, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return this.FirstName + ' ' + this.LastName;
        }
    }
}

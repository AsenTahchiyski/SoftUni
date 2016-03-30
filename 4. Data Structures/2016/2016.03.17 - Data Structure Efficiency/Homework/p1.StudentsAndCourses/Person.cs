using System;

namespace p1.StudentsAndCourses
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            int lastNames = this.LastName.CompareTo(other.LastName);
            if (lastNames != 0)
            {
                return lastNames;
            }
            else
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
        }

        public override string ToString()
        {
            return this.FirstName + ' ' + this.LastName;
        }
    }
}

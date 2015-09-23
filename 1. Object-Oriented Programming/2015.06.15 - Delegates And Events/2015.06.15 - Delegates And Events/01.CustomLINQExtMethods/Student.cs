namespace CustomLINQExtMethods
{
    using System;
    using System.Collections.Generic;

    public struct Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(string name, int grade) : this()
        {
            this.Name = name;
            this.Grade = grade;
        }
    }
}

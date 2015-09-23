using System;
using System.Linq;

namespace Persons
{
    public class Person
    {
        // fields
        private string name;
        private int age;
        private string email;

        // constructors
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public Person(string name, int age) : this (name, age, null)
        {
        }

        // properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                else this.name = value; 
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 100.");
                }
                else this.age = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.email = null;
                }
                else if (!value.Contains('@'))
                {
                    throw new ArgumentOutOfRangeException("Invalid email.");
                }
                else this.email = value;
            }
        }
        // method
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                return string.Format("Name: {0}; Age: {1}", this.Name, this.Age);
            }
            else
            {
                return string.Format("Name: {0}; Age: {1}; Email: {2}", this.Name, this.Age, this.email);
            }
        }
    }
}

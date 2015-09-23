using System;
using System.Linq;

namespace _02.Animals
{
    abstract public class Animal
    {
        private string name;
        private int age;
        private string gender;
        private readonly string[] genders = { "Male", "Female" };
        
        public string Name 
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                this.name = value;
            }
        }
        public int Age 
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative.");
                }
                this.age = value;
            }
        }
        public string Gender 
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                if (!genders.Contains(value))
                {
                    throw new ArgumentOutOfRangeException("Gender should be either Male or Female.");
                }
                this.gender = value;
            }
        }

    }
}

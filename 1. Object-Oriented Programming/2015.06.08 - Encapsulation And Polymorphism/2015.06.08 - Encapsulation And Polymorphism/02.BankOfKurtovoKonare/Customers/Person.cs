namespace BankOfKurtovoKonare.Customers
{
    using System;
    using BankOfKurtovoKonare.Interfaces;

    public class Person : Customer, IPerson
    {
        private string fName;
        private string lName;
        private int age;
        private string egn;

        private readonly int minAge = 14;
        private readonly int maxAge = 120;

        public Person(string address, string phone, string fName, string lName, int age, string egn) : base(address, phone)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
            this.EGN = egn;
            this.Type = CustomerType.Person;
        }

        public string FirstName 
        {
            get
            {
                return this.fName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be empty.");
                }
                this.fName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty.");
                }
                this.lName = value;
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
                if (value < minAge || value > maxAge)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Age should be between {0} and {1}.", minAge, maxAge));
                }
                this.age = value;
            }
        }

        public string EGN
        {
            get
            {
                return this.egn;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("EGN cannot be empty.");
                }
                this.egn = value;
            }
        }

    }
}

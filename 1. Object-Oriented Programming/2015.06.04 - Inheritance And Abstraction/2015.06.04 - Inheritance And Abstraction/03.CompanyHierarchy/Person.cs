using System;

namespace CompanyHierarchy
{
    abstract class Person
    {
        private string id;
        private string fName;
        private string lName;

        public string ID 
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ID cannot be empty.");
                }
                this.id = value;
            }
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
    }
}

using System;
using System.Linq;

namespace CompanyHierarchy
{
    abstract class Employee : Person, IEmployee
    {
        private string dept;
        private decimal salary;
        
        public string Department
        {
            get
            {
                return this.dept;
            }
            protected set
            {
                string[] departments = { "Production", "Accounting", "Sales", "Marketing" };
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Department cannot be empty.");
                }
                else if (!departments.Contains(value))
                {
                    throw new ArgumentOutOfRangeException("Specified department does not exist.");
                }
                this.dept = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative.");
                }
                this.salary = value;
            }
        }
    }
}

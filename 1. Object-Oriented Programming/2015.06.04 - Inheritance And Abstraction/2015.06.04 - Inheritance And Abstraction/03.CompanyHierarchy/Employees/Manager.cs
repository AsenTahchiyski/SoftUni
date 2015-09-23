using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Manager : Employee, IManager
    {
        public List<Employee> Subordinates { get; set; }

        public Manager(string fName, string lName, string id, string department, decimal salary, List<Employee> subordinates)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.ID = id;
            this.Department = department;
            this.Salary = salary;
            this.Subordinates = subordinates;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("ID {2}: {0} {1} (Department {3})", this.FirstName, this.LastName, this.ID, this.Department));
            output.AppendLine(string.Format("Department {1}, Salary: {0} BGN", this.Salary, this.Department));
            foreach (var emp in Subordinates)
            {
                output.AppendLine(string.Format("--> Subordinate: {0} {1} (ID: {2}", emp.FirstName, emp.LastName, emp.ID));
            }
            return output.ToString();
        }
    }
}

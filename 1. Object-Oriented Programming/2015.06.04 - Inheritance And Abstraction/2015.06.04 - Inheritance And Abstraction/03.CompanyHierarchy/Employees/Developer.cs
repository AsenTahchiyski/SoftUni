using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyHierarchy
{
    class Developer : Employee, IDeveloper
    {
        public List<Project> Projects { get; set; }

        public Developer(string fName, string lName, string id, decimal salary, string department, List<Project> projects)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.ID = id;
            this.Projects = projects;
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("ID {2}: {0} {1} (Department {3})", this.FirstName, this.LastName, this.ID, this.Department));
            output.AppendLine(string.Format("Salary: {0} BGN", this.Salary));
            foreach (var prj in this.Projects)
            {
                output.AppendLine(string.Format(">>> Project: {0} ({1})", prj.ProjectName, prj.State));
                output.AppendLine(string.Format("--> Start date: {0}; Details: {1}", prj.StartDate, prj.Details));
            }
            return output.ToString();
        }
    }
}

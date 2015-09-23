using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class SalesEmployee : Employee, ISalesEmployee
    {
        public List<Sale> Sales { get; set; }

        public SalesEmployee(string fName, string lName, string id, decimal salary, string department, List<Sale> sales)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.ID = id;
            this.Sales = sales;
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("ID {2}: {0} {1} (Department {3})", this.FirstName, this.LastName, this.ID, this.Department));
            output.AppendLine(string.Format("Salary: {0} BGN", this.Salary));
            foreach (var sale in this.Sales)
            {
                output.AppendLine(string.Format(">>> {2}: Product: {0} ({1})", sale.ProductName, sale.Price, sale.Date));
            }
            return output.ToString();
        }
    }
}

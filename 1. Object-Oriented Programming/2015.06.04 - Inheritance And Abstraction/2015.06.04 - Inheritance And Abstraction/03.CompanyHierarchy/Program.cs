using System;
using System.Collections.Generic;

namespace CompanyHierarchy
{
    class Program
    {
        static void Main()
        {
            Manager manager1 = new Manager("Maya", "Yosifova", "MNG002", "Marketing", 2500M,
                new List<Employee>());
            Manager manager2 = new Manager("Kamen", "Bobrev", "MNG001", "Production", 3500,
                new List<Employee>());
            Manager manager3 = new Manager("Boris", "Vasilev", "MNG003", "Sales", 2800,
                new List<Employee>());
            Manager manager4 = new Manager("Radi", "Nalazov", "MNG003", "Accounting", 2400,
               new List<Employee>());

            Developer dev1 = new Developer("Ivan", "Ganchev", "DEV001", 2000, "Production", new List<Project>());
            Developer dev2 = new Developer("Svetoslav", "Vishkov", "DEV002", 2500, "Production", new List<Project>());
            Developer dev3 = new Developer("Ivana", "Manova", "DEV003", 2200, "Production", new List<Project>());
            Developer dev4 = new Developer("Vladimir", "Peynov", "DEV004", 2200, "Production", new List<Project>());

            SalesEmployee sales1 = new SalesEmployee("Ana", "Pancheva", "SAL001", 1800, "Sales", new List<Sale>());
            SalesEmployee sales2 = new SalesEmployee("Rosica", "Gurdeva", "SAL002", 1900, "Sales", new List<Sale>());
            SalesEmployee sales3 = new SalesEmployee("Jivko", "Kosev", "SAL003", 1700, "Sales", new List<Sale>());
            SalesEmployee sales4 = new SalesEmployee("Antoniya", "Argirova", "SAL004", 1850, "Sales", new List<Sale>());

            List<Person> allEmployees = new List<Person>();
            allEmployees.Add(manager1);
            allEmployees.Add(manager2);
            allEmployees.Add(manager3);
            allEmployees.Add(manager4);
            allEmployees.Add(dev1);
            allEmployees.Add(dev2);
            allEmployees.Add(dev3);
            allEmployees.Add(dev4);
            allEmployees.Add(sales1);
            allEmployees.Add(sales2);
            allEmployees.Add(sales3);
            allEmployees.Add(sales4);

            foreach (var person in allEmployees)
            {
                Console.WriteLine("(ID {2}) {0} {1} ({3})", person.FirstName, person.LastName, person.ID, person.GetType().Name);
            }
        }
    }
}

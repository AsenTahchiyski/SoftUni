using System;

namespace p2.EmployeeDAOClass
{
    class Program
    {
        static void Main()
        {
            //var testEmp = DAO.FindByKey(1);
            //Console.WriteLine(testEmp.FirstName);
            //testEmp.FirstName = "Guy";
            //DAO.Modify(testEmp);
            //Console.WriteLine(DAO.FindByKey(1).FirstName);

            var newEmployee = DAO.FindByKey(293);
            Console.WriteLine(newEmployee.FirstName + newEmployee.EmployeeID);
            newEmployee.FirstName = "Gosho";
            DAO.Add(newEmployee);
            var added = DAO.FindByKey(newEmployee.EmployeeID);
            Console.WriteLine(added.FirstName + added.EmployeeID);
        }
    }
}

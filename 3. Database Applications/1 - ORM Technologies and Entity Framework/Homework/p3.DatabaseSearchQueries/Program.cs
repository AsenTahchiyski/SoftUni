using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace p3.DatabaseSearchQueries
{
    class Program
    {
        private static SoftUniEntities context = new SoftUniEntities();

        static void Main()
        {
            // 3.1. Find all employees who have projects started in the time period 2001 - 2003 (inclusive). Select each employee's first name, last name and manager name and each of their projects' name, start date, end date.
            //GetEmployeesWithProjectsStartBetween(2001, 2003, true);

            // 3.2. Find all addresses, ordered by the number of employees who live there (descending), then by town name(ascending).Take only the first 10 addresses and select their address text, town name and employee count.
            //GetAddressesWithMostEmployees(10, true);

            // 3.3. Get an employee by id (e.g. 147). Select only his/her first name, last name, job title and projects (only their names). The projects should be ordered by name (ascending).
            //GetProjectsForEmployee(147, true);

            // 3.4. Find all departments with more than 5 employees. Order them by employee count (ascending). Select the department name, manager name and first name, last name, hire date and job title of every employee.
            //GetDepartmentsWithAtLeastNEmployees(5, true);

            // 4. Native SQL Query - Find all employees who have projects with start date in the year 2002. Select only their first name. Solve this task by using both LINQ query and native SQL query through the context. Measure the difference in performance in both cases with a Stopwatch. Comment out any printing so the measurements can be most accurate.
            //CompareNativeSQLAndLINQPerformance();

            // 5. Concurrent Database Changes with EF - Open two different data contexts and perform concurrent changes on the same records in some database table.
            //TestConcurrentChanges();

            // 6. Call a Stored Procedure - Your task is to create a stored procedure in the SoftUni database for finding all projects for given employee. The procedure should receive first name and last name as arguments. Using EF implement a C# method that calls the stored procedure and returns the result projects' name, description and start date.

            // Create stored procedure in SQL Server Management Studio
            //use SoftUni
            //go
            //create procedure usp_GetProjectsForEmployee @firstName nvarchar(50), @lastName nvarchar(50)
            //as
            //select
            //    p.Name,
            //    p.Description,
            //    p.StartDate
            //from Employees e
            //join EmployeesProjects ep on e.EmployeeID = ep.EmployeeID
            //join Projects p on ep.ProjectID = p.ProjectID
            //where e.FirstName = @firstName and e.LastName = @lastName

            GetProjectsForEmployeeUSP("Ruth", "Ellerbrock", true);
        }

        static object GetEmployeesWithProjectsStartBetween(int startYear, int endYear, bool print = false)
        {
            var result = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year > startYear - 1 && p.StartDate.Year < endYear + 1))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Projects = e.Projects.Select(p => new
                    {
                        p.Name,
                        p.StartDate,
                        p.EndDate
                    }),
                    Manager = context.Employees
                        .Where(m => m.EmployeeID == e.ManagerID)
                        .FirstOrDefault()
                });

            if (print)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine("Employee: {0} {1}", employee.FirstName, employee.LastName);
                    Console.WriteLine("--Manager: {0} {1}", employee.Manager.FirstName, employee.Manager.LastName);
                    Console.WriteLine("---Projects:");
                    foreach (var project in employee.Projects)
                    {
                        Console.WriteLine("----Name: {0}\n Start: {1:dd-MM-yyyy}\n End: {2:dd-MM-yyyy}",
                            project.Name, project.StartDate, project.EndDate);
                    }

                    Console.WriteLine(new string('-', 30));
                }
            }

            return result;
        }

        static object GetAddressesWithMostEmployees(int count, bool print = false)
        {
            var result = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(count)
                .Select(a => new
                {
                    a.AddressText,
                    Town = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                });

            if (print)
            {
                foreach (var address in result)
                {
                    Console.WriteLine("{0}, {1} - {2} employees",
                        address.AddressText, address.Town, address.EmployeesCount);
                }
            }

            return result;
        }

        static object GetProjectsForEmployee(int id, bool print = false)
        {
            var result = context.Employees
                .Where(e => e.EmployeeID == id)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.Projects
                        .Select(p => p.Name)
                        .OrderBy(p => p)
                }).FirstOrDefault();

            if (print)
            {
                Console.WriteLine("{0} {1} ({2})", result.FirstName, result.LastName, result.JobTitle);
                Console.WriteLine("Projects: " + string.Join(", ", result.Projects));
            }

            return result;
        }

        static object GetDepartmentsWithAtLeastNEmployees(int n, bool print = false)
        {
            var result = context.Departments
                .Where(d => d.Employees.Count > n)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    d.Name,
                    Manager = d.Employee.FirstName + " " + d.Employee.LastName,
                    EmployeeCount = d.Employees.Count
                }).ToList();

            if (print)
            {
                Console.WriteLine("Total departments with more than {0} employees: {1}", n, result.Count());
                foreach (var dept in result)
                {
                    Console.WriteLine("-- {0} - Manager: {1}, Employees: {2}",
                        dept.Name, dept.Manager, dept.EmployeeCount);
                }
            }

            return result;
        }

        static void CompareNativeSQLAndLINQPerformance()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var linqResult = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName)
                .OrderBy(e => e);
            stopwatch.Stop();
            Console.WriteLine("LINQ Query took {0} ticks", stopwatch.ElapsedTicks);
            //Console.WriteLine(string.Join(", ", linqResult));
            stopwatch.Reset();

            stopwatch.Start();
            var nativeSqlResult = context.Database
                .SqlQuery<string>(@"
                    select distinct FirstName from Employees e
                    join EmployeesProjects ep on e.EmployeeID = ep.EmployeeID
                    join Projects p on ep.ProjectID = p.ProjectID
                    where datepart(yyyy, p.StartDate) = 2002
                ");
            stopwatch.Stop();
            Console.WriteLine("Native SQL Query took {0} ticks", stopwatch.ElapsedTicks);
            //Console.WriteLine(string.Join(", ", nativeSqlResult));
        }

        static void TestConcurrentChanges()
        {
            var context2 = new SoftUniEntities();
            context.Employees.Where(e => e.EmployeeID == 1).First().FirstName = "Paco";
            context2.Employees.Where(e => e.EmployeeID == 1).First().FirstName = "Minka";
            context.SaveChanges();
            context2.SaveChanges();
            Console.WriteLine((new SoftUniEntities()).Employees.Where(e => e.EmployeeID == 1).First().FirstName);
            // new values are switching on every run
            // no change after concurrency mode == Fixed
        }

        static object GetProjectsForEmployeeUSP(string firstName, string lastName, bool print = false)
        {
            var result = context.usp_GetProjectsForEmployee(firstName, lastName);

            if (print)
            {
                foreach (var project in result)
                {
                    Console.WriteLine("Project Name: {0}\n- {1}\n- Project Start: {2}", project.Name, project.Description, project.StartDate);
                    Console.WriteLine(new string('-', 70));
                }
            }

            return result;
        }
    }
}

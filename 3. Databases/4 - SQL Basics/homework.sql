-- Problem 4.	Write a SQL query to find all information about all departments (use "SoftUni" database).
select * from Departments

-- Problem 5.	Write a SQL query to find all department names.
select Name from Departments

-- Problem 6.	Write a SQL query to find the salary of each employee.
-- Problem 7.	Write a SQL to find the full name of each employee.
select FirstName + ' ' + LastName, Salary from Employees

-- Problem 8.	Write a SQL query to find the email addresses of each employee.
no emails present in the DB

-- Problem 9.	Write a SQL query to find all different employee salaries. 
select distinct Salary from Employees

-- Problem 10.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
select * from Employees
where JobTitle='Sales Representative'

-- Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA".
select FirstName + ' ' + LastName from Employees
where (lower(FirstName) like 'sa%')

-- Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei".
select FirstName + ' ' + LastName from Employees
where (lower(LastName) like '%ei%')

-- Problem 13.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
select FirstName + ' ' + LastName, Salary from Employees
where Salary > 19999.999 and Salary < 30000.01

-- Problem 14.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
select FirstName + ' ' + LastName, Salary from Employees
where Salary in (25000, 14000, 12500, 23600)

-- Problem 15.	Write a SQL query to find all employees that do not have manager.
select FirstName + ' ' + LastName, ManagerID from Employees
where ManagerID is null

-- Problem 16.	Write a SQL query to find all employees that have salary more than 50000. 
-- Order them in decreasing order by salary.
select FirstName + ' ' + LastName, Salary from Employees
where Salary > 50000 order by Salary desc

-- Problem 17.	Write a SQL query to find the top 5 best paid employees.
select top 5 FirstName + ' ' + LastName, Salary from Employees
order by Salary desc

-- Problem 18.	Write a SQL query to find all employees along with their address.
select FirstName + ' ' + LastName, a.AddressText, a. from Employees e
inner join Addresses a on a.AddressID=e.AddressID

-- Problem 19.	Write a SQL query to find all employees and their address.
select FirstName + ' ' + LastName, Addresses.AddressText from Employees
join Addresses on Employees.AddressID=Addresses.AddressID

-- Problem 20.	Write a SQL query to find all employees along with their manager.
select e.FirstName + ' ' + e.LastName as Employee,
m.FirstName + ' ' + m.LastName as Manager 
from Employees e
inner join Employees m on e.ManagerID=m.EmployeeID

-- Problem 21.	Write a SQL query to find all employees, along with their manager and their address.
select e.FirstName + ' ' + e.LastName as Employee,
m.FirstName + ' ' + m.LastName as Manager,
a.AddressText as Address,
t.Name as Town
from Employees e
inner join Employees m on e.ManagerID=m.EmployeeID
inner join Addresses a on e.AddressID=a.AddressID
inner join Towns t on a.TownID=t.TownID

-- Problem 22.	Write a SQL query to find all departments and all town names as a single list.
select Name from Departments
union
select Name from Towns

-- Problem 23.	Write a SQL query to find all the employees and the manager for each of them 
-- along with the employees that do not have manager. 
select 
e.EmployeeID as Employee,
m.EmployeeID as Manager
from Employees m
right outer join
Employees e
on e.ManagerID=m.EmployeeID
---------------------------
select 
e.EmployeeID as Employee,
m.EmployeeID as Manager
from Employees e
left outer join
Employees m 
on e.ManagerID=m.EmployeeID

-- Problem 24.	Write a SQL query to find the names of all employees from the departments 
-- "Sales" and "Finance" whose hire year is between 1995 and 2005.
select e.EmployeeID, d.Name, e.HireDate from Employees e
inner join Departments d 
on e.DepartmentID=d.DepartmentID and 
e.HireDate>='1.1.1995' AND e.HireDate<'1.1.2006'
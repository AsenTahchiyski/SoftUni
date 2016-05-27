-- Problem 1.	Write a SQL query to find the names and salaries of the employees 
-- that take the minimal salary in the company.
select FirstName, LastName, Salary from Employees
where Salary=(select min(Salary) from Employees)

-- Problem 2.	Write a SQL query to find the names and salaries of the employees 
-- that have a salary that is up to 10% higher than the minimal salary for the company.
select FirstName, LastName, Salary from Employees
where Salary<=1.1*(select min(Salary) from Employees)
order by Salary

-- Problem 3.	Write a SQL query to find the full name, salary and department 
-- of the employees that take the minimal salary in their department.
select 
	FirstName + ' ' + LastName as Employee, 
	Salary, 
	d.Name as Department
from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
where Salary=(
	select min(Salary) from Employees
	where e.DepartmentID=DepartmentID)
order by Salary desc

-- Problem 4.	Write a SQL query to find the average salary in the department #1.
select avg(Salary) from Employees
where DepartmentID=1

-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.
select avg(Salary) from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
where e.DepartmentID = (select DepartmentID from Departments where Name='Sales')

-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.
select count(e.EmployeeID) from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
where e.DepartmentID = (select DepartmentID from Departments where Name='Sales')

-- Problem 7.	Write a SQL query to find the number of all employees that have manager.
select count(e.EmployeeID) from Employees e
where e.ManagerID is not null

-- Problem 8.	Write a SQL query to find the number of all employees that have no manager.
select count(e.EmployeeID) from Employees e
where e.ManagerID is null

-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them.
select d.Name, avg(Salary) as AvgSalary from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
group by Name order by Name

-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town. 
select
	t.Name as Town,
	d.Name as Department,
	count(*) as 'Employees count'
from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
join Addresses a on a.AddressID=e.AddressID
join Towns t on t.TownID=a.TownID
group by t.Name, d.Name

-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.
select m.FirstName, m.LastName, count(m.FirstName + m.LastName) as [Employees count]
from Employees e
join Employees m on e.ManagerID = m.EmployeeID
group by m.FirstName, m.LastName
having count(m.FirstName + m.LastName) = 5

-- Problem 12.	Write a SQL query to find all employees along with their managers.
select
	e.FirstName + ' ' + e.LastName as Employee,
	case when e.ManagerID is null then '(no manager)'
	else m.FirstName + ' ' + m.LastName end as Manager
from Employees e
left outer join Employees m on e.ManagerID=m.EmployeeID

-- Problem 13.	Write a SQL query to find the names of all employees whose 
-- last name is exactly 5 characters long. 
select e.FirstName + ' ' + e.LastName as Employee
from Employees e where len(e.LastName) = 5

-- Problem 14.	Write a SQL query to display the current date and time in the 
-- following format "day.month.year hour:minutes:seconds:milliseconds". 
select convert(varchar(10),getdate(),104) + ' ' + 
convert(varchar(12),getdate(),114) as DateTime

-- Problem 15.	Write a SQL statement to create a table Users.
create table Users (
	Id int identity not null,
	Username varchar(50) unique not null,
	[Password] varchar(50) not null check(len([Password]) > 5),
	[Full Name] varchar(50) not null,
	[Last Login] datetime,
	constraint PK_Users primary key(Id))
	
-- Problem 16.	Write a SQL statement to create a view that displays the users 
-- from the Users table that have been in the system today.
create view UV_UsersLoggedToday as
	select * from Users
	where cast([Last Login] as date) = cast(getdate() as date)

-- Problem 17.	Write a SQL statement to create a table Groups. 
create table Groups (
	Id int identity not null,
	Name nvarchar(50) unique not null,
	constraint PK_Groups primary key(Id))
	
-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users.
alter table Users
add GroupId int

-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.
insert into Users (Username, [Password], [Full Name], [Last Login], GroupId)
values
('gicata', 'gicata', 'gicka', 12-05-16, 2),
('sakito', 'sakito', 'sasho', 15-05-16, 3),
('mecata', 'mecata', 'mecko', 16-05-16, 1),
('micata', 'micata', 'mitko', 17-05-16, 2),
('kacata', 'kacata', 'kamen', 17-05-16, 3),
('boicata', 'boicata', 'boiko', 13-05-16, 1)

insert into Groups (Name) values
('MegaGrupata'),
('AA Group'),
('A+ Group')

alter table Users
add constraint FK_Users_Groups
foreign key (GroupId) references Groups(Id)

select 
	Username,
	g.Name as [Group]
from Users u
join Groups g on u.GroupId=g.Id

-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.
update Groups set Name='Updated group' where Id=1

-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.
delete from Users where Id=3

alter table Users
drop constraint FK_Users_Groups

alter table Users
add constraint FK_Users_Groups_Cascade
foreign key (GroupId) references Groups(Id) on delete cascade

delete from Users where Id=4

-- Problem 22.	Write SQL statements to insert in the Users table the names of 
-- all employees from the Employees table.
insert into Users(Username, [Password], [Full Name])
select 
	substring(FirstName, 1, 1) + lower(LastName) + convert(nvarchar, EmployeeId),
	substring(FirstName, 1, 1) + lower(LastName), 
	FirstName + ' ' + LastName
from Employees

-- Problem 23.	Write a SQL statement that changes the password to NULL for all users 
-- that have not been in the system since 10.03.2010.
duplicates task 16

-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).
delete from Users where [Password]=NULL

-- Problem 25.	Write a SQL query to display the average employee salary by department and job title.
select
	d.Name as Department,
	e.JobTitle,
	avg(Salary) as [Average Salary]
from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
group by d.Name, e.JobTitle

-- Problem 26.	Write a SQL query to display the minimal employee salary by department 
-- and job title along with the name of some of the employees that take it.
select
	d.Name as Department,
	e.JobTitle,
	e.FirstName,
	min(Salary) as [Min Salary]
from Employees e
join Departments d on e.DepartmentID=d.DepartmentID
group by d.Name, e.JobTitle, e.FirstName
order by d.Name

-- Problem 27.	Write a SQL query to display the town where maximal number of employees work.
select top 1
	t.Name,
	count(EmployeeId) as [Number of employees]
from Employees e
join Addresses a on e.AddressID=a.AddressID
join Towns t on a.TownID=t.TownID
group by t.Name
order by count(EmployeeId) desc

-- Problem 28.	Write a SQL query to display the number of managers from each town.
select
	t.Name,
	count(*) as Managers
from Employees e
join Addresses a on e.AddressID=a.AddressID
join Towns t on a.TownID=t.TownID
where e.EmployeeID in (select ManagerID from Employees)
group by t.Name

-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.
create table WorkHours (
	Id int identity not null,
	EmployeeId int not null,
	[Date] date not null,
	Task nvarchar(50) not null,
	[Hours] real not null,
	Comments nvarchar(200),
	FK_Employees_WorkHours int foreign key references Employees(EmployeeId),
	constraint PK_WorkHours primary key (Id))

-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.
insert into WorkHours (EmployeeId, [Date], Task, [Hours], Comments) values
(1, '2016.05.18', 'Insert some data', 0.5, 'DB homework'),
(2, '2016.05.17', 'Task 2', 0.5, 'Install and cfg tasker'),
(3, '2016.05.18', 'Task 3', 2.5, 'dependent on task 2'),
(4, '2016.05.18', 'Megaimportant task', 3.1, 'DB homework'),
(5, '2016.05.18', 'Backup DB', 5, 'in the evening'),
(6, '2016.05.18', 'Task 5', 0.5, 'Done'),
(7, '2016.05.18', 'Task 4', 0.6, 'super opisatelen description'),
(8, '2016.05.18', 'Das tasken 6', 0.1, 'Raumschaf'),
(9, '2016.05.18', 'Change water dispenser bottle', 0.05, 'Done'),
(10, '2016.05.18', 'Approve salary indexing', 2, 'Check what others do')

delete from WorkHours where Id=2

update WorkHours set Task='For Pesho' where Task='Task 4'

-- Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
create table WorkHoursLogs (
	Id int identity not null,
	OldId int not null,
	OldEmployeeId int not null,
	OldDate date not null,
	OldTask nvarchar(50) not null,
	OldHours real not null,
	OldComments nvarchar(200),
	[NewId] int not null,
	NewEmployeeId int not null,
	NewDate date not null,
	NewTask nvarchar(50) not null,
	NewHours real not null,
	NewComments nvarchar(200),
	UserName nvarchar(50) not null,
	ChangedAt datetime not null,
	constraint PK_WorkHoursLogs primary key (Id))
	
-- https://www.simple-talk.com/sql/database-administration/pop-rivetts-sql-server-faq-no.5-pop-on-the-audit-trail/


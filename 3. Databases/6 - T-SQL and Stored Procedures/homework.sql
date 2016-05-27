-- Problem 1.	Create a database with two tables
use [tsql-homework]
go

create procedure usp_FullNames
as
select FirstName + ' ' + LastName as FullName
from Persons
go

-- Problem 2.	Create a stored procedure
use [tsql-homework]
go

create procedure usp_GetPersonsWithMoreThan @Balance money
as
select *
from Persons p
join Accounts a on p.Id=a.PersonId
where a.Balance > @Balance
go

exec usp_GetPersonsWithMoreThan 1000

-- Problem 3.	Create a function with parameters
create function ufn_CalculateInterest(@Sum money, @YearlyInterest real, @TotalMonths int)
returns money
as
begin
	declare @result money;
	set @result = @Sum * (@YearlyInterest / 12) * @TotalMonths;
	return @result;
end
go
--
select p.FirstName, dbo.ufn_CalculateInterest (a.Balance, 1.24, 12)
from Persons p
join Accounts a on a.PersonId = p.Id

-- Problem 4.	Create a stored procedure that uses the function from the previous example.
use [tsql-homework]
go

create procedure usp_GetInterest @AccountId int, @InterestRate real
as
select
	p.FirstName,
	dbo.ufn_CalculateInterest(a.Balance, @InterestRate, 1)
from Persons p
join Accounts a on a.PersonId = p.Id
where a.Id = @AccountId

exec usp_GetInterest @AccountId = 1, @InterestRate = 1.2

-- Problem 5.	Add two more stored procedures WithdrawMoney and DepositMoney.
-- WITHDRAW
use [tsql-homework]
go

create procedure usp_WithdrawMoney @AccountId int, @WithdrawAmount money
as
begin
	begin tran
		declare @CurrentAmount money;
		select @CurrentAmount = Balance from Accounts
		where Id = @AccountId
		if @CurrentAmount < @WithdrawAmount
		begin
			print 'Amount to withdraw larger than available amount.'
			rollback
		end
		else
		begin
			update Accounts
			set Balance = @CurrentAmount - @WithdrawAmount
			where Id = @AccountId
			commit
		end
end

exec usp_WithdrawMoney @AccountId = 1, @WithdrawAmount = 99
select * from Accounts where Id = 1
drop procedure usp_WithdrawMoney

-- DEPOSIT
use [tsql-homework]
go

create procedure usp_DepositMoney @AccountId int, @DepositAmount money
as
begin
	begin tran
		declare @CurrentAmount money;
		select @CurrentAmount = Balance from Accounts
		where Id = @AccountId
		update Accounts
		set Balance = @CurrentAmount + @DepositAmount
		where Id = @AccountId
		commit
end

exec usp_DepositMoney @AccountId = 1, @DepositAmount = 10000
select * from Accounts where Id = 1

-- Problem 6.	Create table Logs.
create table Logs(
	Id int identity not null,
	AccountId int not null,
	OldSum money not null,
	NewSum money not null,
	constraint PK_Logs primary key(Id))

create trigger tr_Accounts_Audit
on Accounts for update as
insert into Logs
	select 
	d.Id,
	d.Balance,
	i.Balance
	from deleted d, inserted i
go

-- Problem 7.	Define function in the SoftUni database.
FTS

-- Problem 8.	Using database cursor write a T-SQL
-- http://www.sqlshack.com/sql-server-cursor-tutorial/

DECLARE @ITEM_ID uniqueidentifier  -- Here we create a variable that will contain the ID of each row.
 
DECLARE ITEM_CURSOR CURSOR  -- Here we prepare the cursor and give the select statement to iterate through
FOR
SELECT ITEM_ID
FROM #ITEMS
 
OPEN ITEM_CURSOR -- This charges the results to memory
 
FETCH NEXT FROM ITEM_CURSOR INTO @ITEM_ID -- We fetch the first result
 
WHILE @@FETCH_STATUS = 0 --If the fetch went well then we go for it
BEGIN
 
SELECT ITEM_DESCRIPTION -- Our select statement (here you can do whatever work you wish)
FROM #ITEMS
WHERE ITEM_ID = @ITEM_ID -- In regards to our latest fetched ID
 
FETCH NEXT FROM ITEM_CURSOR INTO @ITEM_ID -- Once the work is done we fetch the next result
 
END
-- We arrive here when @@FETCH_STATUS shows there are no more results to treat
CLOSE ITEM_CURSOR  
DEALLOCATE ITEM_CURSOR -- CLOSE and DEALLOCATE remove the data from memory and clean up the process
- See more at: http://www.sqlshack.com/sql-server-cursor-tutorial/#sthash.s0QGYAo9.dpuf
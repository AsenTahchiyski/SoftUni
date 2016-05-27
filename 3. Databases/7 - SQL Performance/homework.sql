-- Problem 1.	Create a table in SQL Server
create table Entries (
	Id int identity not null,
	[Date] datetime not null,
	constraint PK_Entries primary key(Id))
go

declare @Counter int = 10000000;
declare @StartDate datetime = '1990-1-1';
while (@Counter > 0)
begin
	insert into Entries ([Date]) 
	values (@StartDate)
	set @Counter = @Counter - 1;
	set @StartDate = dateadd(minute, 1, @StartDate)
end
go

-- running time 49 minutes

select * from Entries
where [Date] > '1996-1-1' and [Date] < '1997-1-31'
-- running time 5s

-- Problem 2.	Add an index to speed-up the search by date 
create nonclustered index ix_EntryDates
on Entries([Date])
go
-- running time 8s

DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE
go

select * from Entries
where [Date] > '1997-1-1' and [Date] < '1998-1-31'

-- running time 6s

-- Problem 3.	Create the same table in MySQL
CREATE TABLE `test`.`entries` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Date` DATETIME NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC));
  
MySQL sucks
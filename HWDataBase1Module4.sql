/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [Id]
      ,[ChiefId]
      ,[Name]
      ,[Salary]
      ,[DepartmentId]
  FROM [HumanResources].[dbo].[Employee]
  --Отсортированный в обратном порядке список отделов с количеством сотрудников
  select count([Employee].[Id]) as CountEmployee,[Department].[Name]
  from [HumanResources].[dbo].[Employee]
  inner join [Department] on [Employee].[DepartmentId]=[Department].Id
  group by [Employee].[DepartmentId],[Department].[Name]
  Order by count([Employee].[Id]) desc
    --Вывести список сотрудников, получающих заработную плату большую чем у непосредственного руководителя

	SELECT e.[Id],e.[Name] as EmployeeName, e.Salary ,
	eB.[Name] as BossName, eB.Salary as BossSalary
	FROM [Employee] as e
	LEFT JOIN [Employee] eB ON e.ChiefId=eB.id
	WHERE e.Salary>eB.Salary
--Вывести список отделов, количество сотрудников в которых не превышает 3 человек
  select count([Employee].[Id]) as CountEmployee,[Department].[Name]
  from [HumanResources].[dbo].[Employee]
  inner join [Department] on [Employee].[DepartmentId]=[Department].Id
  group by [Employee].[DepartmentId],[Department].[Name]
   Having count([Employee].[Id])<3
   --Вывести список сотрудников, получающих максимальную заработную плату в своем отделе
  select Max([Employee].[Salary]) as MaxSalary,[Department].[Name]
  from [HumanResources].[dbo].[Employee]
  inner join [Department] on [Employee].[DepartmentId]=[Department].Id
  group by [Employee].[DepartmentId],[Department].[Name]


  select a.*
from Employee as a
where a.Salary >= all (select Max(Salary) from Employee b where b.Id = a.DepartmentId)

 -- Найти список отделов с максимальной суммарной зарплатой сотрудников
   select Sum([Employee].[Salary]) as SumSalaryByDept,[Department].[Name]
  from [HumanResources].[dbo].[Employee]
  inner join [Department] on [Employee].[DepartmentId]=[Department].Id
  group by [Employee].[DepartmentId],[Department].[Name]
  Order by Sum([Employee].[Salary]) Desc
--Вывести список сотрудников, не имеющих назначенного руководителя, работающего в том-же отделе
	SELECT e.[Id],e.[Name] as EmployeeName, e.DepartmentId ,
	eB.[Name] as BossName, eB.DepartmentId as BossSalary
	FROM [Employee] as e
	LEFT JOIN [Employee] eB ON e.ChiefId=eB.id
	WHERE e.DepartmentId!=eB.DepartmentId
--SQL-запрос, чтобы найти вторую самую высокую зарплату работника
Select top 1 * from (Select top 2 * from [Employee] Order by Salary Desc) as tab1 order by tab1.[Salary] asc
USE [HumanResources]
GO

  --Отсортированный в обратном порядке список отделов с количеством сотрудников+

  select count([Employee].[Id]) as CountEmployee,[Department].[Name]
  from [HumanResources].[dbo].[Employee]
  right join [Department] on [Employee].[DepartmentId]=[Department].Id
  group by [Employee].[DepartmentId],[Department].[Name]
  Order by count([Employee].[Id]) desc
   --Вывести список сотрудников, получающих заработную плату большую чем у непосредственного руководителя

	SELECT e.[Id],e.[Name] as EmployeeName, e.Salary ,
	eB.[Name] as BossName, eB.Salary as BossSalary
	FROM [Employee] as e
	LEFT JOIN [Employee] eB ON e.ChiefId=eB.id
	WHERE e.Salary>eB.Salary
--Вывести список отделов, количество сотрудников в которых не превышает 3 человек+

	  SELECT count([Employee].[Id]) as CountEmployee,[Department].[Name]
	  FROM [HumanResources].[dbo].[Employee]
	  RIGHT JOIN [Department] on [Employee].[DepartmentId]=[Department].Id
	  GROUP BY [Employee].[DepartmentId],[Department].[Name]
	  HAVING count([Employee].[Id])<3
   --Вывести список сотрудников, получающих максимальную заработную плату в своем отделе+

		SELECT * 
		FROM Employee AS a
		WHERE a.salary = (
		SELECT MAX(salary) 
		FROM Employee AS max 
		WHERE max.DepartmentId = a.DepartmentId);
 -- Найти список отделов с максимальной суммарной зарплатой сотрудников+

      SELECT TOP 1 Sum([Employee].[Salary]) as SumSalaryByDept,[Department].[Name]
	  FROM [HumanResources].[dbo].[Employee]
	  inner join [Department] on [Employee].[DepartmentId]=[Department].Id
	  GROUP BY [Employee].[DepartmentId],[Department].[Name]
	  ORDER BY Sum([Employee].[Salary]) Desc;

	  WITH dep_salary AS 
		(SELECT [DepartmentId], sum(salary) AS salary
		FROM employee 
		GROUP BY [DepartmentId])
	SELECT [DepartmentId]
	FROM dep_salary
	WHERE dep_salary.salary = (SELECT max(salary) FROM dep_salary);
--Вывести список сотрудников, не имеющих назначенного руководителя, работающего в том-же отделе+

	SELECT e.[Id],e.[Name] as EmployeeName, e.DepartmentId ,
	eB.[Name] as BossName, eB.DepartmentId as BossSalary
	FROM [Employee] as e
	LEFT JOIN [Employee] eB ON e.ChiefId=eB.id
	WHERE e.DepartmentId!=eB.DepartmentId or eB.[Name] is NULL
--SQL-запрос, чтобы найти вторую самую высокую зарплату работника

	SELECT TOP 1 * from (
	SELECT TOP 2 * FROM [Employee] ORDER BY Salary Desc
	) as tab1 
	ORDER BY tab1.[Salary] asc



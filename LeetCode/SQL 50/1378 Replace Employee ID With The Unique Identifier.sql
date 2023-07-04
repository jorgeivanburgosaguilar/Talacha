/*
 1378 Replace Employee ID With The Unique Identifier
 Runtime: 2454 ms, faster than 68.83% of MySQL online submissions.
 Runtime: 1754 ms, faster than 90.9% of MS SQL Server online submissions.
 */
SELECT
  EU.unique_id,
  E.name
FROM
  Employees AS E
  LEFT JOIN EmployeeUNI AS EU ON E.id = EU.id;

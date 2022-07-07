/*
1965 Employees With Missing Information
Runtime: 834 ms, faster than 27.42% of MS SQL Server online submissions for Employees With Missing Information.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Employees With Missing Information.
*/
SELECT      ISNULL(E.employee_id, S.employee_id) AS employee_id
FROM        Employees AS E
FULL JOIN   Salaries AS S ON S.employee_id = E.employee_id
WHERE       E.name IS NULL
OR          S.salary IS NULL
ORDER BY    1 ASC

/*
Runtime: 1559 ms, faster than 5.01% of MySQL online submissions for Employees With Missing Information.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Employees With Missing Information.
*/
SELECT      T.employee_id
FROM        (
                SELECT           E1.employee_id
                                ,name
                                ,salary
                FROM            Employees AS E1
                LEFT JOIN       Salaries AS S1 ON E1.employee_id = S1.employee_id
                UNION
                SELECT           S2.employee_id
                                ,name
                                ,salary
                FROM            Employees AS E2
                RIGHT JOIN      Salaries AS S2 ON S2.employee_id = E2.employee_id
            ) AS T
WHERE       T.name IS NULL
OR          T.salary IS NULL
ORDER BY    1 ASC
/*
176 Second Highest Salary
Runtime: 198 ms, faster than 90.82% of MySQL online submissions for Second Highest Salary.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Second Highest Salary.
*/
SELECT		salary AS SecondHighestSalary
FROM		employee
UNION
SELECT		NULL AS SecondHighestSalary
ORDER BY	1 DESC
LIMIT		1,1

/*
Runtime: 683 ms, faster than 66.91% of MS SQL Server online submissions for Second Highest Salary.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Second Highest Salary.
*/
SELECT TOP 1    T.salary AS SecondHighestSalary
FROM            (
                    SELECT       salary
                                ,ROW_NUMBER() OVER (ORDER BY salary DESC) AS position
                    FROM        employee
                    GROUP BY    salary
                    UNION
                    SELECT       NULL
                                ,2 AS position
                ) AS T
WHERE           T.position = 2
ORDER BY        T.salary DESC
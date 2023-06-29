/*
1873 Calculate Special Bonus
Runtime: 991 ms, faster than 18.90% of MySQL online submissions for Calculate Special Bonus.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Calculate Special Bonus.
*/
SELECT       employee_id
            ,CASE
                WHEN MOD(employee_id, 2) <> 0 AND name NOT LIKE 'M%' THEN salary
                ELSE 0
             END AS bonus
FROM        Employees
ORDER BY    employee_id

/*
Runtime: 1462 ms, faster than 33.00% of MS SQL Server online submissions for Calculate Special Bonus.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Calculate Special Bonus.
*/
SELECT       employee_id
            ,CASE
                WHEN employee_id % 2 <> 0 AND name NOT LIKE 'M%' THEN salary
                ELSE 0
             END AS bonus
FROM        Employees
ORDER BY    employee_id
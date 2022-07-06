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
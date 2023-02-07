/*
1741 Find Total Time Spent by Each Employee
Runtime: 520 ms, faster than 63.32% of MySQL online submissions for Find Total Time Spent by Each Employee.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Find Total Time Spent by Each Employee.
--
Runtime: 684 ms, faster than 56.85% of MS SQL Server online submissions for Find Total Time Spent by Each Employee.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Find Total Time Spent by Each Employee.
*/
SELECT   T.event_day AS day
        ,T.emp_id
        ,(T.out_time - T.in_time) AS total_time
FROM    (
            SELECT       emp_id
                        ,event_day
                        ,SUM(in_time) AS in_time
                        ,SUM(out_time) AS out_time
            FROM        Employees
            GROUP BY    emp_id, event_day
        ) AS T
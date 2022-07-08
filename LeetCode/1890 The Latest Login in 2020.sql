/*
1890 The Latest Login in 2020
Runtime: 609 ms, faster than 70.09% of MySQL online submissions for The Latest Login in 2020.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for The Latest Login in 2020.
--
Runtime: 1779 ms, faster than 62.53% of MS SQL Server online submissions for The Latest Login in 2020.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for The Latest Login in 2020.
*/
SELECT       user_id
            ,MAX(time_stamp) AS last_stamp
FROM        Logins
WHERE       YEAR(time_stamp) = 2020
GROUP BY    user_id
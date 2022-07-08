/*
511 Game Play Analysis I
Runtime: 1277 ms, faster than 5.00% of MySQL online submissions for Game Play Analysis I.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Game Play Analysis I.
--
Runtime: 4450 ms, faster than 6.99% of MS SQL Server online submissions for Game Play Analysis I.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Game Play Analysis I.
*/
SELECT       player_id
            ,MIN(event_date) AS first_login
FROM        Activity
GROUP BY    player_id
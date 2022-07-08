/*
1729 Find Followers Count
Runtime: 1349 ms, faster than 5.89% of MySQL online submissions for Find Followers Count.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Find Followers Count.
--
Runtime: 1423 ms, faster than 36.80% of MS SQL Server online submissions for Find Followers Count.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Find Followers Count.
*/
SELECT       user_id
            ,COUNT(*) as followers_count
FROM        Followers
GROUP BY    user_id
ORDER BY    user_id
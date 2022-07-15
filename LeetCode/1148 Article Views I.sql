/*
1148. Article Views I
Runtime: 394 ms, faster than 80.45% of MySQL online submissions for Article Views I.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Article Views I.
--
Runtime: 1299 ms, faster than 99.63% of MS SQL Server online submissions for Article Views I.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Article Views I.
*/
SELECT      author_id AS id
FROM        Views
WHERE       viewer_id = author_id
GROUP BY	author_id
ORDER BY    1 ASC
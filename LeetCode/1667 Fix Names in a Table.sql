/*
1667 Fix Names in a Table
Runtime: 564 ms, faster than 86.53% of MySQL online submissions for Fix Names in a Table.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Fix Names in a Table.
*/
SELECT       user_id
            ,CONCAT(UCASE(LEFT(name, 1)), LCASE(SUBSTRING(name, 2))) AS name
FROM        Users
ORDER BY    user_id ASC

/*
Runtime: 2151 ms, faster than 43.22% of MS SQL Server online submissions for Fix Names in a Table.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Fix Names in a Table.
*/
SELECT       user_id
            ,UPPER(SUBSTRING(name, 1, 1)) + LOWER(SUBSTRING(name, 2, LEN(name))) AS name
FROM        Users
ORDER BY    user_id ASC
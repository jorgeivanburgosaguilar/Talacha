/*
595 Big Countries
Runtime: 265 ms, faster than 81.14% of MySQL online submissions for Big Countries.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Big Countries.
--
Runtime: 1277 ms, faster than 49.84% of MS SQL Server online submissions for Big Countries.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Big Countries.
*/
SELECT   name
        ,population
        ,area
FROM    World
WHERE   area >= 3000000
OR      population >= 25000000
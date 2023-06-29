/*
1407 Top Travellers
Runtime: 737 ms, faster than 73.10% of MySQL online submissions for Top Travellers.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Top Travellers.
--
Runtime: 1896 ms, faster than 16.93% of MS SQL Server online submissions for Top Travellers.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Top Travellers.
*/
SELECT       U.name
            ,SUM(R.distance) AS travelled_distance
FROM        Rides AS R
INNER JOIN   Users as U ON R.user_id = U.id
GROUP BY    R.user_id
UNION
SELECT       name
            ,0 AS travelled_distance
FROM        Users
WHERE       id NOT IN (SELECT user_id FROM Rides)
ORDER BY    2 DESC, 1 ASC

/*
Runtime: 960 ms, faster than 98.56% of MS SQL Server online submissions for Top Travellers.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Top Travellers.
*/
SELECT       U.name AS name
            ,ISNULL(UR.total_distance, 0) AS travelled_distance
FROM        (
                SELECT       R.user_id
                            ,SUM(R.distance) AS total_distance
                FROM        Rides AS R
                GROUP BY    R.user_id
            ) AS UR
RIGHT JOIN  Users as U ON UR.user_id = U.id
ORDER BY    2 DESC, 1 ASC

/*
Runtime: 1651 ms, faster than 10.98% of MySQL online submissions for Top Travellers.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Top Travellers.
*/
SELECT       U.name AS name
            ,IFNULL(UR.total_distance, 0) AS travelled_distance
FROM        (
                SELECT       R.user_id
                            ,SUM(R.distance) AS total_distance
                FROM        Rides AS R
                GROUP BY    R.user_id
            ) AS UR
RIGHT JOIN  Users as U ON UR.user_id = U.id
ORDER BY    2 DESC, 1 ASC
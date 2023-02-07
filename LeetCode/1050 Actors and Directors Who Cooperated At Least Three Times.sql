/*
1050 Actors and Directors Who Cooperated At Least Three Times
Runtime: 442 ms, faster than 47.53% of MySQL online submissions for Actors and Directors Who Cooperated At Least Three Times.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Actors and Directors Who Cooperated At Least Three Times.
--
Runtime: 1523 ms, faster than 53.42% of MS SQL Server online submissions for Actors and Directors Who Cooperated At Least Three Times.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Actors and Directors Who Cooperated At Least Three Times.
*/
SELECT   T.actor_id
        ,T.director_id
FROM    (
            SELECT       actor_id
                        ,director_id
                        ,COUNT(*) AS total
            FROM        ActorDirector
            GROUP BY    actor_id, director_id
        ) AS T
WHERE   T.total > 2
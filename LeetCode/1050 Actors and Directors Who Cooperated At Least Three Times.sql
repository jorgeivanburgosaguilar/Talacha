/*
1050 Actors and Directors Who Cooperated At Least Three Times

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
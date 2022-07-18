/*
182 Duplicate Emails

*/
SELECT  T.email AS Email
FROM    (
            SELECT       COUNT(*) AS total
                        ,email
            FROM        Person
            GROUP BY    email
        ) AS T
WHERE   T.total > 1
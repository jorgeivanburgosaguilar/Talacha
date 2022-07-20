/*
182 Duplicate Emails
Runtime: 369 ms, faster than 64.85% of MySQL online submissions for Duplicate Emails.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Duplicate Emails.
--
Runtime: 740 ms, faster than 65.25% of MS SQL Server online submissions for Duplicate Emails.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Duplicate Emails.
*/
SELECT  T.email AS Email
FROM    (
            SELECT       COUNT(*) AS total
                        ,email
            FROM        Person
            GROUP BY    email
        ) AS T
WHERE   T.total > 1
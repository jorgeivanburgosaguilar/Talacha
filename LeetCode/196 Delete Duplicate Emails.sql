/*
196 Delete Duplicate Emails
Runtime: 817 ms, faster than 62.40% of MS SQL Server online submissions for Delete Duplicate Emails.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Delete Duplicate Emails.
*/
DELETE FROM Person
WHERE id IN (
                SELECT  P1.id
                FROM    Person AS P1
                WHERE   P1.id NOT IN (
                                        SELECT  MIN(P2.id)
                                        FROM    Person AS P2
                                        GROUP BY P2.email
                                     )
            )


/*
Runtime: 819 ms, faster than 65.00% of MySQL online submissions for Delete Duplicate Emails.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Delete Duplicate Emails.
*/
DELETE FROM Person
WHERE id IN (SELECT id FROM (
                SELECT  P1.id
                FROM    Person AS P1
                WHERE   P1.id NOT IN (
                                        SELECT  MIN(P2.id)
                                        FROM    Person AS P2
                                        GROUP BY P2.email
                                     )
            ) AS T)
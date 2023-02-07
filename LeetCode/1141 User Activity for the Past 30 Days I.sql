/*
1141 User Activity for the Past 30 Days I
Runtime: 633 ms, faster than 30.19% of MySQL online submissions for User Activity for the Past 30 Days I.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for User Activity for the Past 30 Days I.
*/
SELECT       T.activity_date AS day
            ,COUNT(*) AS active_users
FROM        (
                SELECT       A.activity_date
                            ,A.user_id
                            ,COUNT(*) AS visits
                FROM        Activity AS A
                WHERE       A.activity_date <= '2019-07-27'
                AND         A.activity_date > DATE_SUB('2019-07-27', INTERVAL 30 DAY)
                GROUP BY    A.user_id, A.activity_date
            ) AS T
GROUP BY    T.activity_date

/*
Runtime: 1562 ms, faster than 91.64% of MS SQL Server online submissions for User Activity for the Past 30 Days I.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for User Activity for the Past 30 Days I.
*/
SELECT       T.activity_date AS day
            ,COUNT(*) AS active_users
FROM        (
                SELECT       A.activity_date
                            ,A.user_id
                            ,COUNT(*) AS visits
                FROM        Activity AS A
                WHERE       A.activity_date <= '2019-07-27'
                AND         A.activity_date > DATEADD(DAY, -30, '2019-07-27')
                GROUP BY    A.user_id, A.activity_date
            ) AS T
GROUP BY    T.activity_date
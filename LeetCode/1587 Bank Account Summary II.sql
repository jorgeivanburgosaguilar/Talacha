/*
1587 Bank Account Summary II
Runtime: 1286 ms, faster than 17.19% of MySQL online submissions for Bank Account Summary II.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Bank Account Summary II.
--
Runtime: 1253 ms, faster than 9.02% of MS SQL Server online submissions for Bank Account Summary II.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Bank Account Summary II.
*/
SELECT       U.name
            ,T.balance
FROM        (
                SELECT       account
                            ,SUM(amount) AS balance
                FROM        Transactions
                GROUP BY    account
            ) AS T
INNER JOIN  Users AS U ON U.account = T.account
WHERE       T.balance > 10000
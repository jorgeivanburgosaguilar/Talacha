/*
1587 Bank Account Summary II

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
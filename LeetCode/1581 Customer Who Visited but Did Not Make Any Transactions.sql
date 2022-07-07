/*
1581 Customer Who Visited but Did Not Make Any Transactions
Runtime: 4777 ms, faster than 1.01% of MySQL online submissions for Customer Who Visited but Did Not Make Any Transactions.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Customer Who Visited but Did Not Make Any Transactions.
--
Runtime: 3384 ms, faster than 19.35% of MS SQL Server online submissions for Customer Who Visited but Did Not Make Any Transactions.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Customer Who Visited but Did Not Make Any Transactions.
*/
SELECT      V.customer_id
            ,COUNT(*) as count_no_trans
FROM        Visits AS V
LEFT JOIN   Transactions AS T ON T.visit_id = V.visit_id
WHERE       T.transaction_id IS NULL
GROUP BY    V.customer_id
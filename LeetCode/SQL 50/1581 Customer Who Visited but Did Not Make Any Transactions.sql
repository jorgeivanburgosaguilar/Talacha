/*
 1581 Customer Who Visited but Did Not Make Any Transactions
 Runtime: 1903 ms, faster than 24.99% of MySQL online submissions for Customer Who Visited but Did Not Make Any Transactions.
 --
 Runtime: 2431 ms, faster than 65.15% of MS SQL Server online submissions for Customer Who Visited but Did Not Make Any Transactions.
 */
SELECT
  V.customer_id,
  COUNT(*) AS count_no_trans
FROM
  Visits AS V
  LEFT JOIN Transactions AS T ON T.visit_id = V.visit_id
WHERE
  T.transaction_id IS NULL
GROUP BY
  V.customer_id;

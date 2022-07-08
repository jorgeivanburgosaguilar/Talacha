/*
1393. Capital Gain/Loss
Runtime: 469 ms, faster than 78.59% of MySQL online submissions for Capital Gain/Loss.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Capital Gain/Loss.
*/
SELECT       T.stock_name
            ,SUM(T.price) AS capital_gain_loss
FROM        (
                SELECT   stock_name
                        ,CASE
                            WHEN operation = 'Buy' THEN  IF(price > 0, price * -1, price)
                            WHEN operation = 'Sell' THEN price
                            ELSE 0
                         END AS price
                FROM    Stocks
            ) AS T
GROUP BY    T.stock_name

/*
Runtime: 1559 ms, faster than 72.48% of MS SQL Server online submissions for Capital Gain/Loss.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Capital Gain/Loss.
*/
SELECT       T.stock_name
            ,SUM(T.price) AS capital_gain_loss
FROM        (
                SELECT   stock_name
                        ,CASE
                            WHEN operation = 'Buy' THEN  IIF(price > 0, price * -1, price)
                            WHEN operation = 'Sell' THEN price
                            ELSE 0
                         END AS price
                FROM    Stocks
            ) AS T
GROUP BY    T.stock_name
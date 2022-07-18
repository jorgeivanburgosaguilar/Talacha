/*
586 Customer Placing the Largest Number of Orders
Runtime: 870 ms, faster than 18.42% of MySQL online submissions for Customer Placing the Largest Number of Orders.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Customer Placing the Largest Number of Orders.
*/
SELECT      T.customer_number
FROM        (
                SELECT       customer_number
                            ,COUNT(*) AS number_of_orders
                FROM        Orders
                GROUP BY    customer_number
            ) AS T
ORDER BY    T.number_of_orders DESC
LIMIT       1

/*
Runtime: 913 ms, faster than 64.00% of MS SQL Server online submissions for Customer Placing the Largest Number of Orders.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Customer Placing the Largest Number of Orders.
*/
SELECT TOP 1    T.customer_number
FROM            (
                    SELECT       customer_number
                                ,COUNT(*) AS number_of_orders
                    FROM        Orders
                    GROUP BY    customer_number
                ) AS T
ORDER BY        T.number_of_orders DESC
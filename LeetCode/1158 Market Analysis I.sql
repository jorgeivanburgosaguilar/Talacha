/*
1158 Market Analysis I
Runtime: 1350 ms, faster than 46.62% of MySQL online submissions for Market Analysis I.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Market Analysis I.
*/
SELECT       T.buyer_id
            ,U.join_date
            ,SUM(T.order2019) AS orders_in_2019
FROM	    (
                SELECT   buyer_id
                        ,IF(YEAR(order_date) = 2019, 1, 0) AS order2019
                FROM    Orders
            ) AS T
LEFT JOIN   Users AS U on U.user_id = T.buyer_id
GROUP BY    T.buyer_id
UNION
SELECT       user_id AS buyer_id
            ,join_date
            ,0 AS orders_in_2019
FROM        Users
WHERE       user_id NOT IN (SELECT buyer_id FROM Orders GROUP BY buyer_id)

/*
Runtime: 2445 ms, faster than 79.91% of MS SQL Server online submissions for Market Analysis I.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Market Analysis I.
*/
SELECT       MAX(T.buyer_id) AS buyer_id
            ,MAX(U.join_date) AS join_date
            ,SUM(T.order2019) AS orders_in_2019
FROM	    (
                SELECT   buyer_id
                        ,IIF(YEAR(order_date) = 2019, 1, 0) AS order2019
                FROM    Orders
            ) AS T
LEFT JOIN   Users AS U on U.user_id = T.buyer_id
GROUP BY    T.buyer_id
UNION
SELECT       user_id AS buyer_id
            ,join_date
            ,0 AS orders_in_2019
FROM        Users
WHERE       user_id NOT IN (SELECT buyer_id FROM Orders GROUP BY buyer_id)
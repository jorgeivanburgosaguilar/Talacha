/*
1484 Group Sold Products By The Date
Runtime: 360 ms, faster than 95.36% of MySQL online submissions for Group Sold Products By The Date.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Group Sold Products By The Date.
*/
SELECT       T.sell_date
            ,COUNT(T.product) AS num_sold
            ,GROUP_CONCAT(T.product ORDER BY T.product ASC) AS products
FROM        (
                SELECT       A.sell_date
                            ,A.product
                FROM        Activities AS A
                GROUP BY    A.sell_date, A.product
            ) AS T
GROUP BY    T.sell_date
ORDER BY    T.sell_date ASC

/*
Runtime: 1831 ms, faster than 37.27% of MS SQL Server online submissions for Group Sold Products By The Date.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Group Sold Products By The Date.
*/
SELECT       T.sell_date
            ,COUNT(T.product) AS num_sold
            ,STRING_AGG(T.product , ',') WITHIN GROUP (ORDER BY T.product ASC) AS products
FROM        (
                SELECT       A.sell_date
                            ,A.product
                FROM        Activities AS A
                GROUP BY    A.sell_date, A.product
            ) AS T
GROUP BY    T.sell_date
ORDER BY    T.sell_date ASC
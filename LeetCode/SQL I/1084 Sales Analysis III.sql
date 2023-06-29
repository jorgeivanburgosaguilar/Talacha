/*
1084 Sales Analysis III
Runtime: 1943 ms, faster than 13.25% of MySQL online submissions for Sales Analysis III.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Sales Analysis III.
--
Runtime: 5838 ms, faster than 5.06% of MS SQL Server online submissions for Sales Analysis III.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Sales Analysis III.
*/
SELECT       P.product_id
            ,P.product_name
FROM        (
    			SELECT	 	product_id
    			FROM		Sales
    			WHERE		sale_date BETWEEN '2019-01-01' AND '2019-03-31'
    			GROUP BY	product_id
    		) AS S
INNER JOIN  Product AS P on P.product_id = S.product_id
AND         S.product_id NOT IN (
                                    SELECT  product_id
                                    FROM    Sales
                                    WHERE   sale_date NOT BETWEEN '2019-01-01' AND '2019-03-31'
                                )
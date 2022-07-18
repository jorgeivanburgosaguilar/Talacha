/*
1084 Sales Analysis III

*/
SELECT       P.product_id
            ,P.product_name
FROM        Sales AS S
INNER JOIN  Product AS P on P.product_id = S.product_id
WHERE       S.sale_date BETWEEN '2019-01-01' AND '2019-03-31'
AND         S.product_id NOT IN (
                                    SELECT  product_id
                                    FROM    Sales
                                    WHERE   sale_date NOT BETWEEN '2019-01-01' AND '2019-03-31'
                                )
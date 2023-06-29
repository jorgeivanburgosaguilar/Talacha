/*
1757 Recyclable and Low Fat Products
Runtime: 538 ms, faster than 58.74% of MySQL online submissions for Recyclable and Low Fat Products.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Recyclable and Low Fat Products.
--
Runtime: 682 ms, faster than 90.88% of MS SQL Server online submissions for Recyclable and Low Fat Products.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Recyclable and Low Fat Products.
*/
SELECT  product_id
FROM    Products
WHERE   low_fats = 'Y'
AND     recyclable = 'Y'
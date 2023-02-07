/*
183 Customers Who Never Order
Runtime: 417 ms, faster than 88.39% of MySQL online submissions for Customers Who Never Order.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Customers Who Never Order.
*/
SELECT      name AS Customers
FROM        Customers AS C
LEFT JOIN   Orders AS O ON C.id = O.customerID
WHERE       O.id IS NULL

/*
Runtime: 777 ms, faster than 36.90% of MS SQL Server online submissions for Customers Who Never Order.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Customers Who Never Order.
*/
SELECT      name AS Customers
FROM        Customers AS C
WHERE       C.id NOT IN (SELECT O.customerId AS id FROM Orders AS O GROUP BY O.customerId)
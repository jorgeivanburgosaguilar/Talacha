/*
607 Sales Person
Runtime: 966 ms, faster than 96.71% of MySQL online submissions for Sales Person.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Sales Person.
--
Runtime: 912 ms, faster than 89.47% of MS SQL Server online submissions for Sales Person.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Sales Person.
*/
SELECT  name
FROM    SalesPerson
WHERE   sales_id NOT IN (
                            SELECT  sales_id
                            FROM    Orders
                            WHERE   com_id IN   (
                                                    SELECT  com_id
                                                    FROM    Company
                                                    WHERE   name = 'RED'
                                                )
                        )
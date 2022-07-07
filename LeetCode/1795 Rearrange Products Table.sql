/*
1795 Rearrange Products Table
Runtime: 454 ms, faster than 86.79% of MySQL online submissions for Rearrange Products Table.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Rearrange Products Table.
*/
SELECT	 p.product_id
		,'store1' AS store
		,p.store1 AS price
FROM	products AS P
WHERE	p.store1 IS NOT NULL
UNION
SELECT	 p.product_id
		,'store2' AS store
		,p.store2 AS price
FROM	products AS P
WHERE	p.store2 IS NOT NULL
UNION
SELECT	 p.product_id
		,'store3' AS store
		,p.store3 AS price
FROM	products AS P
WHERE	p.store3 IS NOT NULL

/*
Runtime: 714 ms, faster than 51.85% of MS SQL Server online submissions for Rearrange Products Table.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Rearrange Products Table.
*/
SELECT   product_id
        ,stores as store
        ,store as price
FROM    products
UNPIVOT (store FOR stores IN (store1, store2, store3)) AS up
/*
608 Tree Node
Runtime: 396 ms, faster than 81.79% of MySQL online submissions for Tree Node.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Tree Node.
--
Runtime: 1303 ms, faster than 9.09% of MS SQL Server online submissions for Tree Node.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Tree Node.
*/
SELECT	 	 id
			,'Root' AS type
FROM		tree
WHERE		p_id IS NULL
UNION
SELECT		 id
			,'Inner' AS type
FROM		tree
WHERE		id IN (SELECT p_id FROM tree)
AND			p_id IS NOT NULL
UNION
SELECT		 id
			,'Leaf' AS type
FROM		tree
WHERE		id NOT IN (SELECT p_id FROM tree WHERE p_id IS NOT NULL)
AND			p_id IS NOT NULL
ORDER BY	1 ASC
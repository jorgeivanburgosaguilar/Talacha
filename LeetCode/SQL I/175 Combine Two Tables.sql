/*
175 Combine Two Tables
Runtime: 402 ms, faster than 64.02% of MySQL online submissions for Combine Two Tables.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Combine Two Tables.
--
Runtime: 762 ms, faster than 67.83% of MS SQL Server online submissions for Combine Two Tables.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Combine Two Tables.
*/
SELECT		 P.firstName
            ,P.lastName
            ,A.city
            ,A.state
FROM		Person AS P
LEFT JOIN	Address AS A ON A.personId = P.personId
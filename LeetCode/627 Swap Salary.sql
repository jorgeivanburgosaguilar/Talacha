/*
627 Swap Salary
Runtime: 218 ms, faster than 82.75% of MySQL online submissions for Swap Salary.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Swap Salary.
*/
UPDATE  Salary
SET     sex = CASE WHEN sex = 'm' THEN 'f' ELSE 'm' END
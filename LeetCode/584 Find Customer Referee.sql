/*
584 Find Customer Referee
Runtime: 466 ms, faster than 72.96% of MySQL online submissions for Find Customer Referee.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Find Customer Referee.
*/
SELECT  name
FROM    Customer
WHERE   referee_id <> 2
OR      referee_id IS NULL
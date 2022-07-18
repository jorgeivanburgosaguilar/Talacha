/*
197 Rising Temperature
Runtime: 549 ms, faster than 45.82% of MySQL online submissions for Rising Temperature.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Rising Temperature.
*/
SELECT      TODAY.id
FROM        Weather AS TODAY
LEFT JOIN   Weather AS YESTERDAY ON YESTERDAY.recordDate = DATE_SUB(TODAY.recordDate, INTERVAL 1 DAY)
WHERE       TODAY.temperature > YESTERDAY.temperature

/*
Runtime: 896 ms, faster than 52.82% of MS SQL Server online submissions for Rising Temperature.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Rising Temperature.
*/
SELECT      TODAY.id
FROM        Weather AS TODAY
LEFT JOIN   Weather AS YESTERDAY ON YESTERDAY.recordDate = DATEADD(DAY, -1, TODAY.recordDate)
WHERE       TODAY.temperature > YESTERDAY.temperature
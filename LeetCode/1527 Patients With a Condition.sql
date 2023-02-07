/*
1527 Patients With a Condition
Runtime: 287 ms, faster than 86.81% of MySQL online submissions for Patients With a Condition.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Patients With a Condition.
*/
SELECT   patient_id
        ,patient_name
        ,conditions
FROM    Patients
WHERE   conditions REGEXP ' DIAB1[0-9]{2}'
OR      conditions REGEXP '^DIAB1[0-9]{2}'

/*
Runtime: 271 ms, faster than 94.23% of MySQL online submissions for Patients With a Condition.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Patients With a Condition.
--
Runtime: 645 ms, faster than 28.99% of MS SQL Server online submissions for Patients With a Condition.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Patients With a Condition.
*/
SELECT   patient_id
        ,patient_name
        ,conditions
FROM    Patients
WHERE   conditions LIKE '% DIAB1%'
OR      conditions LIKE 'DIAB1%'

/*
Accepted but wrong from my POV
Runtime: 280 ms, faster than 90.12% of MySQL online submissions for Patients With a Condition.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Patients With a Condition.
*/
SELECT   patient_id
        ,patient_name
        ,conditions
FROM    Patients
WHERE   conditions REGEXP 'DIAB1[0-9]{2}'
AND     conditions NOT LIKE 'SADIAB1%'
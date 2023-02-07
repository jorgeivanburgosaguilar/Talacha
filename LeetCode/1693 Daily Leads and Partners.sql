/*
1693 Daily Leads and Partners
Runtime: 556 ms, faster than 61.98% of MySQL online submissions for Daily Leads and Partners.
Memory Usage: 0B, less than 100.00% of MySQL online submissions for Daily Leads and Partners.
--
Runtime: 766 ms, faster than 74.97% of MS SQL Server online submissions for Daily Leads and Partners.
Memory Usage: 0B, less than 100.00% of MS SQL Server online submissions for Daily Leads and Partners.
*/
SELECT       date_id
            ,make_name
            ,COUNT(DISTINCT(lead_id)) AS unique_leads
            ,COUNT(DISTINCT(partner_id)) AS unique_partners
FROM        DailySales
GROUP BY    date_id, make_name
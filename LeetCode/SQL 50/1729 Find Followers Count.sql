/*
 1729 Find Followers Count
 Runtime: 2666 ms, faster than 5.03% of MySQL online submissions.
 Runtime: 1370 ms, faster than 33.37% of MS SQL Server online submissions.
 */
SELECT
  user_id,
  COUNT(*) AS followers_count
FROM
  Followers
GROUP BY
  user_id
ORDER BY
  user_id

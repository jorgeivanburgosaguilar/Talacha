/*
 1683 Invalid Tweets
 Runtime: 1167 ms, faster than 81.9% of MySQL online submissions for Invalid Tweets.
 */
SELECT
  tweet_id
FROM
  Tweets
WHERE
  LENGTH(content) > 15;

/*
 1683 Invalid Tweets
 Runtime: 2215 ms, faster than 11.29% of MS SQL Server online submissions Invalid Tweets.
 */
SELECT
  tweet_id
FROM
  Tweets
WHERE
  LEN(content) > 15;

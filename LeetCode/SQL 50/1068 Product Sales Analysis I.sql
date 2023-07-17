/*
 1068. Product Sales Analysis I
 Runtime: 2078 ms, faster than 57.16% of MySQL online submissions.
 */
SELECT
  P.product_name,
  S.year,
  S.price
FROM
  Sales AS S
  INNER JOIN Product AS P ON S.product_id = P.product_id

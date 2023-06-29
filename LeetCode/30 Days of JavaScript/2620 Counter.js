/*
2620 Counter
Runtime: 51 ms, faster than 87.37% of JavaScript online submissions for Counter.
Memory Usage: 41.7 MB, less than 82.46% of JavaScript online submissions for Counter.
*/
/**
 * @param {number} n
 * @return {Function} counter
 */
var createCounter = function (n) {
  return function () {
    return n++;
  };
};

/**
 * const counter = createCounter(10)
 * counter() // 10
 * counter() // 11
 * counter() // 12
 */

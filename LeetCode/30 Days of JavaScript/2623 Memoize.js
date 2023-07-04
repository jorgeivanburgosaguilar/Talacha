/*
2623 Memoize
Runtime: 369 ms, faster than 28.33% of JavaScript online submissions.
Memory Usage: 108.2 MB, less than 18.18% of JavaScript online submissions.
*/
/**
 * @param {Function} fn
 */
function memoize(fn) {
  const cache = new Map();
  return function (...args) {
    const key = args.join(",");
    if (cache.has(key)) return cache.get(key);
    const result = fn.apply(this, args);
    cache.set(key, result);
    return result;
  };
}

let callCount = 0;
const sum = function (a, b) {
  callCount += 1;
  return a + b;
};
const memoizedSum = memoize(sum);

// Output: 4
console.log(memoizedSum(2, 2));

// Output: 4
console.log(memoizedSum(2, 2));

// Output: 1
console.log(callCount);

// Output: 3
console.log(memoizedSum(1, 2));

// Output: 2
console.log(callCount);

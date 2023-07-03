/*
2666 Allow One Function Call
Runtime: 54 ms, faster than 80.72% of JavaScript online submissions.
Memory Usage: 41.6 MB, less than 80.28% of JavaScript online submissions.
*/
/**
 * @param {Function} fn
 * @return {Function}
 */
var once = function (fn) {
  return function (...args) {
    const result = fn(...args);
    fn = () => undefined;
    return result;
  };
};

let fn = (a, b, c) => a + b + c;
let onceFn = once(fn);

// Output: 6
console.log(onceFn(1, 2, 3));

// Output: undefined
console.log(onceFn(2, 3, 6));

// Output: undefined
console.log(onceFn(3, 4, 9));

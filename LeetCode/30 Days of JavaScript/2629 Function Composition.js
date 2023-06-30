/*
2629 Function Composition
Runtime: 67 ms, faster than 82.33% of JavaScript online submissions.
Memory Usage: 43.1 MB, less than 84.73% of JavaScript online submissions..
*/
/**
 * @param {Function[]} functions
 * @return {Function}
 */
const compose = function (functions) {
  return function (x) {
    const functionsLength = functions.length;
    if (functionsLength < 1) return x;
    let currentValue = x;
    for (i = functionsLength - 1; i >= 0; i--) {
      currentValue = functions[i](currentValue);
    }
    return currentValue;
  };
};

// Output: 9
let fn = compose([(x) => x + 1, (x) => 2 * x]);
console.log(fn(4));

// Output: 65
fn = compose([(x) => x + 1, (x) => x * x, (x) => 2 * x]);
console.log(fn(4));

// Output: 1000
fn = compose([(x) => 10 * x, (x) => 10 * x, (x) => 10 * x]);
console.log(fn(1));

// Output: 42
fn = compose([]);
console.log(fn(42));

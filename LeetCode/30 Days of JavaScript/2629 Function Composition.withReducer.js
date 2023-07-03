/*
2629 Function Composition (with vanilla reducer)
Runtime: 86 ms, faster than 6.24% of JavaScript online submissions.
Memory Usage: 43.3 MB, less than 56.53% of JavaScript online submissions.
*/
/**
 * @param {Function[]} functions
 * @return {Function}
 */
const compose = function (functions) {
  return function (x) {
    return functions.reduceRight(
      (acumulador, valorActual) => valorActual(acumulador),
      x
    );
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

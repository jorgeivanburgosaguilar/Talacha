/*
2724 Sort By
Runtime: 129 ms, faster than 49.21% of JavaScript online submissions.
Memory Usage: 56.33 MB, less than 61.62% of JavaScript online submissions.
*/
/**
 * @param {Array} arr
 * @param {Function} fn
 * @return {Array}
 */
const sortBy = function (arr, fn) {
  return arr.sort((a, b) => fn(a) - fn(b));
};

let arr = [5, 4, 1, 2, 3];
let fn = (x) => x;
console.log(sortBy(arr, fn)); // [1, 2, 3, 4, 5]

arr = [{ x: 1 }, { x: 0 }, { x: -1 }];
fn = (d) => d.x;
console.log(sortBy(arr, fn)); // [{"x": -1}, {"x": 0}, {"x": 1}]

arr = [
  [3, 4],
  [5, 2],
  [10, 1],
];
fn = (x) => x[1];
console.log(sortBy(arr, fn)); // [[10, 1], [5, 2], [3, 4]]

/*
2727 Is Object Empty
Runtime: 43 ms, faster than 93.63% of JavaScript online submissions.
Memory Usage: 43.00 MB, less than 25.28% of JavaScript online submissions.
*/
/**
 * @param {Object|Array} obj
 * @return {boolean}
 */
var isEmpty = function (obj) {
  return Object.keys(obj).length === 0;
};

console.log(isEmpty({ x: 5, y: 42 }));
console.log(isEmpty({}));
console.log(isEmpty([null, false, 0]));
console.log(isEmpty([]));

/*
2619 Array Prototype Last
Runtime: 48 ms, faster than 66.77% of JavaScript online submissions.
Memory Usage: 41.66 MB, less than 56.92% of JavaScript online submissions.
*/
/**
 * @return {null|boolean|number|string|Array|Object}
 */
Array.prototype.last = function () {
  if (this.length > 0) return this.slice(-1)[0];
  return -1;
};

let arr = [1, 2, 3];
console.log(arr.last()); // 3

arr = [null, {}, 3];
console.log(arr.last()); // 3

arr = [];
console.log(arr.last()); // -1

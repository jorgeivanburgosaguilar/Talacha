/*
2695 Array Wrapper
Runtime: 59 ms, faster than 18.48% of JavaScript online submissions.
Memory Usage: 44.12 MB, less than 25.48% of JavaScript online submissions.
*/
/**
 * @param {number[]} nums
 * @return {void}
 */
var ArrayWrapper = function (nums) {
  this.numbers = nums;
};

/**
 * @return {number}
 */
ArrayWrapper.prototype.valueOf = function () {
  let result = 0;
  this.numbers.forEach((element) => (result += element));
  return result;
};

/**
 * @return {string}
 */
ArrayWrapper.prototype.toString = function () {
  return `[${this.numbers.toString()}]`;
};

const obj1 = new ArrayWrapper([1, 2]);
const obj2 = new ArrayWrapper([3, 4]);
console.log(obj1 + obj2); // 10
console.log(String(obj1)); // "[1,2]"
console.log(String(obj2)); // "[3,4]"

const obj = new ArrayWrapper([23, 98, 42, 70]);
console.log(String(obj)); // "[23,98,42,70]"

const obj3 = new ArrayWrapper([]);
const obj4 = new ArrayWrapper([]);
console.log(obj3 + obj4); // 0

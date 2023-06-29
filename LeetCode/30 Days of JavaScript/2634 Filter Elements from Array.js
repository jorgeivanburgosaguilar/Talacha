/*
2634 Filter Elements from Array
Runtime: 61 ms, faster than 40.38% of JavaScript online submissions for Filter Elements from Array.
Memory Usage: 42.3 MB, less than 13.94% of JavaScript online submissions for Filter Elements from Array.
*/
/**
 * @param {number[]} arr
 * @param {Function} fn
 * @return {number[]}
 */
const filter = function (arr, fn) {
  let newArr = new Array();
  for (let x = 0; x < arr.length; x++) {
    if (fn(arr[x], x)) newArr.push(arr[x]);
  }
  return newArr;
};

// Output: [20,30]
console.log(
  filter([0, 10, 20, 30], function greaterThan10(n) {
    return n > 10;
  })
);

// Output: [1]
console.log(
  filter([1, 2, 3], function firstIndex(n, i) {
    return i === 0;
  })
);

// Output: [-2,0,1,2]
console.log(
  filter([-2, -1, 0, 1, 2], function plusOne(n) {
    return n + 1;
  })
);

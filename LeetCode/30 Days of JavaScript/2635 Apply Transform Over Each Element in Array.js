/*
2635 Apply Transform Over Each Element in Array
Runtime: 59 ms, faster than 54.66% of JavaScript online submissions for Apply Transform Over Each Element in Array.
Memory Usage: 42.2 MB, less than 34.22% of JavaScript online submissions for Apply Transform Over Each Element in Array.
*/
/**
 * @param {number[]} arr
 * @param {Function} fn
 * @return {number[]}
 */
const map = function (arr, fn) {
  const arrLength = arr.length;
  let newArr = new Array(arrLength);
  for (let x = 0; x < arrLength; x++) {
    newArr[x] = fn(arr[x], x);
  }
  return newArr;
};

// Output: [2,3,4]
console.log(
  map([1, 2, 3], function plusone(n) {
    return n + 1;
  })
);

// Output: [1,3,5]
console.log(
  map([1, 2, 3], function plusI(n, i) {
    return n + i;
  })
);

// Output: [42,42,42]
console.log(
  map([1, 2, 3], function constant() {
    return 42;
  })
);

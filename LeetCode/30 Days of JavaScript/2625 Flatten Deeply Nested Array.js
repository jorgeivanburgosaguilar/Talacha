/*
2625. Flatten Deeply Nested Array
Runtime: 140 ms, faster than 39.67% of JavaScript online submissions.
Memory Usage: 99.09 MB, less than 40.29% of JavaScript online submissions.
*/
/**
 * @param {Array} arr
 * @param {number} depth
 * @return {Array}
 */
const flat = function (arr, n) {
  if (n <= 0) return arr;
  let flattenedArray = [];

  for (let i = 0; i < arr.length; i++) {
    const currValue = arr[i];

    if (Array.isArray(currValue)) {
      flattenedArray.push(...flat(currValue, n - 1));
    } else {
      flattenedArray.push(currValue);
    }
  }
  return flattenedArray;
};

let arr = [1, 2, 3, [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]];
let n = 0;
// [1, 2, 3, [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]]
console.log(flat(arr, n));

arr = [1, 2, 3, [4, 5, 6], [7, 8, [9, 10, 11], 12], [13, 14, 15]];
n = 1;
// [1, 2, 3, 4, 5, 6, 7, 8, [9, 10, 11], 12, 13, 14, 15]
console.log(flat(arr, n));

arr = [
  [1, 2, 3],
  [4, 5, 6],
  [7, 8, [9, 10, 11], 12],
  [13, 14, 15],
];
n = 2;
// [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
console.log(flat(arr, n));

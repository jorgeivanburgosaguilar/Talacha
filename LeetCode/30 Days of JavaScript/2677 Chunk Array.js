/*
2677 Chunk Array
Runtime: 53 ms, faster than 69.46% of JavaScript online submissions.
Memory Usage: 44.26 MB, less than 67.96% of JavaScript online submissions.
*/
/**
 * @param {Array} arr
 * @param {number} size
 * @return {Array}
 */
const chunk = function (arr, size) {
  let chunked = [];
  const numberOfChunks = Math.ceil(arr.length / size);
  for (let i = 0; i < numberOfChunks; i++) {
    chunked.push(arr.splice(0, size));
  }
  return chunked;
};

// Output: [[1],[2],[3],[4],[5]]
console.log(chunk([1, 2, 3, 4, 5], 1));

// Output: [[1,9,6],[3,2]]
console.log(chunk([1, 9, 6, 3, 2], 3));

// Output: [[8,5,3,2,6]]
console.log(chunk([8, 5, 3, 2, 6], 6));

// Output: []
console.log(chunk([], 1));

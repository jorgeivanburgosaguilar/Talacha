/*
2626 Array Reduce Transformation
Runtime: 74 ms, faster than 5.7% of JavaScript online submissions for Array Reduce Transformation.
Memory Usage: 42.4 MB, less than 51.40% of JavaScript online submissions for Array Reduce Transformation.
*/
/**
 * @param {number[]} nums
 * @param {Function} fn
 * @param {number} init
 * @return {number}
 */
const reduce = function (nums, fn, init) {
  const numsLength = nums.length;
  if (numsLength < 1) return init;

  let value = init;
  for (let x = 0; x < numsLength; x++) {
    value = fn(value, nums[x]);
  }
  return value;
};

// Output: 10
console.log(
  reduce(
    [1, 2, 3, 4],
    function sum(accum, curr) {
      return accum + curr;
    },
    0
  )
);

// Output: 130
console.log(
  reduce(
    [1, 2, 3, 4],
    function sum(accum, curr) {
      return accum + curr * curr;
    },
    100
  )
);

// Output: 25
console.log(
  reduce(
    [],
    function sum(accum, curr) {
      return 0;
    },
    25
  )
);

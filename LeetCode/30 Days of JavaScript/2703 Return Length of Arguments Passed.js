/*
2703 Return Length of Arguments Passed
Runtime: 57 ms, faster than 63.30% of JavaScript online submissions.
Memory Usage: 41.6 MB, less than 79.20% of JavaScript online submissions.
*/
/**
 * @return {number}
 */
var argumentsLength = function (...args) {
  return args.length;
};

// Output: 3
console.log(argumentsLength(1, 2, 3));

// Output: 1
console.log(argumentsLength(5));

// Output: 3
console.log(argumentsLength({}, null, "3"));

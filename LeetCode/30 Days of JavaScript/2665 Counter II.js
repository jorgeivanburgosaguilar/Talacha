/*
2665 Counter II
Runtime: 64 ms, faster than 73.97% of JavaScript online submissions for Counter II.
Memory Usage: 44.5 MB, less than 67.75% of JavaScript online submissions for Counter II.
*/
/**
 * @param {integer} init
 * @return { increment: Function, decrement: Function, reset: Function }
 */
var createCounter = function (init) {
  currentValue = init;
  return {
    increment: function () {
      return ++currentValue;
    },
    decrement: function () {
      return --currentValue;
    },
    reset: function () {
      currentValue = init;
      return currentValue;
    },
  };
};

/**
 * const counter = createCounter(5)
 * counter.increment(); // 6
 * counter.reset(); // 5
 * counter.decrement(); // 4
 */

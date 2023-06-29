/*
2704 To Be Or Not To Be
Runtime: 43 ms, faster than 99.28% of JavaScript online submissions for To Be Or Not To Be.
Memory Usage: 41.8 MB, less than 49.99% of JavaScript online submissions for To Be Or Not To Be.
*/
/**
 * @param {string} val
 * @return {Object}
 */
var expect = function (val) {
  return {
    toBe: function (val2) {
      if (val !== val2) throw "Not Equal";
      return true;
    },
    notToBe: function (val2) {
      if (val !== val2) return true;
      throw "Equal";
    },
  };
};

/**
 * expect(5).toBe(5); // true
 * expect(5).notToBe(5); // throws "Equal"
 */

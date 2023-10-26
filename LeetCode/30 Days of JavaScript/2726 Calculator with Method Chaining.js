/*
2726 Calculator with Method Chaining
Runtime: 52 ms, faster than 42.85% of JavaScript online submissions.
Memory Usage: 41.61 MB, less than 66.49% of JavaScript online submissions.
*/
class Calculator {
  /**
   * @param {number} value
   */
  constructor(value) {
    this.result = value;
  }

  /**
   * @param {number} value
   * @return {Calculator}
   */
  add(value) {
    this.result += value;
    return this;
  }

  /**
   * @param {number} value
   * @return {Calculator}
   */
  subtract(value) {
    this.result -= value;
    return this;
  }

  /**
   * @param {number} value
   * @return {Calculator}
   */
  multiply(value) {
    this.result *= value;
    return this;
  }

  /**
   * @param {number} value
   * @return {Calculator}
   */
  divide(value) {
    if (value == 0) throw new Error("Division by zero is not allowed");
    this.result /= value;
    return this;
  }

  /**
   * @param {number} value
   * @return {Calculator}
   */
  power(value) {
    this.result = this.result ** value;
    return this;
  }

  /**
   * @return {number}
   */
  getResult() {
    return this.result;
  }
}

console.log(new Calculator(10).add(5).subtract(7).getResult()); // 10 + 5 - 7 = 8
console.log(new Calculator(2).multiply(5).power(2).getResult()); // (2 * 5) ^ 2 = 100
try {
  new Calculator(20).divide(0).getResult(); // 20 / 0
} catch (error) {
  console.log(error);
}

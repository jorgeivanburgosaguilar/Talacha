/*
2627 Debounce
Runtime: 54 ms, faster than 70.86% of JavaScript online submissions.
Memory Usage: 42.05 MB, less than 29.65% of JavaScript online submissions.
*/
/**
 * @param {Function} fn
 * @param {number} t milliseconds
 * @return {Function}
 */
var debounce = function (fn, t) {
  let timeoutId;

  return function (...args) {
    clearTimeout(timeoutId);
    timeoutId = setTimeout(() => {
      fn(...args);
    }, t);
  };
};

// Example 0
const log = debounce(console.log, 100);
let start = performance.now();
setTimeout(() => {
  log("Hello"); // cancelled
}, 30);
setTimeout(() => {
  log("Hello"); // cancelled
}, 60);
setTimeout(() => {
  log("Hello"); // Logged at t=100ms
  console.log("Example 0:", [
    Math.floor(performance.now() - start),
    "inputs:",
    "Hello",
  ]);
}, 100);

// Example 1
const dlog = debounce((...inputs) => {
  console.log("Example 1:", [
    Math.floor(performance.now() - start),
    "inputs:",
    inputs,
  ]);
}, 50);
start = performance.now();
setTimeout(() => {
  dlog(1);
}, 50);
setTimeout(() => {
  dlog(2);
}, 75);

// Example 2
const dlog2 = debounce((...inputs) => {
  console.log("Example 2:", [
    Math.floor(performance.now() - start),
    "inputs:",
    inputs,
  ]);
}, 20);
start = performance.now();
setTimeout(() => {
  dlog2(1);
}, 50);
setTimeout(() => {
  dlog2(2);
}, 100);

// Example 3
const dlog3 = debounce((...inputs) => {
  console.log("Example 3:", [
    Math.floor(performance.now() - start),
    "inputs:",
    inputs,
  ]);
}, 150);
start = performance.now();
setTimeout(() => {
  dlog3([1, 2]);
}, 50);
setTimeout(() => {
  dlog3([3, 4]);
}, 300);
setTimeout(() => {
  dlog3([5, 6]);
}, 300);

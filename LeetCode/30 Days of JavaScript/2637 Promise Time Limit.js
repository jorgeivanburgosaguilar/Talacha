/*
2637 Promise Time Limit
Runtime: 51 ms, faster than 84.44% of JavaScript online submissions.
Memory Usage: 41.92 MB, less than 44.33% of JavaScript online submissions.
*/
/**
 * @param {Function} fn
 * @param {number} t
 * @return {Function}
 */
function timeLimit(fn, t) {
  return function (...args) {
    return new Promise((resolve, reject) => {
      let timeout;

      const timeLimitPromise = new Promise((_resolve, reject) => {
        timeout = setTimeout(() => {
          reject("Time Limit Exceeded");
        }, t);
      });

      Promise.race([fn(...args), timeLimitPromise])
        .then((result) => {
          clearTimeout(timeout);
          resolve(result);
        })
        .catch((error) => {
          clearTimeout(timeout);
          reject(error);
        });
    });
  };
}

function getCurrentPerformance(start) {
  return `at ${Math.floor(performance.now() - start)}ms`;
}

// Example 0
let start = performance.now();
let fn = async (t) => new Promise((resolve) => setTimeout(resolve, t));
let t = 100;
let inputs = [150];
let limited = timeLimit(fn, t);
limited(...inputs).catch((result) =>
  console.log("Example 0:", result, getCurrentPerformance(start))
); // "Time Limit Exceeded" at t=100ms

// Example 1
start = performance.now();
fn = async (n) => {
  await new Promise((res) => setTimeout(res, 100));
  return n * n;
};
t = 50;
inputs = [5];
limited = timeLimit(fn, t);
limited(...inputs).catch((result) =>
  console.log("Example 1:", result, getCurrentPerformance(start))
); // "Time Limit Exceeded" at t=50ms

// Example 2
start = performance.now();
fn = async (n) => {
  await new Promise((res) => setTimeout(res, 100));
  return n * n;
};
t = 150;
inputs = [5];
limited = timeLimit(fn, t);
limited(...inputs)
  .then((result) =>
    console.log("Example 2:", result, getCurrentPerformance(start))
  )
  .catch((result) =>
    console.log("Example 2:", result, getCurrentPerformance(start))
  ); // Output: 25 at t=100ms

// Example 3
start = performance.now();
fn = async (a, b) => {
  await new Promise((res) => setTimeout(res, 120));
  return a + b;
};
t = 150;
inputs = [5, 10];
limited = timeLimit(fn, t);
limited(...inputs)
  .then((result) =>
    console.log("Example 3:", result, getCurrentPerformance(start))
  )
  .catch((result) =>
    console.log("Example 3:", result, getCurrentPerformance(start))
  ); // Output: 15 at t=120ms

// Example 4
start = performance.now();
fn = async () => {
  throw "Error";
};
t = 1000;
inputs = [];
limited = timeLimit(fn, t);
limited(...inputs).catch((result) =>
  console.log("Example 4:", result, getCurrentPerformance(start))
); // Output: Error at t=0ms

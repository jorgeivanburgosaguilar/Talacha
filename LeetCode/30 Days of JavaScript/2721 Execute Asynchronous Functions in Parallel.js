/*
2721 Execute Asynchronous Functions in Parallel
Runtime: 72 ms, faster than 39.38% of JavaScript online submissions.
Memory Usage: 42.32 MB, less than 44.96% of JavaScript online submissions.
*/
/**
 * @param {Array<Function>} functions
 * @return {Promise<any>}
 */
var promiseAll = function (functions) {
  return new Promise((resolve, reject) => {
    let cache = new Array(functions.length);
    let solvedFunctions = 0;

    functions.forEach((currentFunction, index) => {
      setTimeout(() => {
        currentFunction()
          .then((res) => {
            cache[index] = res;
            solvedFunctions++;

            if (solvedFunctions == functions.length) {
              resolve(cache);
            }
          })
          .catch((error) => {
            reject(error);
          });
      }, 5);
    });
  });
};

let promise = promiseAll([() => new Promise((res) => res(42))]);
promise.then(console.log).catch(console.log); // [42]

promise = promiseAll([
  () => new Promise((resolve) => setTimeout(() => resolve(5), 200)),
]);
promise.then(console.log); // {"t": 200, "resolved": [5]}

promise = promiseAll([
  () => new Promise((resolve) => setTimeout(() => resolve(1), 200)),
  () =>
    new Promise((_resolve, reject) => setTimeout(() => reject("Error"), 100)),
]);
promise.then(console.log).catch(console.log); // {"t": 100, "rejected": "Error"}

promise = promiseAll([
  () => new Promise((resolve) => setTimeout(() => resolve(4), 50)),
  () => new Promise((resolve) => setTimeout(() => resolve(10), 150)),
  () => new Promise((resolve) => setTimeout(() => resolve(16), 100)),
]);
promise.then(console.log).catch(console.log); // {"t": 150, "resolved": [4, 10, 16]}

promise = promiseAll([
  () => new Promise((resolve) => setTimeout(() => resolve(64), 60)),
  () => new Promise((resolve) => setTimeout(() => resolve(32), 80)),
  () => new Promise((resolve) => setTimeout(() => resolve(34), 20)),
  () => new Promise((resolve) => setTimeout(() => resolve(23), 40)),
  () => new Promise((resolve) => setTimeout(() => resolve(1), 100)),
]);
promise.then(console.log).catch(console.log); // {"resolved":[64,32,34,23,1],"t":99}

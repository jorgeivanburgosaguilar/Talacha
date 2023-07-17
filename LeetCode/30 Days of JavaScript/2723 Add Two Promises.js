/*
2723 Add Two Promises
Runtime: 62 ms, faster than 82% of JavaScript online submissions.
Memory Usage: 41.7 MB, less than 76.84% of JavaScript online submissions.
*/
/**
 * @param {Promise} promise1
 * @param {Promise} promise2
 * @return {Promise}
 */
var addTwoPromises = async function (promise1, promise2) {
  return Promise.all([promise1, promise2]).then((val) => {
    return val[0] + val[1];
  });
};

// Output: 4
addTwoPromises(Promise.resolve(2), Promise.resolve(2)).then(console.log);

// Output: 7
addTwoPromises(
  (promise1 = new Promise((resolve) => setTimeout(() => resolve(2), 20))),
  (promise2 = new Promise((resolve) => setTimeout(() => resolve(5), 60)))
).then(console.log);

// Output: -2
addTwoPromises(
  (promise1 = new Promise((resolve) => setTimeout(() => resolve(10), 50))),
  (promise2 = new Promise((resolve) => setTimeout(() => resolve(-12), 30)))
).then(console.log);

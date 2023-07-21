/*
2621 Sleep
Runtime: 56 ms, faster than 76.76% of JavaScript online submissions.
Memory Usage: 41.50 MB, less than 70.04% of JavaScript online submissions.
*/
/**
 * @param {number} millis
 */
async function sleep(millis) {
  return new Promise((resolve) => setTimeout(resolve, millis));
}

// Output: 100
let t = Date.now();
sleep(100).then(() => console.log(Date.now() - t));

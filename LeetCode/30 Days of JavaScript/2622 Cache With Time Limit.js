/*
2622 Cache With Time Limit
Runtime: 58 ms, faster than 45.97% of JavaScript online submissions.
Memory Usage: 42.21 MB, less than 13.97% of JavaScript online submissions.
*/
var TimeLimitedCache = function () {
  this.cache = {};
};

/**
 * @param {number} key
 * @param {number} value
 * @param {number} duration time until expiration in ms
 * @return {boolean} if un-expired key already existed
 */
TimeLimitedCache.prototype.set = function (key, value, duration) {
  const currentTime = performance.now();
  if (this.cache[key] && this.cache[key].expireTime > currentTime) {
    this.cache[key] = { value, expireTime: currentTime + duration };
    return true;
  }

  this.cache[key] = { value, expireTime: currentTime + duration };
  return false;
};

/**
 * @param {number} key
 * @return {number} value associated with key
 */
TimeLimitedCache.prototype.get = function (key) {
  const currentTime = performance.now();
  if (this.cache[key] && this.cache[key].expireTime > currentTime) {
    return this.cache[key].value;
  }
  return -1;
};

/**
 * @return {number} count of non-expired keys
 */
TimeLimitedCache.prototype.count = function () {
  const currentTime = performance.now();
  let count = 0;
  for (let key in this.cache) {
    if (this.cache[key].expireTime > currentTime) {
      count++;
    }
  }
  return count;
};

console.log("--- Example 1 ----");
let timeLimitedCache = new TimeLimitedCache();
console.log(timeLimitedCache.set(1, 42, 1000)); // false
console.log(timeLimitedCache.get(1)); // 42
console.log(timeLimitedCache.count()); // 1
setTimeout(() => {
  console.log("Example 1 Async:", timeLimitedCache.get(1)); // -1
}, 150);

console.log("--- Example 2 ----");
timeLimitedCache = new TimeLimitedCache();
console.log(timeLimitedCache.set(1, 42, 50)); // false
console.log(timeLimitedCache.set(1, 50, 100)); // true
console.log(timeLimitedCache.get(1)); // 50
console.log(timeLimitedCache.get(1)); // 50
setTimeout(() => {
  console.log("Example 2 Async:", timeLimitedCache.get(1)); // -1
  console.log("Example 2 Async:", timeLimitedCache.count()); // 0
}, 200);

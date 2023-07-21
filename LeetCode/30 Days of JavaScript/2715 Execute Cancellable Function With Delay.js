/*
2715 Execute Cancellable Function With Delay
Runtime: 84 ms, faster than 5.82% of JavaScript online submissions.
Memory Usage: 41.8 MB, less than 81.12% of JavaScript online submissions.
*/
/**
 * @param {Function} fn
 * @param {Array} args
 * @param {number} t
 * @return {Function}
 */
const cancellable = function (fn, args, t) {
  let timeoutId;

  const executeFn = () => {
    timeoutId = undefined;
    console.log({ time: t, returned: fn(...args) });
  };

  timeoutId = setTimeout(executeFn, t);

  function cancelFn() {
    if (timeoutId !== undefined) {
      clearTimeout(timeoutId);
      timeoutId = undefined;
    }
  }

  return cancelFn;
};

// Output: [{"time": 20, "returned": 10}]
const cancelTime = 50;
const cancel = cancellable((x) => x * 5, [2], 20); // fn(2) called at t=20ms
setTimeout(cancel, cancelTime);

// Output: []
const cancelTime2 = 50;
const cancel2 = cancellable((x) => x ** 2, [2], 100); // fn(2) not called
setTimeout(cancel2, cancelTime2);

// Output: [{"time": 30, "returned": 8}]
const cancelTime3 = 100;
const cancel3 = cancellable((x1, x2) => x1 * x2, [2, 4], 30); // fn(2,4) called at t=30ms
setTimeout(cancel3, cancelTime3);

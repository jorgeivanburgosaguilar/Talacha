/*
2694 Event Emitter
Runtime: 58 ms, faster than 29.91% of JavaScript online submissions.
Memory Usage: 42.98 MB, less than 26.98% of JavaScript online submissions.
*/
class EventEmitter {
  constructor() {
    this.events = new Map();
  }

  /**
   * @param {string} eventName
   * @param {Function} callback
   * @return {Object}
   */
  subscribe(eventName, callback) {
    let index = 0;
    let event = this.events.get(eventName);
    if (!event) {
      this.events.set(eventName, [callback]);
      event = this.events.get(eventName);
    } else {
      index = event.length;
      event.push(callback);
    }
    return {
      unsubscribe: () => {
        event[index] = null;
      },
    };
  }

  /**
   * @param {string} eventName
   * @param {Array} args
   * @return {Array}
   */
  emit(eventName, args = []) {
    const event = this.events.get(eventName);
    const results = [];

    if (event) {
      event.forEach((element) => {
        if (element) results.push(element(...args));
      });
    }
    return results;
  }
}

const emitter = new EventEmitter();

// Subscribe to the onClick event with onClickCallback
function onClickCallback() {
  return 99;
}
let sub = emitter.subscribe("onClick", onClickCallback);

console.log(emitter.emit("onClick")); // [99]
console.log(sub.unsubscribe()); // undefined
console.log(emitter.emit("onClick")); // []

emitter.subscribe("firstEvent", function cb1(...args) {
  return args.join(",");
});
console.log(emitter.emit("firstEvent", [1, 2, 3])); // ["1,2,3"]
console.log(emitter.emit("firstEvent", [3, 4, 6])); // ["3,4,6"]

sub = emitter.subscribe("secondEvent", (...args) => args.join(","));
console.log(emitter.emit("secondEvent", [1, 2, 3])); // ["1,2,3"]
console.log(sub.unsubscribe()); // undefined
console.log(emitter.emit("secondEvent", [4, 5, 6])); // [], there are no subscriptions

const sub1 = emitter.subscribe("thirdEevent", (x) => x + 1);
const sub2 = emitter.subscribe("thirdEevent", (x) => x + 2);
console.log(sub1.unsubscribe()); // undefined
console.log(emitter.emit("thirdEevent", [5])); // [7]

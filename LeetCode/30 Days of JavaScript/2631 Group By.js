/*
2631 Group By
Runtime: 121 ms, faster than 51.97% of JavaScript online submissions.
Memory Usage: 68.15 MB, less than 19.05% of JavaScript online submissions.
*/
/**
 * @param {Function} fn
 * @return {Object}
 */
Array.prototype.groupBy = function (fn) {
  const result = {};
  for (let i = 0; i < this.length; i++) {
    const key = fn(this[i]);
    if (result[key] === undefined) result[key] = [];
    result[key].push(this[i]);
  }
  return result;
};

/*
Output:
{
  "1": [1],
  "2": [2],
  "3": [3]
}
*/
console.log([1, 2, 3].groupBy(String)); //

/*
Output:
{
  "1": [{"id": "1"}, {"id": "1"}],
  "2": [{"id": "2"}]
}
*/
let array = [{ id: "1" }, { id: "1" }, { id: "2" }];
let fn = function (item) {
  return item.id;
};
console.log(array.groupBy(fn));

/*
Output:
{
  "1": [[1, 2, 3], [1, 3, 5], [1, 5, 9]]
}
*/
array = [
  [1, 2, 3],
  [1, 3, 5],
  [1, 5, 9],
];
fn = function (list) {
  return String(list[0]);
};
console.log(array.groupBy(fn));

/*
Output:
{
  "true": [6, 7, 8, 9, 10],
  "false": [1, 2, 3, 4, 5]
}
*/
array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
fn = function (n) {
  return String(n > 5);
};
console.log(array.groupBy(fn));

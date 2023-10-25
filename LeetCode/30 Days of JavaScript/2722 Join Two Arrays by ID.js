/*
2722 Join Two Arrays by ID
Runtime: 340 ms, faster than 28.33% of JavaScript online submissions.
Memory Usage: 127.07 MB, less than 7.97% of JavaScript online submissions.
*/
/**
 * @param {Array} arr1
 * @param {Array} arr2
 * @return {Array}
 */
const join = function (arr1, arr2) {
  const mergedMap = new Map();

  [...arr1, ...arr2].forEach((obj) => {
    const id = obj.id;
    if (!mergedMap.has(id)) {
      mergedMap.set(id, { ...obj });
    } else {
      mergedMap.set(id, { ...mergedMap.get(id), ...obj });
    }
  });

  return [...mergedMap.values()].sort((a, b) => a.id - b.id);
};

let arr1 = [
  { id: 1, x: 1 },
  { id: 2, x: 9 },
];
let arr2 = [{ id: 3, x: 5 }];
/*
  {"id": 1, "x": 1},
  {"id": 2, "x": 9},
  {"id": 3, "x": 5}
]
*/
console.log(join(arr1, arr2));

arr1 = [
  { id: 1, x: 2, y: 3 },
  { id: 2, x: 3, y: 6 },
];
arr2 = [
  { id: 2, x: 10, y: 20 },
  { id: 3, x: 0, y: 0 },
];
/*
[
    {"id": 1, "x": 2, "y": 3},
    {"id": 2, "x": 10, "y": 20},
    {"id": 3, "x": 0, "y": 0}
]
*/
console.log(join(arr1, arr2));

arr1 = [{ id: 1, b: { b: 94 }, v: [4, 3], y: 48 }];
arr2 = [{ id: 1, b: { c: 84 }, v: [1, 3] }];
/*
[
    {"id": 1, "b": {"c": 84}, "v": [1, 3], "y": 48}
]
*/
console.log(join(arr1, arr2));

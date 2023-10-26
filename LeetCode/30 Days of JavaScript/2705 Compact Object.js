/*
2705 Compact Object
Runtime: 79 ms, faster than 80.48% of JavaScript online submissions.
Memory Usage: 52.14 MB, less than 74.65% of JavaScript online submissions.
*/
/**
 * @param {Object|Array} obj
 * @return {Object|Array}
 */
const compactObject = function (obj) {
  if (!obj) return false;
  if (typeof obj !== "object") return obj;

  if (Array.isArray(obj)) {
    const compactArray = [];
    obj.forEach((element) => {
      const result = compactObject(element);
      if (result) compactArray.push(result);
    });
    return compactArray;
  }

  const compactObj = {};
  for (const element in obj) {
    const result = compactObject(obj[element]);
    if (result) compactObj[element] = result;
  }
  return compactObj;
};

let obj = [null, 0, false, 1];
// [1]
console.log(compactObject(obj));

obj = { a: null, b: [false, 1] };
// {"b": [1]}
console.log(compactObject(obj));

obj = [null, 0, 5, [0], [false, 16]];
// [5, [], [16]]
console.log(compactObject(obj));

obj = {
  o: 11,
  a: 68,
  m: 18,
  v: true,
  b: false,
  h: null,
  r: false,
  p: 93,
  l: true,
  k: "",
  n: 79,
  f: 18,
  u: null,
  j: null,
  e: null,
  z: {
    d: true,
    t: null,
    o: 21,
    w: null,
    m: 82,
    k: 35,
    l: 26,
    r: 45,
    b: false,
    z: 0,
    i: null,
    c: 33,
    p: 69,
    j: 27,
    e: 53,
    q: 97,
    h: true,
    a: true,
    n: true,
    f: 73,
    u: null,
  },
  w: 12,
  y: 0,
  q: "",
  t: null,
  s: true,
  x: false,
  c: true,
  i: false,
  g: 29,
};
/*
{
  a: 68,
  c: true,
  f: 18,
  g: 29,
  l: true,
  m: 18,
  n: 79,
  o: 11,
  p: 93,
  s: true,
  v: true,
  w: 12,
  z: {
    a: true,
    c: 33,
    d: true,
    e: 53,
    f: 73,
    h: true,
    j: 27,
    k: 35,
    l: 26,
    m: 82,
    n: true,
    o: 21,
    p: 69,
    q: 97,
    r: 45,
  },
}
*/
console.log(compactObject(obj));

# Searching Challenge 1 - Coderbyte Candidate Assessment (Coding Challenge) for Django Developer

Have the function `SearchingChallenge(str)` take the `str`parameter being passed and return 1 if the brackets are correctly matched and each one is accounted for. Otherwise return 0. For example: if `str` is "(hello (world))", then the output should be 1, but if `str` is "((hello (world))" the the output should be 0 because the brackets do not correctly match up. Only "(" and ")" will be used as brackets. If `str` contains no brackets return 1.

## Examples

```text
Input: "(coder)(byte))"
Output: 0

Input: "(c(oder)) b(yte)"
Output: 1
```

## Initial Stub

```python
def SearchingChallenge(strParam):

  # code goes here
  return strParam

# keep this function call here
print(SearchingChallenge(input()))
```

## Environment

Python version: 3.9.17

Packages installed:

- approvaltests
- boto3
- mysql
- numpy
- pandas
- polars
- pyproj
- pyspark
- pytest
- requests
- scikit-learn
- scipy
- shapefile
- shapely
- tensorflow
- torch
- unittest

## Solution

```python
def SearchingChallenge(strParam: str) -> str:
    status: int = 0

    for char in strParam:
        if char == "(":
            status += 1
        elif char == ")":
            status -= 1

        if status < 0:
            return 0

    # code goes here
    return 1 if status == 0 else 0


# keep this function call here
print(SearchingChallenge("(coder)(byte))"))
```

## Output logs

```text
== RUNNING SAMPLE TEST CASES ==

== INPUT ==
"(c(oder)) b(yte)"

== OUTPUT ==
1

<< CORRECT >>

== INPUT ==
"(coder)(byte))"

== OUTPUT ==
0

<< CORRECT >>

== 8 TEST CASES HIDDEN ==
```

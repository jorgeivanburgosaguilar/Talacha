# String Challenge 1 - Coderbyte Candidate Assessment (Coding Challenge) for Django Developer

Have the function `StringChallenge(str)` take the `str` parameter and encode the message according to the following rule: encode every letter into its corresponding numbered position in the alphabet. Symbols and spaces will also be used in the input. For example: if `str` is "af5c a#!" then your program should return 1653 1#!.

## Examples

```text
Input: "hello 45"
Output: 85121215 45

Input: "jaj-a"
Output: 10110-1
```

## Initial Stub

```python
def StringChallenge(strParam):

  # code goes here
  return strParam

# keep this function call here
print(StringChallenge(input()))
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
def StringChallenge(strParam: str) -> str:
  encoded_message: str = ""

  for char in strParam.lower():
    if char.isalpha():
      encoded_message += str(ord(char) - 96)
    else:
      encoded_message += char

  # code goes here
  return encoded_message

# keep this function call here
print(StringChallenge("hello 45"))
```

## Output logs

```text
== RUNNING SAMPLE TEST CASES ==

== INPUT ==
"hello 45"

== OUTPUT ==
85121215 45

<< CORRECT >>

== INPUT ==
"jaj-a"

== OUTPUT ==
10110-1

<< CORRECT >>

== 8 TEST CASES HIDDEN ==
```

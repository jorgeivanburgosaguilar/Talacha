# String Challenge 2 - Coderbyte Candidate Assessment (Coding Challenge) for Django Developer

Have the function `StringChallenge(str)` read `str` which will contain two strings separated by a space. The first string will consist of the following sets of characters: `+, *, $, and {N}` which is optional. The plus (+) character represents a single alphabetic character, the ($) character represents a number between 1-9, and the asterisk (*) represents a sequence of the same character of length 3 unless it is followed by {N} which represents how many characters should appear in the sequence where N will be at least 1. Your goal is to determine if the second string exactly matches the pattern of the first string in the input.

For example: if `str` is "++*{5} jtggggg" then the second string in this case does match the pattern, so your program should return the string `true`. If the second string does not match the pattern your program should return the string `false`.

## Examples

```text
Input: "+++++* abcdehhhhhh"
Output: false

Input: "$**+*{2} 9mmmrrrkbb"
Output: true
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

## Solution not found given the time constraint, next are my three different attempts

### Attempt 1

```python
import re

def StringChallenge(strParam: str) -> bool:
    params: list = strParam.split()
    pattern: str = params[0]
    text: str = params[1]
    regex: str = ''
    pos: int = 0

    while pos < len(pattern):
        char: str = pattern[pos]

        if char == '+':
            regex += r'[a-zA-Z]'
        elif char == '$':
            regex += r'[1-9]'
        elif char == '*':
            previous_char = pattern[pos - 1] if pos > 0 else ''
            next_char = pattern[pos + 1] if pos + 1 < len(pattern) else ''

            if next_char == '{':
                pos += 1
                repeat_value: str = ''
                while pos < len(pattern) and pattern[pos].isdigit():
                    repeat_value += pattern[pos]
                    pos += 1

                count: int = int(repeat_value)
                regex += rf'({re.escape(previous_char)}){{{count}}}'
                pos += 1
            else:
                regex += re.escape(previous_char) * 3
        elif char == '{':
            previous_char = pattern[pos - 1] if pos > 0 else ''
            pos += 1
            repeat_value: str = ''
            while pos < len(pattern) and pattern[pos].isdigit():
                repeat_value += pattern[pos]
                pos += 1

            count: int = int(repeat_value)
            regex += rf'({re.escape(previous_char)}){{{count}}}'
            pos += 1
        else:
            # bad character in the patten should throw
            # but it is not specified in the instructions
            return False

        pos += 1

    # print(regex)
    return bool(re.fullmatch(regex, text))


# Test cases
print(StringChallenge("+++++* abcdehhhhhh"))  # Output: false
print(StringChallenge("$**+*{2} 9mmmrrrkbb"))  # Output: true
print(StringChallenge("++*{5} jtggggg"))  # Output: true
```

### Attempt 2

```python
import re

def StringChallenge(str):
    # Split into pattern string and test string
    pattern_str, test_str = str.split()

    # Regular expression for matching individual pattern elements
    element_regex = r"(\+|\$\d|\*\w|\*\w\{N\})"

    # Compile full pattern based on pattern string
    pattern = ""
    for element in pattern_str:
        if element == "+":
            pattern += "[a-zA-Z]"
        elif element[0] == "$":
            pattern += "\d"
        elif element[0] == "*":
            if len(element) > 1:  # Has letter or {N}
                if element[1] == "{":
                    N = int(element[3])
                    pattern += element[2] * N
                else:
                    pattern += element[1] * 3
            else:  # Standalone "*", match any single character
                pattern += "."

    # Match full pattern against test string
    match = re.fullmatch(pattern, test_str)
    return "true" if match else "false"


# Example usage
print(StringChallenge("++*{5} jtggggg"))  # Output: true
print(StringChallenge("+++++* abcdehhhhhh"))  # Output: false
print(StringChallenge("$**+*{2} 9mmmrrrkbb"))  # Output: true
```

### Attempt 3

```python
def StringChallenge(strParam):
    # Split the input string into pattern and test string
    pattern, test_str = strParam.split()

    i = 0  # Index for pattern string
    j = 0  # Index for test string

    while i < len(pattern) and j < len(test_str):
        if pattern[i] == '+':
            if not test_str[j].isalpha():
                return "false"
            i += 1
            j += 1

        elif pattern[i] == '$':
            if not test_str[j].isdigit():
                return "false"
            i += 1
            j += 1

        elif pattern[i] == '*':
            if i + 1 < len(pattern) and pattern[i + 1] == '{':  # Check for {N}
                end = pattern.find('}', i)
                num_repeat = int(pattern[i + 2:end])
                i += end + 1  # Move i past the {N} block
            else:
                num_repeat = 1  # Repetition of 1 if no {N} is specified
                if j >= len(test_str):  # Check for immediate end of test string
                    return "false"

            # Check if the next characters in test string match the pattern
            if not test_str[j:j + num_repeat] == test_str[j] * num_repeat:
                return "false"
            i += 1
            j += num_repeat

        else:
            return "false"  # Invalid character in pattern

    # Check if we reached the end of both strings
    return i == len(pattern) and j == len(test_str)


# Test cases
print(StringChallenge("++*{5} jtggggg"))   # Output: true
print(StringChallenge("+++++* abcdehhhhhh"))  # Output: false
print(StringChallenge("$**+*{2} 9mmmrrrkbb"))  # Output: true
```

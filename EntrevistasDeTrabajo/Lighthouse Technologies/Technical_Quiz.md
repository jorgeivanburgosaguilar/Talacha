# Lighthouse Technologies - Coderbyte Candidate Assessment (Technical Quiz) for Django Developer

Welcome to your Python Quick assessment. You must answer following 10 questions in under 10 minutes. Good luck!

## 1. What will be the output of the following Python code?

```python
a={30,40,50}
a.update([10,20,30])
print (a)
```

Options:

- {10, 20, 30, 40, 50}
- [10,20,30,30,40,50]
- Error, list can't be added to set
- None of the these
- Error, duplicate item present in list

**Answer:** **_None of the these_**

## 2. In a SELECT query which clause is executed first?

- HAVING
- GROUP BY
- WHERE
- ORDER BY

**Answer:** **_WHERE_**

## 3. What will be the output of the following Python code?

```python
import math
[str(round(math.pi)) for i in range (1, 3)]
```

Options:

- ['3.1', '3.14','3.142']
- [3, 3, 3]
- ['3', '3']
- None of these
- ['3', '3', '3']

**Answer:** **_['3', '3']_**

## 4. Let X and Y be objects of class Class1. Which functions are called when print(A + B) is executed?

Options

- _sum_(), _str_()
- _add_(), _str_()
- None of the other answers is correct
- _str_(), _add_()

**Answer:** **__add_(), _str_()_**

## 5. What will be the output of the following Python code?

```python
def add (o,k):
    o.t=o.t+1
    k=k+1

class A:
    def __init__(self):
        self.t = 0

def main():
    c = A()
    k = 0
```

### Options

- ```python
    c.t = 25
    k = 25
  ```

- ```python
    c.t = 25
    k = 0
  ```

- ```python
    c.t = 0
    k = 0
  ```

- Exception is thrown

**Answer:**

```python
    c.t = 0
    k = 0
```

## 6. Given the following script, what will be the value of my_string?

```python
my_sentence = "I love to learn new things"
splited = my_sentence.split()
my_string = splited[-1]
```

Options

- "things"
- "love"
- None of these
- "I"
- ""

**Answer:** **_"things"_**

## 7. What will be the output of the following code?

```python
name = "James"
for x in name:
  print (x)
```

Options

- It will raise ValueError
- None of these
- It will print numbers 1 through 5
- It will print each character once
- It will print James multiple times

**Answer:** **_It will print each character once_**

## 8. What is the output of the following code?

```python
for count in range(5):
  str1 = 'a' * count
  str2 = 'a' * count
  print (str1 is str2)
```

Options

- None of these

- ```python
    True
    True
    True
    True
    True
  ```

- ```python
    False
    False
    False
    False
    False
  ```

- ```python
    True
    True
    False
    False
    False
  ```

- Exception will be raised

**Answer:**

```python
True
True
False
False
False
```

## 9. What will be the output of the following code?

```python
m = [1,2,3,4]
m.append([4,6,7,8])
print (len(m))
```

Options

- Exception will be raised
- 5
- 8
- 7

**Answer:** **_5_**

## 10. Whats "requests" library is used for?

Options

- Making web requests
- Interacting with the file system
- Making database requests
- There is no such library

**Answer:** **_Making web requests_**

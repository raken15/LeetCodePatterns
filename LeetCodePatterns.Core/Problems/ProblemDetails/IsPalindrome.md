# IsPalindrome

## Problem Statement
A **palindrome** is a string that reads the same backward as forward. Write a program that determines whether a given string is a palindrome. The program should consider only alphanumeric characters and ignore case differences.

## Example Input/Output

### Example 1
**Input:**  
`"A man, a plan, a canal: Panama"`

**Output:**  
`True`

**Explanation:**  
Ignoring spaces, punctuation, and case, the string is `"amanaplanacanalpanama"`, which is a palindrome.

---

### Example 2
**Input:**  
`"race a car"`

**Output:**  
`False`

**Explanation:**  
Ignoring spaces, punctuation, and case, the string is `"raceacar"`, which is not a palindrome.

---

### Example 3
**Input:**  
`""` (empty string)

**Output:**  
`True`

**Explanation:**  
An empty string is considered a palindrome.

---

## Constraints
1. The string can contain any printable ASCII characters.
2. The string length is between `0` and `100,000`.

---

## Requirements
1. Implement a function that takes a string as input and returns a boolean indicating whether it is a palindrome.
2. Optimize the solution for both time and space efficiency.

---

## Hints
1. Use two pointers to compare characters from the start and the end of the string.
2. Skip non-alphanumeric characters and ensure case-insensitive comparisons.
3. Consider edge cases like an empty string, single-character strings, and strings with only non-alphanumeric characters.

---

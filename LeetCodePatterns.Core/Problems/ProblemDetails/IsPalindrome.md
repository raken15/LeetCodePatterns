# IsPalindrome

## Problem Statement
Implement a function that takes a string as input and returns a boolean indicating whether it is a palindrome. The function should consider only alphanumeric characters and ignore case differences.
A **palindrome** is a string that reads the same backward as forward

---

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

### Approach
The **two-pointer technique** efficiently checks for palindromes by comparing characters from both ends of the string, gradually moving toward the center.

1. **Initialize Pointers:**
   - `left` starts at the beginning of the string (`0`).
   - `right` starts at the end of the string (`n - 1`, where `n` is the string length).

2. **Iterative Comparison:**
   - While `left < right`:
     - **Skip Non-Alphanumeric Characters:**
       - If the character at `left` is not alphanumeric, increment `left`, and continue to the next iteration of the loop.
       - If the character at `right` is not alphanumeric, decrement `right`, and continue to the next iteration of the loop.
     - **Compare Characters:**
       - Convert both characters to lowercase for case-insensitive comparison.
       - If the characters do not match, return `False` (not a palindrome).
     - If they match, move both pointers closer to the center:
       - Increment `left`.
       - Decrement `right`.

3. **Termination:**
   - If all characters match or the pointers cross, return `True` (the string is a palindrome).

---
## Time Complexity
- **O(n)**: Each character is processed once as the left and right pointers move toward the center.

## Space Complexity
- **O(1)**: The algorithm uses constant extra space for variables (left and right).
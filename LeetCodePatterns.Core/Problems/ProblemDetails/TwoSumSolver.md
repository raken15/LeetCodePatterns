# Two Sum Solver

## Problem Statement
Given an array of integers `nums` and an integer `target`, return the indices of the two numbers such that they add up to `target`.

## Example
Input: `nums = [2, 7, 11, 15], target = 9`  
Output: `[0, 1]`

## Constraints
- Each input has exactly one solution.
- You cannot use the same element twice.

## Approach
1. Use a dictionary to store the complement of each number (`target - nums[i]`) and its index.
2. Iterate through the array:
   - If the current number exists in the dictionary, return the indices.
   - Otherwise, add the number and its index to the dictionary.

## Time Complexity
- **O(n)**: Single pass through the array.

## Space Complexity
- **O(n)**: Dictionary stores up to `n` elements.
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
1. Use a dictionary to store each number (`nums[i]`) and its index as you iterate through the array.
2. Iterate through the array:
   - For each number nums[i], calculate the complement (target - nums[i]).
   - Check if the complement is already in the dictionary:
      * If it is, return the pair of indices (the index of the complement and the current index i).
   - If the complement is not in the dictionary, add the current number (nums[i]) and its index (i) to the dictionary.

## Time Complexity
- **O(n)**: Single pass through the array.

## Space Complexity
- **O(n)**: Dictionary stores up to `n` elements.
using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Edge Case: Empty array
                if (nums == null || nums.Length == 0) return new List<int>();

                // Edge Case: Duplicates should not affect detection of missing numbers
                // Use a HashSet to check presence of each number from 1 to n

                HashSet<int> numSet = new HashSet<int>(nums);
                List<int> missing = new List<int>();
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!numSet.Contains(i))
                    {
                        missing.Add(i);
                    }
                }

                return missing;
            }
            catch (Exception)
            {
                // Edge Case: Exception handling if input is null or invalid
                throw;
            }
        }


        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Edge Case: Empty array
                if (nums == null || nums.Length == 0) return new int[0];

                // Edge Case: Duplicates should not affect detection of missing numbers
                // Use a HashSet to check presence of each number from 1 to n

               return nums.OrderBy(x => x%2).ToArray();
            }
            catch (Exception)
            {
                // Edge Case: Exception handling if input is null or invalid
                throw;
            }
        }


        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Edge Case: Empty or single-element array
                if (nums == null || nums.Length < 2) return new int[0];

                // Edge Case: Multiple possible pairs - return first correct match
                // Use dictionary to store value -> index mappings

                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    if (!map.ContainsKey(nums[i]))
                    {
                        map[nums[i]] = i;
                    }
                }

                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Edge Case: Array must have at least 3 elements
                if (nums == null || nums.Length < 3) throw new ArgumentException("Input must have at least 3 integers");

                // Edge Case: Contains negative numbers which may lead to larger product when paired
                Array.Sort(nums);
                int n = nums.Length;

                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                int product2 = nums[0] * nums[1] * nums[n - 1];

                return Math.Max(product1, product2);
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Edge Case: 0 should return "0"
                if (decimalNumber == 0) return "0";

                string binary = "";
                int num = decimalNumber;

                // Edge Case: Handles all positive integers, including large values.
                while (num > 0)
                {
                    binary = (num % 2) + binary;
                    num /= 2;
                }

                return binary;
            }
            catch (Exception)
            {
                // Edge Case: Exception thrown for invalid input, like negative numbers (if allowed)
                throw;
            }

        }


        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                // Edge Case: Single element array
                if (nums.Length == 1) return nums[0];

                // Binary search for rotation point
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // Edge Case: Unrotated sorted array
                    if (nums[mid] > nums[right])
                        left = mid + 1;
                    else
                        right = mid;
                }

                // At the end of loop, left == right and points to smallest
                return nums[left];
            }
            catch (Exception)
            {
                // Edge Case: Empty array - could throw error if not handled by caller
                throw;
            }
        }


        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge Case: Negative numbers are not palindromes
                if (x < 0) return false;

                string str = x.ToString();
                int left = 0, right = str.Length - 1;

                while (left < right)
                {
                    // Compare characters from both ends
                    if (str[left] != str[right]) return false;
                    left++;
                    right--;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }


        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Edge Case: 0 and 1 are base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                int a = 0, b = 1, result = 0;
                for (int i = 2; i <= n; i++)
                {
                    result = a + b;
                    a = b;
                    b = result;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
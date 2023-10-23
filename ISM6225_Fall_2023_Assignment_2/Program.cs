/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Initializing list to store missing ranges 
                List<IList<int>> missingRanges = new List<IList<int>>();

                // // Variable to track expected next number in sequence
                int expectedNumber = lower;

                foreach (int num in nums)
                {
                    // Check if num is greater than expected number
                    if (num > expectedNumber)
                    {
                        // If difference is 1, only 1 number is missing
                        if (num - expectedNumber == 1)
                        {
                            missingRanges.Add(new List<int> { expectedNumber, expectedNumber });
                        }
                        //Inside loop, if gap between numbers is more than 1, add missing range to result list
                        else if (num - expectedNumber > 1)
                        {
                            missingRanges.Add(new List<int> { expectedNumber, num - 1 });
                        }
                    }

                    // Update expected number
                    expectedNumber = num + 1;
                }

                // Check for missing numbers after final element
                if (expectedNumber <= upper)
                {
                    // Single missing number
                    if (upper - expectedNumber == 0)
                    {
                        missingRanges.Add(new List<int> { expectedNumber, expectedNumber });
                    }
                    // Missing range
                    else if (upper - expectedNumber > 0)
                    {
                        missingRanges.Add(new List<int> { expectedNumber, upper });
                    }
                }

                // Return result
                return missingRanges;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Stacking to store opening brackets
                Stack<char> openBrackets = new Stack<char>();

                // Converting string to char array
                char[] chars = s.ToCharArray();

                foreach (char c in chars)
                {
                    // If opening bracket, push to stack
                    if (c == '(' || c == '[' || c == '{')
                    {
                        openBrackets.Push(c);
                        continue;
                    }

                    // If it is closing bracket but stack empty, invalid
                    if (openBrackets.Count == 0)
                    {
                        return false;
                    }

                    // Check the matching closing bracket
                    char lastOpen = openBrackets.Pop();
                    if (lastOpen == '(' && c != ')')
                    {
                        return false;
                    }
                    else if (lastOpen == '[' && c != ']')
                    {
                        return false;
                    }
                    else if (lastOpen == '{' && c != '}')
                    {
                        return false;
                    }
                }

                // If stack is empty, all brackets matched
                return openBrackets.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initializing profit and buy price
                int maxProfit = 0;
                int buyPrice = prices[0];

                for (int i = 1; i < prices.Length; i++)
                {
                    // Update buying price if lower price found
                    if (prices[i] < buyPrice)
                    {
                        buyPrice = prices[i];
                    }

                    // Calculate the potential profit  
                    int potentialProfit = prices[i] - buyPrice;

                    // Update max profit if it is greater 
                    if (potentialProfit > maxProfit)
                    {
                        maxProfit = potentialProfit;
                    }
                }

                // Return the maximum profit
                return maxProfit;
            }

            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string num)
        {
            try
            {
                // // Map to lookup valid strobogrammatic number pairs for comparison
                Dictionary<char, char> pairs = new Dictionary<char, char>{
      {'0', '0'},
      {'1', '1'},
      {'6', '9'},
      {'8', '8'},
      {'9', '6'}
    };

                int left = 0;
                int right = num.Length - 1;

                while (left <= right)
                {
                    // // Check if current left and right digits form a valid strobogrammatic pair
                    if (!pairs.ContainsKey(num[left]) ||
                       pairs[num[left]] != num[right])
                    {
                        return false;
                    }

                    left++;
                    right--;
                }

                // If all pairs valid, num is strobogrammatic
                return true;
            }

            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Creating dictionary to store result
                Dictionary<int, int> countDict = new Dictionary<int, int>();
                // intialize count of good pairs
                int goodPairs = 0;

                foreach (int num in nums)
                {
                    if (countDict.ContainsKey(num))
                    {
                        // // If number is in dictionary, increment pairs count
                        goodPairs += countDict[num];

                        // Incrementing count for current number
                        countDict[num]++;
                    }
                    else
                    {
                        // Initializing count for new number
                        countDict[num] = 1;
                    }
                }

                // Return number of good pairs
                return goodPairs;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                //  HashSet to store unique numbers from input array
                HashSet<int> uniques = new HashSet<int>();

                foreach (int num in nums)
                {
                    // Add each number to HashSet
                    uniques.Add(num);

                    // If more than 3 numbers, remove smallest
                    if (uniques.Count > 3)
                    {
                        uniques.Remove(uniques.Min());
                    }
                }

                // If less than 3 unique numbers, return max 
                if (uniques.Count < 3)
                {
                    return uniques.Max();
                }

                // Otherwise return third max number
                return uniques.Min();

            }

            catch (Exception)
            {
                // Log error
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // // Initialize empty list to store all possible next moves generated
                List<string> nextMoves = new List<string>();

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // If current chars are "++" flip them to "--"
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        string nextState = currentState.Substring(0, i) +
                                           "--" +
                                           currentState.Substring(i + 2);

                        // Add state to list of possible moves  
                        nextMoves.Add(nextState);
                    }
                }

                // Return all possible next moves
                return nextMoves;
            }

            catch (Exception e)
            {
                // Log error 
                Console.WriteLine("Error: " + e.Message);
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string input)
        {
            try
            {
                //  Initialize empty StringBuilder to hold result string as vowels removed
                StringBuilder result = new StringBuilder();

                foreach (char c in input)
                {
                    // Check if character is a vowel
                    if (!"aeiou".Contains(Char.ToLower(c)))
                    {
                        result.Append(c);
                    }
                }

                return result.ToString();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

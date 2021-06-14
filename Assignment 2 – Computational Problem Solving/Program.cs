using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2___Computational_Problem_Solving
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1 : 
            Console.WriteLine("Intersection - Q1");
            int[] nums1 = { 1, 2, 3, 8, 9, 10 };
            int[] nums2 = { 2, 3, 4, 5, 6, 7, 3 };
            Console.WriteLine("Elements of FirstArray:{ 1, 2, 3,8,9,10 }");
            Console.WriteLine("Elements of SecondArray:{ 2, 3, 4,5,6,7,3 }");
            Console.WriteLine("Intersect Result");
            var res = Program.Intersection(nums1, nums2);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Question 2 : 
            Console.WriteLine("Target Value - Q2");
            int[] nums = { 1, 2, 3, 4, 5 };
            int target = 2;
            Console.WriteLine("Elements of Array: {1, 2, 3, 4, 5}");
            Console.WriteLine("Target value to be searched : 2");
            int index = Program.SearchInsert(nums, target);
            Console.WriteLine("The index of the target value is " + index);
            Console.WriteLine();

            //Question 3 : 
            Console.WriteLine("Lucky Integer - Q3");
            int[] lucky = { 1, 2, 2, 3, 3, 3 };
            Console.WriteLine("Elements in the array : {1, 2, 2, 3, 3, 3}");
            Console.WriteLine("Lucky Integer is : ");
            int largestLucky = Program.FindLucky(lucky);
            Console.WriteLine(largestLucky);
            Console.WriteLine();

            //Question 4 : 
            Console.WriteLine("Max Number - Q4");
            Console.WriteLine("The Maximum number generated in the sequence is ");
            int max = Program.GetMaximumGenerated(5);
            Console.WriteLine(max);
            Console.WriteLine();

            //Question 5: 
            Console.WriteLine("Destination - Q5");
            IList<IList<string>> paths = new List<IList<string>>();
            List<string> city = new List<string>() { "London", "New York", "New York", "Lima", "Lima", "Sao Paulo" };
            paths.Add(city);
            string destinationCity = Program.DestCity(paths);
            Console.WriteLine(destinationCity);
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Two Sum - Q6");
            int[] arr = new int[] { 2, 7, 11, 15 };
            var items = Program.TwoSum(arr, 9);
            Console.WriteLine("The element in the array is");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Question 7: 
            Console.WriteLine("Student Scores - Q7");
            int[][] studentScores =
                {
                    new int[] { 1,91 },new int[] { 1,92 }, new int[] { 2, 93 },
                    new int[] { 2,97 },new int[] { 1,60 }, new int[] { 2,77 },
                    new int[] { 1,65 },new int[] { 1,87 }, new int[] { 1,100 },
                    new int[] { 2,100 },new int[] { 2,76 }

                };

            var topFive = Program.HighFive(studentScores);
            //Display the result 
            for (int i = 0; i < topFive.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < topFive[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", topFive[i][j], j == (topFive[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }

            //Question 8 : 

            Console.WriteLine("Top Five Average - Q8");
            int[] values =  { 1, 2, 3, 4, 5, 6, 7 };
            var result = Program.Rotate(values, 3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Returns the intersection of two arrays
        /// </summary>
        /// <param name="nums1">the first array passed in</param>
        /// <param name="nums2">the second array passed in</param>
        /// <returns></returns>
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            //Using a linq function called Intersect to find the intersection of these two arrays
            //Intersection returns only the unique elements. 
            //Time Complexity is : O(n+m) 
            //Self Reflection : Using a for loop here and checking each element if it occurs in the 
            //second collection would result in a pretty bad  time complexity,O(m*n)
            //where n and m are arrays' lengths.

            int[] Results = nums1.Intersect(nums2).ToArray();
            return Results;
        }
        /// <summary>
        /// Searches a target value from a sorted array and returns indesx of the 
        /// target value. Similar to a binary search tree. If the target is not found, 
        /// returns the position where the target would have been in a sorted array. 
        /// </summary>
        /// <param name="nums">the array passed in</param>
        /// <param name="target">the target element to be searched in the array</param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            //O(log n) runtime complexity.
            //Uses Binary search tree algorithm
            //Self Reflection :Could have used a linq Expression but this is faster way of searching 
            //linearly. 
            //Space complexity : O(1) since it's a constant space solution.
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
            }
            return low;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">The array passed in</param>
        /// <returns></returns>
        public static int FindLucky(int[] arr)
        {
            //Using a linq expression here. First, Group by all the elements within the array. 
            //Time Complexity : O(n)
            //Self Reflection : Could have been done via for loops but the implementation would have 
            //been a bit complex and time consuming. 

            return
                  arr.GroupBy(x => x)
                  .Where(x => x.Count() == x.Key)//Get the elements in the group which has the same key as number of elements. 
                  .Select(x => x.Key)
                  .OrderByDescending(x => x).//Order them in descending, to get the largest. 
                  DefaultIfEmpty(-1)//return - 1, if there are no lucky numbers. 
                  .First();//Always return the first largest. 
        }

        /// <summary>
        /// returns the maximum number generated from a sequence. 
        /// </summary>
        /// <param name="n">maximum iterations or lenght of the array</param>
        /// <returns></returns>
        public static int GetMaximumGenerated(int n)
        {
            //Time Complexity : O(n)
            //Space Complexity: \mathcal{O}(n)O(n), as we use an array \text{nums}nums of size nn.
            //If current index i is even, the value of nums[i] is equal to nums[i/2].
            //Else, the value of nums[i] is equal to nums[i / 2] + nums[i / 2 + 1].
            //Self Reflection : The straightforward solution is to generate the array of size n+1
            //using the given generation pattern and keep track of the maximum element in the array.
            //but the implementation of this would be convoluted. 
            if (n <= 0)
                return 0;

            var num = new int[n + 1];
            num[0] = 0;
            num[1] = 1;
            var max = 1;
            for (var i = 2; i < n + 1; i++)
            {
                if (i % 2 == 0)
                    num[2 * (i / 2)] = num[i / 2];
                else
                    num[(2 * (i / 2)) + 1] = num[i / 2] + num[i / 2 + 1];

                max = Math.Max(max, num[i]);
            }

            return max;
        }

        /// <summary>
        /// Return the destination city, that is, the city without any path outgoing to another city.
        /// </summary>
        /// <param name="paths">Paths with origin to destination</param>
        /// <returns></returns>
        public static string DestCity(IList<IList<string>> paths)
        {
            //Time Complexity : O(n*m) since this requires iteration twice through the hashset.
            //Self Reflection:
            //Although this involves two loops, since we are using a hashset, this would be faster as its a lookup for 
            //unique values.
            ISet<string> fromSet = new HashSet<string>();
            foreach (var p in paths)
            {
                fromSet.Add(p[0]);
            }

            foreach (var p in paths)
            {
                if (!fromSet.Contains(p[1]))
                {
                    return p[1];
                }
            }

            return "";
        }

        /// <summary>
        /// finds two numbers such that they add up to a specific target number.
        /// </summary>
        /// <param name="numbers">the array of integers</param>
        /// <param name="target">the target number</param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            //Time Complexity : O(n).Each of the nn elements is visited at most once, thus the time complexity is O(n)O(n).
            //Self Reflection : 
            //We use two indexes, initially pointing to the first and last element respectively.
            //Compare the sum of these two elements with target. If the sum is equal to target,
            //we found the exactly only solution. If it is less than target, we increase the smaller index by one. 
            //If it is greater than target, we decrease the larger index by one. Move the indexes and repeat
            //the comparison until the solution is found.
            int l = 0, r = numbers.Length - 1, sum;
            while (true)
            {
                sum = numbers[l] + numbers[r];
                if (sum == target)
                    break;
                else if (sum < target)
                    l += 1;
                else
                    r -= 1;
            }
            return new int[2] { l + 1, r + 1 };
        }

        /// <summary>
        /// calculate each student's top five average.
        /// </summary>
        /// <param name="items">where items[i] = [IDi, scorei] represents one score from a student with IDi</param>
        /// <returns></returns>
        public static int[][] HighFive(int[][] items)
        {
            //Time Complexity: Assuming N is the total number of items, 
            //finding a key in the dictionary takes O(logN) time. 
            // pushing an item in the dictionary takes O(1)O(1) time. 
            //Hence to insert all the N elements, the total time taken is O(N)O(N).
            //Iterating over the map dictionary O(N)O(N) time and extracting all the elements
            //from the jagged array is a constant time operation. Hence the overall time taken is O(N \log N)O(NlogN).
            //Self Reflection : 

            //Since we have to take into account the top 5 values corresponding to each id, 
            //we can sort the items array, first based on the id and next based on the score, 
            //i.e. items will be sorted based on increasing order of their ids. In case we have
            //a tie for the value of ids, the items are then sorted based on decreasing order of the scores.
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < items.Length; i++)
            {
                if (!dict.ContainsKey(items[i][0]))
                    dict.Add(items[i][0], new List<int> { items[i][1] });
                else
                    dict[items[i][0]].Add(items[i][1]);
            }
            int[][] result = new int[dict.Keys.Count][];
            int k = 0;
            foreach (KeyValuePair<int, List<int>> kvp in dict.OrderBy(x => x.Key))
            {
                result[k] = new[] { kvp.Key, (int)kvp.Value.OrderByDescending(r => r).Take(5).Average() };
                k++;
            }
            return result;
        }

        /// <summary>
        /// rotates the elements of the given array k times to the right.
        /// </summary>
        /// <param name="nums">array passed in</param>
        /// <param name="k">number of times you need to move to the right</param>
        public static int[] Rotate(int[] nums, int k)
        {
            //Self Reflection:
            //we need to store the number being replaced in a temptemp variable.
            //Then, we can place the replaced number(\text{temp}temp) at its correct position and so on,
            //n times, where n is the length of array. We have chosen n to be the number of replacements
            //since we have to shift all the elements of the array(which is n).
            //Time complexity: \mathcal{O}(n)O(n). Only one pass is used.
            var m = new int[nums.Length];
            Array.Copy(nums, m, nums.Length);
            k = k % nums.Length;
            if (k == 0) return null ;
            var temp = nums[k];
            for (var i = 0; i < nums.Length; i++)
            {
                nums[(i + k) % nums.Length] = m[i];
            }
            return nums;
        }

        //Q 9 : 
        public int MaxSubArray(int[] nums)
        {
            var prevSum = nums[0]; ;
            int maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                prevSum = Math.Max(nums[i], nums[i] + prevSum);
                maxSum = Math.Max(maxSum, prevSum);
            }

            return maxSum;

            
        }

        //Q10:
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost == null)
                return 0;

            var length = cost.Length;
            if (length == 1)
            {
                return 0;
            }

            var dp = new int[length];

            for (int i = 0; i < length; i++)
            {
                if (i <= 1)
                {
                    dp[i] = cost[i];
                }
                else
                {
                    dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
                }
            }

            return Math.Min(dp[length - 1], dp[length - 2]);
        }
    }
}

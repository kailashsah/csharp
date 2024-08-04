using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Search Insert Position

        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

        You must write an algorithm with O(log n) runtime complexity. 

        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1

        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4

*/

namespace CSharpMisc
{
    public class SearchInsertPosition
    {
        /*
            public int RecursiveApproach(int[] nums, int left, int right, int target);
            public int IterativeApproach(int[] nums, int target);
        */

        public int SearchInsert(int[] nums, int target)
        {
            return RecursiveApproach(nums, 0, nums.Length - 1, target);
        }

        public int RecursiveApproach(int[] nums, int left, int right, int target)
        {
            if (left > right)
                return left; // If the search space is empty, return the insertion position

            int mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] < target)
                return RecursiveApproach(nums, mid + 1, right, target); // Search right half
            else //(nums[mid] > target)
                return RecursiveApproach(nums, left, mid - 1, target); // Search left half
        }


        public int IterativeApproach(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;

                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return left;
        }

        public void Run()
        {
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine(SearchInsert(nums, 5));//2

            Console.WriteLine(SearchInsert(nums, 2));//1
            Console.WriteLine(SearchInsert(nums, 7));//4

            //2.
            Console.WriteLine(IterativeApproach(nums, 5));//2
        }

        //static void Main(String[] args)
        //{
        //    new SearchInsertPosition().Run();

        //}
    }
}

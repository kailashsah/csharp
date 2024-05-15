using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. 

 */
namespace CSharpMisc
{
    class SumOfIndexes
    {
        public int[] TwoSumOne(int[] nums, int target)
        {
            int prev = 0;
            int i = 0;
            for (; i < nums.Length; i++)
            {
                if (target == nums[i] + nums[i + 1])
                    break;
            }
            return new int[] { i, i + 1 };
        }
        public void RunSumMatchesTarget()
        {
            //int[] nums = { 2, 7, 11, 15 };
            int[] nums = { 15, 11, 7, 2 };
            int target = 9;

            //1.
            int[] ints = TwoSumTwo(nums, target); // faster than other one
            //2. 
            //int[] ints = TwoSumOne(nums, target); // [0, 1]
            //int[] ints = ArraySort(nums);

            //1.
            Array.ForEach(ints, x => { Console.Write(x + " "); });
            Console.WriteLine();
            //2.
            ints.ToList().ForEach(i => Console.Write(i.ToString() + " "));

            


        }
        public int[] TwoSumTwo(int[] nums, int target)
        {

            (int num, int index)[] numbers = nums.Select((num, index) => (num, index)).ToArray();
            Array.Sort(numbers, (a, b) => a.num.CompareTo(b.num));
            int i = 0, j = nums.Length - 1;

            while (i < j)
            {
                int sum = numbers[i].num + numbers[j].num;
                if (sum == target)
                {
                    return new int[] { numbers[i].index, numbers[j].index };
                }
                else if (sum < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            throw new ArgumentException("No two sum solution");
        }

        public int[] ArraySort(int[] nums)
        {
            Array.Sort(nums);
            return nums;
        }

        //static void Main(String[] args)
        //{
        //    new SumOfIndexes().RunSumMatchesTarget();

        //}
    }
}

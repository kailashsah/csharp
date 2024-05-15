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
        public int[] TwoSum(int[] nums, int target)
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
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] ints = TwoSum(nums, target); // [0, 1]
            //1.
            Array.ForEach(ints, x => { Console.Write(x + " "); });
            //2.
            ints.ToList().ForEach(i => Console.WriteLine(i.ToString()));

        }

        //static void Main(String[] args)
        //{
        //    new SumOfIndexes().RunSumMatchesTarget();

        //}
    }
}

﻿namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an array of ints, return true if the sum of all the 2's in the array is exactly 8.
         Sum28([2, 3, 2, 2, 4, 2]) → true
         Sum28([2, 3, 2, 2, 4, 2, 2]) → false
         Sum28([1, 2, 3, 4]) → false
         */
        public bool Sum28(int[] nums)
        {

            int sumToEight = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 2)
                {
                    sumToEight += 2;
                }
            }
            if(sumToEight == 8)
            {
                return true;
            }
            return false;
        }
    }
}

﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Given 3 int values, a b c, return their sum. However, if one of the values is 13 then it does not
         count towards the sum and values to its immediate right do not count. So for example, if b is 13, then both
         b and c do not count.
         LuckySum(1, 2, 3) → 6
         LuckySum(1, 2, 13) → 3
         LuckySum(1, 13, 3) → 1
         LuckySum(13, 1, 3) → 3
         LuckySum(13, 13, 3) → 0
         */
        public int LuckySum(int a, int b, int c)
        {
            if (a == 13 && b == 13)
            {
                return 0;
            }
            else if (a == 13)
            {
                return c;
            }
            else if (b == 13)
            {
                return a;
            }
            else if (c == 13)
            {
                return a + b;
            }
            else
            {
                return a + b + c;
            }
        }
    }
}

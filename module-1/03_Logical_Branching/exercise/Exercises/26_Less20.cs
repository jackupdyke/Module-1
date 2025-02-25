﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Return true if the given non-negative number is 1 or 2 less than a multiple of 20. So for example 38
         and 39 return true, but 40 returns false.
         (Hint: Think "mod".)
         Less20(18) → true
         Less20(19) → true
         Less20(20) → false
         */
        public bool Less20(int n)
        {
            if (((n + 1) % 20 == 0) || ((n + 2) % 20 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

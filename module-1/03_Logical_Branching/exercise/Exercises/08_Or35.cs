﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Return true if the given non-negative number is a multiple of 3 or a multiple of 5.
         (Hint: Think "mod".)
         Or35(3) → true
         Or35(10) → true
         Or35(8) → false
         */
        public bool Or35(int n)
        {
            if (n % 3 == 0 || n % 5 == 0)
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

﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         We'll say a number is special if it is a multiple of 11 or if it is one more than a multiple of 11.
         Return true if the given non-negative number is special.
         (Hint: Think "mod".)
         SpecialEleven(22) → true
         SpecialEleven(23) → true
         SpecialEleven(24) → false
         */
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || n % 11 == 1)
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

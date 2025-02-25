﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Given three ints, a b c, return true if they are in strict increasing order, such as 2 5 11,
         or 5 6 7, but not 6 5 7 or 5 5 7. However, with the exception that if "equalOk" is true, equality
         is allowed, such as 5 5 7 or 5 5 5.
         InOrderEqual(2, 5, 11, false) → true
         InOrderEqual(5, 7, 6, false) → false
         InOrderEqual(5, 5, 7, true) → true
         */
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (c > b && b > a)
            {
                return true;
            }
            else if ((c >= b && b >= a) && equalOk == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}

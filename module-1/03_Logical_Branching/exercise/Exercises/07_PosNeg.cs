﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Given 2 int values, return true if one is negative and one is positive. Except if the parameter
         "negative" is true, then return true only if both are negative.
         PosNeg(1, -1, false) → true
         PosNeg(-1, 1, false) → true
         PosNeg(-4, -5, true) → true
         */
        public bool PosNeg(int a, int b, bool negative)
        {
            if ((a < 0 && b < 0) && negative == true)
            {
                return true;
            }
            else if(((a < 0 && b > 0) || (a > 0 && b < 0)) && negative == false)
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

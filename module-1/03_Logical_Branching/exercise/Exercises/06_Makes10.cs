﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Given 2 ints, a and b, return true if one if them is 10 or if their sum is 10.
         Makes10(9, 10) → true
         Makes10(9, 9) → false
         Makes10(1, 9) → true
         */
        public bool Makes10(int a, int b)
        {
            if ((a == 10 || b == 10) || a + b == 10)
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

﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Given a number n, return true if n is in the range 1..10, inclusive. Unless "outsideMode" is true,
         in which case return true if the number is less or equal to 1, or greater or equal to 10.
         In1To10(5, false) → true
         In1To10(11, false) → false
         In1To10(11, true) → true
         */
        public bool In1To10(int n, bool outsideMode)
        {
            if ((1 <= n && n <= 10) && outsideMode == false)
            {
                return true;
            }
            else if ((n <= 1 || n >= 10) && outsideMode == true)
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

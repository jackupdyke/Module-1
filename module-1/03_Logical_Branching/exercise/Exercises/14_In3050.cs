﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         Given 2 int values, return true if they are both in the range 30..40 inclusive, or they are both
         in the range 40..50 inclusive.
         In3050(30, 31) → true
         In3050(30, 41) → false
         In3050(40, 50) → true
         */
        public bool In3050(int a, int b)
        {
            if ((30 <= a && a <= 40) && (30 <= b && b <= 40))
            {
                return true;
            }
            else if ((40 <= a && a <= 50) && (40 <= b && b <= 50))
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

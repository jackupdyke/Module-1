﻿namespace Exercises
{
    public partial class LogicalBranchingExercises
    {
        /*
         When squirrels get together for a party, they like to have cigars. A squirrel party is successful
         when the number of cigars is between 40 and 60, inclusive. Unless it is the weekend, in which case
         there is no upper bound on the number of cigars. Return true if the party with the given values is
         successful, or false otherwise.
         CigarParty(30, false) → false
         CigarParty(50, false) → true
         CigarParty(70, true) → true
         */
        public bool CigarParty(int cigars, bool isWeekend)
        {
            if (40 <= cigars && cigars <= 60)
            {
                return true;
            }
            else if (cigars > 60 && isWeekend == true)
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

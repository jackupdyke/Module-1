﻿namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return the count of the number of times that a substring length 2 appears in the string and
        also as the last 2 chars of the string, so "hixxxhi" yields 1 (we won't count the end substring).
        Last2("hixxhi") → 1
        Last2("xaxxaxaxx") → 1
        Last2("axxxaaxx") → 2
        */
        public int Last2(string str)
        {
            int count = 0;
            int length = str.Length;
            if (length < 3)
            {
                return 0;
            }

            
            {

                string lastTwo = str.Substring(length - 2, 2);

                for (int i = 0; i < length - 2; i++)
                {
                    if (lastTwo == str.Substring(i, 2))
                    {
                        count++;
                    }

                }
            }
            return count;
        }
    }
}

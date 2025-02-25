﻿namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a new string made of 3 copies of the last 2 chars of the original string. The string
        length will be at least 2.
        ExtraEnd("Hello") → "lololo"
        ExtraEnd("ab") → "ababab"
        ExtraEnd("Hi") → "HiHiHi"
        */
        public string ExtraEnd(string str)
        {

            return str.Substring(str.Length - 2, 2) + str.Substring(str.Length - 2, 2) + str.Substring(str.Length - 2, 2);
        }
    }
}

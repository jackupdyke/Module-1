﻿namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
        DoubleX("axxbb") → true
        DoubleX("axaxax") → false
        DoubleX("xxxxx") → true
        */
        public bool DoubleX(string str)
        {
            
            for (int i = 0; i < str.Length - 1; i++)
            {

                if (str[i] == 'x')
                {
                    if (str[i + 1] == 'x')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }


                
            }

            return false;
        }
}
}

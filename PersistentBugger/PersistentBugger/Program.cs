using System;

namespace PersistentBugger
{
    class Program
    {
        /*

         * Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence,
         * which is the number of times you must multiply the digits in num until you reach a single digit.

         For example:

         persistence(39) == 3 // because 3*9 = 27, 2*7 = 14, 1*4=4
                              // and 4 has only one digit

         persistence(999) == 4 // because 9*9*9 = 729, 7*2*9 = 126,
                               // 1*2*6 = 12, and finally 1*2 = 2

         persistence(4) == 0 // because 4 is already a one-digit number
         */
        static void Main(string[] args)
        {
            Console.WriteLine(Persistence(4));
        }
        public static int Persistence(long n)
        {
            string sval = n.ToString();
            int count = 0;

            while (sval.Length != 1)
            {
                count++;
                int result = Convert.ToInt32(sval[0].ToString());
                for (int i = 1; i < sval.Length; i++)
                {
                    result = result * Convert.ToInt32(sval[i].ToString());
                }
                sval = result.ToString();
               
            }
            return Convert.ToInt32(count);

        }
    }
}

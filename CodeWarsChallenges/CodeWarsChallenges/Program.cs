using System;
using System.Collections.Generic;

namespace CodeWarsChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            //rowSumOddNumbersMethod
            long n = 100000;
            long solution = rowSumOddNumbers(n);

            //

            //FriendOrFoe Method
            string[] people = 
            {
                "Mark",
                "Kevin",
                "Abieshan",
                "Ken",
                "JJ",
                "Mohammed",
            };
            foreach (string item in FriendOrFoe(people))
            {
                Console.WriteLine(item);
            }
            //
            
            Console.ReadKey();
            //FindMethod
            Random rand = new Random();
            int[] integers = { 2, 4, 0, 100, 4, 11, 2602, 36 }; //sould return 11 the only odd number
            int[] integers2 = { 160, 3, 1719, 19, 11, 13, -21 }; // Should return 160 the only even number
            Console.WriteLine(Find(integers2)); 
            //
        }

        private static long rowSumOddNumbers(long n)
        {
            //Given the triangle of consecutive odd numbers:
            //Calculate the row sums of this triangle from the row index(starting at index 1) e.g.:




        }

        public static int Find(int[] integers)
        {

            //You are given an array (which will have a length of at least 3, but could be very large) containing integers.
            //The array is either entirely comprised of odd integers or entirely comprised of even integers except for a single integer N.
            //    Write a method that takes the array as an argument and returns this "outlier" N.

            List<int> evenNumbers = new List<int>();
            List<int> unevenNumbers = new List<int>();

            foreach (int number in integers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    unevenNumbers.Add(number);
                }
            }
            if (evenNumbers.Count == 1)
            {
                return evenNumbers[0];
            }
            else if (unevenNumbers.Count == 1)
            {
                return unevenNumbers[0];
            }
            return -0;
        }
        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            //Make a program that filters a list of strings and returns a list with only your friends name in it.
            //If a name has exactly 4 letters in it, you can be sure that it has to be a friend of yours! Otherwise, you can be sure he's not...
            List<string> friends = new List<string>();
            foreach (string item in names)
            {
                if (item.Length == 4)
                {
                    friends.Add(item);
                }
            }
            return friends;

            //    return names.Where(x=>x.Length==4); //Solution from web, pretty short


        }

    }
}






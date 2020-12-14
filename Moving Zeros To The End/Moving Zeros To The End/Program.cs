using System;
using System.Linq;

namespace Moving_Zeros_To_The_End
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            Console.Clear();
            foreach (var item in MoveZeroes(new int[] { 1, 2, 0, 0, 0, 1, 0, 3, 0, 1 }))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            Console.Clear();
            foreach (var item in MoveZeroes(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                Console.WriteLine(item);
            }
        }
        public static int[] MoveZeroes(int[] arr)
        {
            int[] newArray = new int[arr.Length];
            int x = 0;

            for (int i = 0; i < arr.Length; i++, x++)
            {
                if (x >= arr.Length)
                {
                    break;
                }
                while (arr[x] == 0)
                {
                    x++;
                    if (x >= arr.Length)
                    {
                        return newArray;
                    }
                }

                newArray[i] = arr[x];
              
               
            }
            return newArray;

            //int zeroIndex = arr.Length - 1;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] == 0)
            //    {
            //        int tmp = arr[zeroIndex];                   
            //        arr[i] = tmp;
            //        arr[zeroIndex] = 0;
            //        zeroIndex = zeroIndex - 1;
            //    }
            //}
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}            
        } //My method

        public static int[] MoveZeroesOtherMethod(int[] arr)
        {
            // This solution makes use of C#'s behaviour with unassigned ints in arrays: They are 0 by default.
            // So we basically only have to create a new array with the same size, and write non-zero values
            // in their usual order. Simple.
            int[] zeroesAtEnd = new int[arr.Length];
            int currIndex = -1;
            foreach (int num in arr)
            {
                if (num != 0)
                {
                    currIndex++;
                    zeroesAtEnd[currIndex] = num;
                }
            }
            return zeroesAtEnd;
        }

        public static int[] MoveZeroesLinqMethod(int[] arr)
        {
            return arr.OrderBy(x => x == 0).ToArray();
        } //This is using linq 
    }
}

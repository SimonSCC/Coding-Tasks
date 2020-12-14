using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static List<int> SeatIds = new List<int>();
        static void Main(string[] args)
        {
            Program pgr = new Program();
            var lines = File.ReadAllLines("input.txt");
            string[] arr = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                arr[i] = lines[i];
            }

            pgr.FindRow(arr);
            Console.ReadKey();

            SeatIds.Sort();
            Console.WriteLine("\n\nHighest rowId: " + SeatIds[SeatIds.Count -1]);

            Part2();
        }

        private static void Part2()
        {
            SeatIds.RemoveAt(SeatIds.Count - 1);
            SeatIds.RemoveAt(0);
            List<int> tst = new List<int>();

            foreach (var item in SeatIds)
            {
                if (SeatIds.Contains(item + 1) && SeatIds.Contains(item -1))
                {
                    tst.Add(item);
                }
                else
                {
                    Console.WriteLine("else: " + item);
                }
            }
            foreach (var item in tst)
            {
                Console.WriteLine(item);
            }
        }

        public void FindRow(string[] arr)
        {
            foreach (var item in arr)
            {
                int max = 128; 
                int min = 0; 

                int Current = 128;

                int rowNr = 0;
                if (item == "")
                {
                    return;
                }
                for (int i = 0; i < 7; i++)
                {
                    //if (Current <= 0)
                    //{
                    //    Console.WriteLine(max - 1);
                    //}

                    Current = Current / 2;

                    if (item[i] == 'B') //Upper half
                    {
                        min += Current;
                    }
                    if (item[i] == 'F') //Lower half
                    {
                        max -= Current;
                    }
                }
                rowNr = max - 1;

                int CurrentCol = 8;

                int colMin = 0;
                int colMax = 7;

                for (int i = 7; i < 10; i++)
                {
                    CurrentCol = CurrentCol / 2;
                    

                    if (item[i] == 'R') //Upper 
                    {
                        colMin += CurrentCol;

                    }
                    if (item[i] == 'L') //Lower half
                    {
                        colMax -= CurrentCol;
                    }

                }
                int ColNr = colMax;
                int SeatID = rowNr * 8 + ColNr;
                Console.WriteLine("Row nr: " + rowNr);
                Console.WriteLine("Col nr: " + ColNr);
                Console.WriteLine("SeatId: " + SeatID);
                Console.WriteLine();

                SeatIds.Add(SeatID);                

            }

        }

        public static object BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        } //Inpsiration
    }


}

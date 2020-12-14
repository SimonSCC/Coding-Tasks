using System;
using System.Collections.Generic;
using System.IO;

namespace Day_9_Enconding_Error
{
    class Program
    {
        public static string[] raw;
        public static double[] lines;
        static void Main(string[] args)
        {
            double result = Part1();
            Console.Clear();
            Console.WriteLine("FinalResult: " + Part2(result)); 

        }

        private static double Part2(double result)
        {
            double total = 0;
            List<int> sequence = new List<int>(); //Index is saved


            for (int i = 0; i < lines.Length; i++)
            {
                total += lines[i];
                sequence.Add(i);
                if (total > result)
                {
                    int startOfSeq = sequence[0];
                    i = startOfSeq;
                    total = 0;
                    sequence = new List<int>();
                }
                if (total == result)
                {
                    List<double> seqResult = new List<double>();
                    foreach (var item in sequence)
                    {
                        seqResult.Add(lines[item]);
                        Console.WriteLine(lines[item]);
                    }
                    seqResult.Sort();
                    Console.ReadKey();
                    return seqResult[0] + seqResult[seqResult.Count - 1];
                }
            }
            return 0;

        }

        private static double Part1()
        {
            raw = File.ReadAllLines("input.txt");
            lines = Array.ConvertAll(raw, double.Parse);

            int preamble = 25;
            int toFind = preamble;

            for (int i = 0; i < lines.Length; i++)
            {
                bool found = false;

                for (int x = 0 + i; x < preamble + i; x++)
                {
                    if (found) break;
                    for (int y = 0 + i; y < preamble + i; y++)
                    {
                        if (lines[x] == lines[y])
                        {

                        }
                        else if (lines[x] + lines[y] == Convert.ToInt32(lines[toFind]))
                        {
                            Console.WriteLine(lines[toFind] + " follows rules: " + lines[x] + " + " + lines[y] + " is equals to " + lines[toFind]);
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Doens't follow rules: " + lines[toFind]);
                    Console.ReadKey();
                    return lines[toFind];
                }
                toFind++;
            }

            return 0;
        }
    }
}

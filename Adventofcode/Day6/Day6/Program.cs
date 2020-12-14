using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var Lines = File.ReadAllLines("test.txt");
            Part1(Lines);
            Console.ReadKey();
            Part2(Lines);



        }

        private static void Part2(string[] Lines)
        {
            int sum = 0;
            string questions = string.Empty;

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i] != "")
                {
                    if (questions.Length == 0)
                    {
                        for (int y = 0; y < Lines[i].Length; y++)
                        {
                            if (!questions.Contains(Lines[i][y]))
                            {
                                questions += Lines[i][y];
                            }
                        }
                    }
                    else
                    {
                        for (int x = 0; x < Lines[i].Length; x++)
                        {
                            if (!questions.Contains(Lines[i][x]))
                            {
                                questions.Trim(Lines[i][x]);
                            }
                        }
                    }

                }

                if (Lines[i] == "")
                {
                    sum += questions.Length;
                    questions = string.Empty;
                }

            }
            sum += questions.Length;
            questions = string.Empty;

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        private static void Part1(string[] Lines)
        {

            int sum = 0;
            string questions = string.Empty;

            foreach (var item in Lines)
            {
                if (item != "")
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (!questions.Contains(item[i]))
                        {
                            questions += item[i];
                        }
                    }
                }
                if (item == "")
                {
                    sum += questions.Length;
                    questions = string.Empty;
                }

            }
            sum += questions.Length;
            questions = string.Empty;

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}

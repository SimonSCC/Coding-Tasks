using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var Lines = File.ReadAllLines("input.txt");
            Part1(Lines);
            //Console.ReadKey();
            Part2Attempt2(Lines);



        }

        private static void Part2Attempt2(string[] lines)
        {
            //end result should be 6 on test.txt
            int sum = 0;
            bool removed = false;

            List<string> groups = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "") //Not new group
                {
                    groups.Add(lines[i]);
                }
                if (lines[i] == "" || i == lines.Length - 1)
                {
                    if (groups.Count == 1)
                    {
                        Console.WriteLine("Sum increased on line: " + i);
                        sum += groups[0].Length;
                        Console.WriteLine("Sum total: " + sum);
                    }
                    else
                    {
                        string firstString = groups[0];
                        for (int u = 0; u < firstString.Length; u++)
                        {
                            char test = firstString[u];
                            int amountRight = 0;
                            if (!removed)
                            {
                                groups.RemoveAt(0);
                                removed = true;

                            }

                            foreach (var items2 in groups)
                            {
                                if (items2.Contains(test)) //This solved it. Wow. I thought it had to be on the same index like code below
                                {
                                    amountRight++;
                                }
                                //if (u >= items2.Length)
                                //{
                                //    break;
                                //}
                                //if (items2[u] == test)
                                //{
                                //    amountRight++;
                                //}
                            }
                            if (amountRight == groups.Count)
                            {
                                Console.WriteLine("Sum increased on line: " + i);
                                sum++;
                                Console.WriteLine("Sum total: " + sum);
                            }                           
                        }
                        removed = false;
                    }
                    groups = new List<string>();
                }
            }
            Console.WriteLine(sum);

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

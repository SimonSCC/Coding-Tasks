using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args) //First intepretation
        {
            OtherInterpretation();
            Console.ReadKey();
            var lines = File.ReadLines("pass.txt");
            int passed = 0;
            int notPassed = 0;
            foreach (string item in lines)
            {
                string[] split = item.Split(":");
                string[] TimesAndLetter = split[0].Split(" ");
                int timesOfOccurance = 0;
                foreach (char letter in split[1])
                {
                    if (letter.ToString() == TimesAndLetter[1])
                    {
                        timesOfOccurance++;
                    }
                }
                string[] minMax = TimesAndLetter[0].Split("-");
                if (timesOfOccurance >= Convert.ToInt32(minMax[0]) && timesOfOccurance <= Convert.ToInt32(minMax[1]))
                {
                    passed++;
                }
                else
                {
                    notPassed++;
                }

            }
            Console.WriteLine("passed: " + passed);
            Console.WriteLine("not passed: " + notPassed);

        }

        private static void OtherInterpretation()
        {
            var lines = File.ReadLines("pass.txt");
            int passed = 0;
            int notPassed = 0;
            foreach (string item in lines)
            {
                string[] split = item.Split(":");
                //split[1] = split[1].TrimStart(' ');
                string[] TimesAndLetter = split[0].Split(" ");
                string[] ValOneValTwo = TimesAndLetter[0].Split("-");
                try
                {
                    if (split[1][Convert.ToInt32(ValOneValTwo[0])].ToString() == TimesAndLetter[1] && split[1][Convert.ToInt32(ValOneValTwo[1])].ToString() != TimesAndLetter[1])
                    {
                        passed++;
                        Console.WriteLine(split[1] + " is " + true);
                    }
                    else if (split[1][Convert.ToInt32(ValOneValTwo[1])].ToString() == TimesAndLetter[1] && split[1][Convert.ToInt32(ValOneValTwo[0])].ToString() != TimesAndLetter[1])
                    {
                        passed++;
                        Console.WriteLine(split[1] + " is " + true);
                    }
                    else
                    {
                        Console.WriteLine(split[1] + " is " + false);
                        notPassed++;
                    }

                   

                }
                catch (Exception)
                {
                    Console.WriteLine(split[1] + " is " + false);

                    notPassed++;
                }
              

            }
            Console.WriteLine("passed: " + passed);
            Console.WriteLine("not passed: " + notPassed);
        }
    }
}

using System;
using System.IO;

namespace Day1SonarSweep
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("inputstrings.txt");
            int[] linesAsInt = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                linesAsInt[i] = int.Parse(lines[i]);
            }

            Part1(linesAsInt);
            Part2(linesAsInt);

        }

        private static void Part2(int[] lines)
        {
            string[] results = new string[lines.Length];

            try
            {
                int lastSum = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        lastSum = lines[i] + lines[i + 1] + lines[i + 2];
                        continue;
                    }
                    int sum = lines[i] + lines[i + 1] + lines[i + 2];
                    if (lastSum > sum)
                        results[i] = "decreased";
                    else if (lastSum < sum)
                        results[i] = "increased";

                    lastSum = sum;

                }


            }
            catch (Exception e)
            {

                Console.WriteLine("No mor");
            }

            int largerThanThePreviousMeasurement = 0;

            foreach (string result in results)
            {
                if (result == "increased")
                {
                    largerThanThePreviousMeasurement++;
                }
            }

            Console.WriteLine("Part 2 " + largerThanThePreviousMeasurement);
        }



        private static void Part1(int[] lines)
        {

            string[] results = new string[lines.Length];

            int lastVal = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                int nowVal = lines[i];
                if (i == 0)
                {
                    lastVal = nowVal;
                    continue;
                }

                if (lastVal > nowVal)
                    results[i] = "decreased";
                else if (lastVal < nowVal)
                    results[i] = "increased";

                lastVal = nowVal;

            }

            int largerThanThePreviousMeasurement = 0;

            foreach (string result in results)
            {
                if (result == "increased")
                {
                    largerThanThePreviousMeasurement++;
                }
            }

            Console.WriteLine(largerThanThePreviousMeasurement);
        }
    }
}

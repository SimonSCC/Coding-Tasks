using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        int SourceJolts = 0;
        int differencesOf1 = 0;
        int differencesOf3 = 1;

        double Arrangements = 0;
        double finalValue = 0;

        Dictionary<double, double> Memo = new Dictionary<double, double>();

        static void Main(string[] args)
        {
            Program pr = new Program();

            List<Adapter> adapters = new List<Adapter>();


            string[] lines = File.ReadAllLines("input.txt");
            foreach (var item in lines)
            {
                if (item != "" || item != null)
                {
                    adapters.Add(new Adapter(Convert.ToInt32(item)));
                }
            }
            adapters.Sort();
            adapters.Add(new Adapter(adapters[adapters.Count - 1].Joltage + 3));

            //pr.Part1(adapters);
            //Console.ReadKey();
            pr.Part2(adapters);
            //Console.WriteLine(pr.Part2SecondTry(adapters));

        }
        //Below function needs to return 19208
        private double Part2SecondTry(List<Adapter> adapters, int i = 0) //Cool, doesn't have to supply method with i because it defaults to 0
        {
            if (Memo.ContainsKey(i))
            {
                return Memo[i];
            }

            if (i == adapters.Count - 1)
            {
                return 1;
            }

            double total = 0;

            if (!(i + 1 >= adapters.Count) && (adapters[i + 1].Joltage - adapters[i].Joltage) <= 3)
            {
                total += Part2SecondTry(adapters, i + 1);
            }

            if (!(i + 2 >= adapters.Count) && (adapters[i + 2].Joltage - adapters[i].Joltage) <= 3)
            {
                total += Part2SecondTry(adapters, i + 2);
            }

            if (!(i + 3 >= adapters.Count) && (adapters[i + 3].Joltage - adapters[i].Joltage) <= 3)
            {
                total += Part2SecondTry(adapters, i + 3);
            }

            Memo[i] = total;
            return total;
        }

        private void Part2(List<Adapter> adapters)
        {
            finalValue = adapters[adapters.Count - 1].Joltage + 3;
            AddSequence(0, adapters, 0);
            Console.WriteLine("Arrangements: " + Arrangements);
        }

        private void AddSequence(int val, List<Adapter> adapters, int index) //Recursive function
        {
            //if (Memo.ContainsKey(index))
            //{
            //    return Memo[index];
            //}
            //double total = 0;

            for (int i = index; i < adapters.Count; i++)
            {
                //if (Memo.ContainsKey(i))
                //{

                //    //Arrangements += Memo[i];
                //    return Memo[i];
                //}

                //if (val == finalValue)
                //{
                //    //Arrangements++;
                //    //return 1;
                //}

                if (adapters[i].Joltage - val <= 3) //If possible, proceed, else proceed to increment i
                {
                    for (int y = 1; y == 1; y++)
                    {
                        if (adapters.Count <= (i + y) || adapters[i + y].Joltage == adapters[i].Joltage)
                        {
                            break;
                        }
                        if (adapters[i + y].Joltage - val <= 3)
                        {
                            List<Adapter> newAdapters = adapters;

                            //Console.WriteLine(newAdapters[i + y].Joltage);
                            //Console.WriteLine(Arrangements);
                           
                            AddSequence(val, newAdapters, i + 1);
                            break;
                        }

                    }

                    adapters[i].TryConnectToSource(ref val);




                }

            }
            //Console.WriteLine("Sequence: ");
            //foreach (var item in adapters)
            //{
            //    Console.WriteLine(item.Joltage);
            //}
            //Console.WriteLine();

            //return 1;
            Arrangements++;
            //Memo[index] = total;
            //return total;
            //Memo[index + 1] = val;
            //return 1;
        }

        private void Part1(List<Adapter> adapters)
        {
            for (int i = 0; i < adapters.Count; i++)
            {
                int difference = adapters[i].TryConnectToSource(ref SourceJolts);
                if (difference == 3)
                {
                    differencesOf3++;
                }
                else if (difference == 1)
                {
                    differencesOf1++;
                }
                if (!adapters[i].Connected)
                {
                    Console.WriteLine("Did not use adapter: " + adapters[i]);

                }


            }


            Console.WriteLine("Differences of one : " + differencesOf1);
            Console.WriteLine("Differences of one three: " + differencesOf3);
            Console.WriteLine("Multiplied: " + differencesOf1 * differencesOf3);

        }
    }
}

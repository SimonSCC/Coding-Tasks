using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {

            var lines = File.ReadLines("input.txt");
            List<int> ints = new List<int>();
            foreach (var item in lines)
            {
                ints.Add(Convert.ToInt32(item));
            }

            for (int i = 0; i < ints.Count; i++)
            {
                for (int x = 0; x < ints.Count; x++)
                {
                    for (int b = 0; b < ints.Count; b++)
                    {
                        if (ints[i] + ints[x] + ints[b] == 2020)
                        {
                            Console.WriteLine(ints[i] * ints[x] * ints[b]);

                        }
                    }
                   
                }
            }
        }
    }
}

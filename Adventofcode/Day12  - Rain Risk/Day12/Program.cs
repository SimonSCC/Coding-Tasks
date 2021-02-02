using Day12.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            StartPart1();
        }

        private static void StartPart1()
        {
            List<Instruction> allInstructs = new List<Instruction>();

            string[] lines = File.ReadAllLines("test1.txt");
            foreach (string line in lines)
            {
                int number = int.Parse(line.Substring(1));
                Instruction intruction = new Instruction(line[0].ToString(), number);
                allInstructs.Add(intruction);

            }

            Console.WriteLine("Checking");

            Ship mainShip = new Ship();

        }
    }
}

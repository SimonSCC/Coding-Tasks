using System;
using System.IO;
using System.Numerics;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("trees.txt");
            Console.WriteLine(CountingTreesProblem(lines, 1, 1));
            Console.WriteLine(CountingTreesProblem(lines, 3, 1));
            Console.WriteLine(CountingTreesProblem(lines, 5, 1));
            Console.WriteLine(CountingTreesProblem(lines, 7, 1));
            Console.WriteLine(CountingTreesProblem(lines, 1, 2));
            Console.ReadKey();

            string[] stringLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                stringLines[i] = lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i]
                    + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i]
                    + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i] + lines[i];
            }
            char[,] charArr = new char[lines.Length, stringLines[0].Length ];
            for (int i = 0; i < stringLines.Length; i++)
            {
                for (int y = 0; y < stringLines[i].Length; y++)
                {
                    charArr[i, y] = stringLines[i][y];
                }
            }
            //Below is to write 

            //for (int x = 0; x < stringLines.Length; x++)
            //{
            //    for (int i = 0; i < stringLines[x].Length; i++)
            //    {
            //        Console.Write(charArr[x, i]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            int countOfTrees31 = 0;
            int xArr = 0;

            for (int y = 1; y < stringLines.Length; y = y + 1)
            {
                xArr = xArr + 3;
                //if (xArr > lines[0].Length)
                //{
                //    xArr = 2;
                //}
                if (charArr[y, xArr] == '#')
                {
                    countOfTrees31++;
                }
            }
            int countOfTrees11 = 0;
            xArr = 0;

            for (int y = 1; y < stringLines.Length; y = y + 1)
            {
                xArr = xArr + 1;
            
                if (charArr[y, xArr] == '#')
                {
                    countOfTrees11++;
                }
            }

            int countOfTrees51 = 0;
            xArr = 0;

            for (int y = 1; y < stringLines.Length; y = y + 1)
            {
                xArr = xArr + 5;
             
                if (charArr[y, xArr] == '#')
                {
                    countOfTrees51++;
                }
            }

            int countOfTrees71 = 0;
            xArr = 0;

            for (int y = 1; y < stringLines.Length; y = y + 1)
            {
                xArr = xArr + 7;
            
                if (charArr[y, xArr] == '#')
                {
                    countOfTrees71++;
                }
            }

            int countOfTrees12 = 0;
            xArr = 0;

            for (int y = 2; y < stringLines.Length; y = y + 2) //Needs to be 44 
            {
                
                xArr = xArr + 1;
              
                if (charArr[y, xArr] == '#')
                {
                    countOfTrees12++;
                }
            }
            Console.WriteLine(countOfTrees11);
            Console.WriteLine(countOfTrees31);
            Console.WriteLine(countOfTrees51);
            Console.WriteLine(countOfTrees71);
            Console.WriteLine(countOfTrees12);
            BigInteger partialResult = countOfTrees31 * countOfTrees11 * countOfTrees51;
            BigInteger result = partialResult * countOfTrees71 * countOfTrees12;
            Console.WriteLine(result);
           



        }
        public static int CountingTreesProblem(string[] inputLines, int rightAdder, int downAdder) //Other guy mehtods. Didn't use it. Didn't cheats
        {
            char tree = '#';
            int treesCounter = 0;
            int currPosition = 0;

            for (int i = 0; i < inputLines.Length; i += downAdder)
            {
                if (i == 0) continue;
                string line = inputLines[i];
                currPosition += rightAdder;

                while (currPosition >= line.Length)
                {
                    line += line; // line expands when necessary
                }

                if (line[currPosition] == tree) treesCounter++;
            }

            return treesCounter;
        }
    }
}

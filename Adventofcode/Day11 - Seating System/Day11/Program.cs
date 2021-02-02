using System;
using System.Collections.Generic;
using System.IO;

namespace Day11
{
    class Program
    {
        const char Empty = 'L';
        const char Occupied = '#';
        const char Floor = '.';
        public static bool didChange = false;

        static void Main(string[] args)
        {
            /*
             * If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied.
            If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
            Otherwise, the seat's state does not change.
             */



            string[] lines = File.ReadAllLines("input.txt");
            //string[] firstRun = RunProgram(lines);
            // foreach (var item in firstRun)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine();
            // string[] secondRun = RunProgram(firstRun);
            // foreach (var item in secondRun)
            // {
            //     Console.WriteLine(item);
            // }
            // Console.WriteLine();
            // Console.ReadKey();
            string[] temp = lines;
            while (true)
            {
                temp = RunProgram(temp);
                foreach (var item in temp)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                if (!didChange)
                {
                    break;
                }
                didChange = false;

            }
            Console.WriteLine("Finalized");
            int total = 0;
            foreach (var item in temp)
            {
                foreach (var seat in item)
                {
                    if (seat == Occupied)
                    {
                        total++;
                    }
                }                
            }
            Console.WriteLine("Counted : " + total + " Occupied seats..");
            Console.ReadLine();
        }

        private static string[] RunProgram(string[] lines)
        {
            List<string> Cache = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                for (int y = 0; y < lines[i].Length; y++)
                {
                    if (lines[i][y] == Floor)
                    {
                        continue;
                    }
                    int NumberOfOccupiedSeats = 0;
                    bool skipTop = false;
                    bool skipBot = false;
                    //Check for eight adjacent tiles
                    if (i == 0) // if first row skip upper check
                    {
                        skipTop = true;
                    }

                    if (i == lines.Length - 1) // if last row skip check row below
                    {
                        skipBot = true;
                    }


                    NumberOfOccupiedSeats += CheckAdjacentSeats(ref lines, y, i, skipTop, skipBot);

                    if (lines[i][y] == Empty && NumberOfOccupiedSeats == 0)
                    {
                        string pos = i + "-" + y;
                        Cache.Add(pos);
                        didChange = true;
                    }
                    if (lines[i][y] == Occupied && NumberOfOccupiedSeats >= 4)
                    {
                        string pos = i + "-" + y;
                        Cache.Add(pos);
                        didChange = true;

                    }



                }
            }
            for (int x = 0; x < lines.Length; x++)
            {
                for (int c = 0; c < lines[x].Length; c++)
                {
                    if (Cache.Contains(x + "-" + c))
                    {
                        char[] lineAsCharArr = lines[x].ToCharArray();
                        if (lineAsCharArr[c] == Occupied)
                        {
                            lineAsCharArr[c] = Empty; //Changes to empty
                           
                        }
                        else
                        {
                            lineAsCharArr[c] = Occupied; //Changes to occupied
                           
                        }
                        string newLine = new string(lineAsCharArr);
                        lines[x] = newLine;
                    }
                }

            }
            return lines;
        }

        private static int CheckAdjacentSeats(ref string[] lines, int y, int i, bool skipTop, bool skipBot)
        {
            int totalOccupied = 0;

            if (y + 1 < lines[i].Length) //if seat exists on the right side
            {
                if (lines[i][y + 1] == Occupied)
                {
                    totalOccupied++;
                }
            }

            if (y - 1 >= 0) // if -1 then adjacent seat is empty because it is non existant
            {
                if (lines[i][y - 1] == Occupied)
                {
                    totalOccupied++;
                }
            }

            if (!skipTop)
            {
                if (y - 1 >= 0) // if -1 then adjacent seat is empty because it is non existant
                {
                    if (lines[i - 1][y - 1] == Occupied)
                    {
                        totalOccupied++;
                    }
                }
                if (lines[i - 1][y] == Occupied)
                {
                    totalOccupied++;
                }
                if (y + 1 < lines[i].Length) //if seat exists on the right side
                {
                    if (lines[i - 1][y + 1] == Occupied)
                    {
                        totalOccupied++;
                    }
                }
            }

            if (!skipBot)
            {
                if (y - 1 >= 0) // if -1 then adjacent seat is empty because it is non existant
                {
                    if (lines[i + 1][y - 1] == Occupied)
                    {
                        totalOccupied++;
                    }
                }
                if (lines[i + 1][y] == Occupied)
                {
                    totalOccupied++;
                }
                if (y + 1 < lines[i].Length) //if seat exists on the right side
                {
                    if (lines[i + 1][y + 1] == Occupied)
                    {
                        totalOccupied++;
                    }
                }
            }

            return totalOccupied;
        }
    }
}

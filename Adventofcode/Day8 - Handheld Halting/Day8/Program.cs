using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            List<int> IndexOfNops = new List<int>();
            List<int> IndexOfJmps = new List<int>();
            //Part2Attempt
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("nop"))
                {
                    IndexOfNops.Add(i);
                }
                if (lines[i].Contains("jmp"))
                {
                    IndexOfJmps.Add(i);
                }
            }
            for (int x = 0; x < IndexOfNops.Count; x++)
            {
                string[] newLines = new string[lines.Length];
                lines.CopyTo(newLines, 0);

                newLines[IndexOfNops[x]] = newLines[IndexOfNops[x]].Replace("nop", "jmp");
                Console.WriteLine("Running replaced nop with jmp on line " + x);
                Part1(newLines);
                Console.WriteLine();
            }
            Console.ReadLine();

            for (int i = 0; i < IndexOfJmps.Count; i++)
            {
                string[] newLines = new string[lines.Length];
                lines.CopyTo(newLines, 0);

                newLines[IndexOfJmps[i]] = newLines[IndexOfJmps[i]].Replace("jmp", "nop");
                Console.WriteLine("Running replaced jmp with nop on line " + i);
                Part1(newLines);
                Console.WriteLine();
            }
            Console.ReadLine();

            //
            //Part1(lines);
        }

        private static void Part1(string[] lines)
        {
            int Accumulator = 0;

            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string unique = i + ":" + "f:" + lines[i]; //f for false
                newLines[i] = unique;
            }
                   
         
            for (int i = 0; i < newLines.Length; i++)
            {
                if (newLines[i].Contains("acc"))
                {
                    string[] split = newLines[i].Split(':');
                    string[] cmd = split[2].Split(' ');

                    if (split[1] == "t")
                    {
                        Console.WriteLine("Aborted already run cmd " + newLines[i]);
                        break;
                    }
                    else
                    {
                        newLines[i] = i + ":" + "t:" + split[2];

                        Accumulator += Convert.ToInt32(cmd[1]);
                    }

                }
                if (newLines[i].Contains("nop"))
                {
                    string[] split = newLines[i].Split(':');
                    string[] cmd = split[2].Split(' ');

                    if (split[1] == "t")
                    {
                        Console.WriteLine("Aborted already run cmd " + newLines[i]);
                        break;
                    }
                    else
                    {
                        if (i + Convert.ToInt32(cmd[1]) >= newLines.Length -1)
                        {
                            Console.WriteLine(newLines[i] + " Change here nop ");
                        }
                        newLines[i] = i + ":" + "t:" + split[2];
                    }
                }
                if (newLines[i].Contains("jmp"))
                {
                    string[] split = newLines[i].Split(':');
                    string[] cmd = split[2].Split(' ');

                    if (split[1] == "t")
                    {
                        Console.WriteLine("Aborted already run cmd " + newLines[i]);
                        break;
                    }
                    else
                    {
                        if (i + 1 == newLines.Length - 1)
                        {
                            Console.WriteLine(newLines[i] + " Change here jump ");
                        }
                        newLines[i] = i + ":" + "t:" + split[2];

                        i += Convert.ToInt32(cmd[1]) -1; //minus oen cuz arrays start at 0
                    }
                }
            }
            Console.WriteLine(Accumulator);
        }
    }
    
}

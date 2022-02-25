using System;
using System.IO;

namespace Day2Dive
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            Submarine sub = new Submarine();

            Move(lines, sub);
        }

        private static void Move(string[] lines, Submarine sub)
        {
            foreach (string direction in lines)
            {
                string[] splitString = direction.Split(' ');
                switch (splitString[0])
                {
                    case "down":
                        sub.GoUpOrDown(int.Parse(splitString[1]));
                        break;

                    case "forward":
                        sub.GoBackOrFoward(int.Parse(splitString[1]));

                        break;

                    case "up":
                        sub.GoUpOrDown(int.Parse("-" + splitString[1]));

                        break;
                       
                    default:
                        break;
                }
            }
            Console.WriteLine("Sub is at this position: " + sub.Pos);
            Console.WriteLine("Multiplyed pos: " + sub.Pos.XPos * sub.Pos.YPos);
        }
    }
}

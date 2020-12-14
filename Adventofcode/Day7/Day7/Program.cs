using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            //topologically 
            var lines = File.ReadAllLines("input.txt");          
            string myBag = "shiny gold";
            int totalContain = 0;


            Dictionary<string, string> allBags = new Dictionary<string, string>();
            Dictionary<string, string> BagsThatDirectlyContainMyBag = new Dictionary<string, string>();
            Dictionary<string, string> BagsThatContainBagsThatContainMyBag = new Dictionary<string, string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] keyValue = lines[i].Split("contain");
                allBags.Add(keyValue[0], keyValue[1]);
            }

            //Part1(allBags);
            Part2(allBags);
        }

        private static void Part1(Dictionary<string,string> lines)
        {
            int total = 0;
            string myBag = "shiny gold";

            Dictionary<string, string> allBags = lines;
            Dictionary<string, string> BagsThatEventuallyContainMyBag = new Dictionary<string, string>();
           
            bool shouldRepeat = true;

            foreach (var item in allBags)
            {
                if (item.Value.Contains(myBag))
                {
                    total++;
                    BagsThatEventuallyContainMyBag.Add(item.Key.Split("bags")[0], item.Value);
                }
            }

            while (shouldRepeat)
            {
                int CountOfBagsStart = BagsThatEventuallyContainMyBag.Count;

                foreach (var item in allBags)
                {
                    foreach (var bag in BagsThatEventuallyContainMyBag)
                    {
                        if (item.Value.Contains(bag.Key))
                        {
                            if (!BagsThatEventuallyContainMyBag.ContainsKey(item.Key.Split("bags")[0]))
                            {
                                BagsThatEventuallyContainMyBag.Add(item.Key.Split("bags")[0], item.Value);
                                total++;
                            }
                            break;
                        }

                    }
                }
                if (CountOfBagsStart == BagsThatEventuallyContainMyBag.Count)
                {
                    shouldRepeat = false;
                }
            }
            Console.WriteLine(total);
            Console.ReadKey();

        }

        private static void Part2(Dictionary<string,string> lines)
        {
            int total = 0;
            string myBag = "shiny gold bags ";

            Dictionary<string, string> allBags = lines;

            string ShinyGoldLine = allBags.Where(x => x.Key == myBag).First().Value;
            Console.WriteLine(ShinyGoldLine);



            string[] bags = ShinyGoldLine.Split(',');


            for (int i = 0; i < bags.Length; i++)
            {
                bags[i] = bags[i].Trim();
                string test = bags[i].TrimStart(bags[i][0]).Trim();
                total += Convert.ToInt32(bags[i][0].ToString());
            }
            total += bags.Length;

           
            Console.WriteLine(total);



        }
    }
}

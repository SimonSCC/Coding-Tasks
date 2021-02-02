using System;
using System.Collections.Generic;

namespace WhereMyAnagramsAt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> anagrams = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                for (int y = 0; y < word.Length; y++)
                {
                    if (word.Contains(word[y]))
                    {

                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}

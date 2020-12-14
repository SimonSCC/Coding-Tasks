using System;
using System.Linq;

namespace ReplaceWithAlphabetPosition
{
    class Program
    {
        /*
         Welcome.
        In this kata you are required to, given a string, replace every letter with its position in the alphabet.
        If anything in the text isn't a letter, ignore it and don't return it.

        "a" = 1, "b" = 2, etc.

        Example
        Kata.AlphabetPosition("The sunset sets at twelve o' clock.")
        Should return "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11" (as a string)
         
         */
        static void Main(string[] args)
        {
            Console.WriteLine(AlphabetPosition("The sunset sets at twelve o' clock."));
        }

        public static string AlphabetPosition(string text)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            char[] textChar = text.ToLower().ToCharArray();
            string newText = "";
            int occurance = 0;
            for (int i = 0; i < textChar.Length; i++)
            {
                occurance = alphabet.IndexOf(textChar[i]);
                if (occurance != -1)
                {
                    newText += occurance + 1 + " ";
                }
            }

            return newText.Trim();
        } //Mymethod

        public static string AlphabetPosition2(string text) //Another method using linq
        {
            return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(x => x - 'a' + 1));
        }
    }
}

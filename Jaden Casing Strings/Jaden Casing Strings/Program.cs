using System;
using System.Globalization;

namespace Jaden_Casing_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase1 = "my name is Simon and I like eXtreme programming";
            Console.WriteLine(phrase1.ToJadenCase()); //extension method 

            Console.WriteLine(phrase1.AnotherSolution());
        }

       
    }

    public static class JadenCast
    {
        public static string ToJadenCase(this string phrase) //extension method, keyword this.
        {
            string[] splitted = phrase.Split(' ');

            string JadenCasePhrase = string.Empty;
            foreach (string word in splitted)
            {
                char[] charWord = word.ToCharArray();
                string jadenWord = string.Empty;

                charWord[0] = Char.ToUpper(charWord[0]);

                foreach (char character in charWord) //Converts to string. Must be a easier method.
                {
                    jadenWord += character;
                }

                JadenCasePhrase += jadenWord + " ";
            }



            return JadenCasePhrase.Trim();
        }


        public static string AnotherSolution(this string phrase)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        }
    }
}

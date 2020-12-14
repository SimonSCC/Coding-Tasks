using System;

namespace DetectPangram
{
    class Program
    {

        //A pangram is a sentence that contains every single letter of the alphabet at least once.
        //For example, the sentence "The quick brown fox jumps over the lazy dog" is a pangram,
        //because it uses the letters A-Z at least once (case is irrelevant).
        //Given a string, detect whether or not it is a pangram.Return True if it is, False if not.Ignore numbers and punctuation.
        //const int[] ASCIIAlphabet = {97, 98, 99, 100 };
        static void Main(string[] args)
        {
            Console.WriteLine(IsPangram("The quick brown fox jumps over the lazy dog."));
        }

        public static bool IsPangram(string str)
        {
            //ASCII Alphabet is numbers from 97 to 122

            char[] sentence = str.ToLower().ToCharArray();
            int asciinr = 97;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == asciinr)
                {
                    asciinr++;
                    i = -1;
                    if (asciinr == 122)
                    {
                        return true;
                    }
                }               
            }
            return false;
        }
    }
}


//if (sentence[i] >= 97 && sentence[i])
//{

//}
using System;
using System.Linq;

namespace Find_The_Odd_Int
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.start();
        }

        private void start()
        {
            int[] seq = new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 };
            Kata kat = new Kata();
            Console.WriteLine(kat.find_it(seq));
            Console.WriteLine(kat.UsingXOR(seq));

            Console.ReadKey();
            kat.DemonstrateXOR();
        }
    }
    class Kata
    {
        public int find_it(int[] seq)
        {
            for (int i = 0; i < seq.Length; i++)
            {               
                if (seq.Count(x => x == seq[i]) % 2 != 0)                
                    return seq[i];                
            }
            return 0;
        }

        public int UsingXOR(int[] seq)
        {
            int found = 0;

            foreach (var num in seq)
            {
                found ^= num;
            }

            return found;
        }

        public void DemonstrateXOR()
        {
            Console.WriteLine(true ^ true); //false
            Console.WriteLine(true ^ false); //true
            Console.WriteLine(false ^ true); //true
            Console.WriteLine(false ^ false); //false
            Console.ReadKey();
        }
    }
}

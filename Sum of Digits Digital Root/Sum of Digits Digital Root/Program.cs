using System;

namespace Sum_of_Digits_Digital_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.Start();
        }

        public void Start()
        {
            Number number = new Number();

            long nr = 99999999998833939;

            Console.WriteLine(number.DigitalRoot(nr));
            Console.WriteLine(number.OtherMethod(nr));
        }
    }
    public class Number
    {
        public int DigitalRoot(long n)
        {
            while (n.ToString().Length != 1)
            {
                var chararr = n.ToString().ToCharArray();
                int totalNumber = 0;
                foreach (var item in chararr)
                {
                    totalNumber += Convert.ToInt32(item.ToString());
                }
                n = totalNumber;
            }
            return (int)n;
        }
        public int OtherMethod(long n)
        {
            return (int)(1 + (n - 1) % 9);
        }
    }



}

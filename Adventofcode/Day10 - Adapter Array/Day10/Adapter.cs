using System;
using System.Collections.Generic;
using System.Text;

namespace Day10
{
    class Adapter : IComparable
    {
        public int Joltage { get; set; }
        public bool Connected { get; set; } = false;

        public Adapter(int joltage)
        {
            Joltage = joltage;
        }

        public override string ToString()
        {
            return this.Joltage.ToString();
        }

        public int TryConnectToSource(ref int sourceJolts)
        {
            int difference = this.Joltage - sourceJolts;

            if (difference <= 3)
            {
                //Console.WriteLine("Connected: " + this);
                sourceJolts = this.Joltage;
                this.Connected = true;
                return difference;
            }
            else
            {
                return 0;
            }
        }
        public int CompareTo(object obj)
        {   
            Adapter otherAdapter = obj as Adapter;
            if (otherAdapter == null)
            {
                return -1;
            }

            if (this.Joltage == otherAdapter.Joltage)
            {
                return 0;
            }
            else if (this.Joltage > otherAdapter.Joltage)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //Override tostring
    }
}

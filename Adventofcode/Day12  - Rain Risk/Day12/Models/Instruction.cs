using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12.Models
{
    public class Instruction
    {
        public string Letter { get; set; }
        public int Number { get; set; }

        public Instruction(string letter, int num)
        {
            Letter = letter;
            Number = num;
        }
    }


}

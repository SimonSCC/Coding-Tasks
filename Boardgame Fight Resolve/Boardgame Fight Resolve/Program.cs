using Boardgame_Fight_Resolve.Models;
using System;

namespace Boardgame_Fight_Resolve
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static char FightResolve(BoardPiece attacker, BoardPiece defender)
        {
            if (Char.IsLower(attacker.CharType) && Char.IsUpper(defender.CharType))
            {
                if (Char.ToLower(attacker.CharType) == 'a' && Char.ToLower(defender.CharType) == 's') //if attacker is archer and defender is swordsman. Attacker wins 
                {
                    return attacker.CharType;
                }
                if (attacker.CharType == 's' && defender.CharType == 'p') //if attc is sword vs pike, sword win
                {
                    return attacker.CharType;
                }
                if (attacker.CharType == 'p' && defender.CharType == 'k') //if attc is pike and def is cavaly pike wins
                {
                    return attacker.CharType;
                }
                if (attacker.CharType == 'k' && defender.CharType == 'a') //if attc is cavalry and def is archer, cavalry wins
                {
                    return attacker.CharType;
                }





            }
            else
            {
                return 'E';
            }
        }
    }
}


//player 1: lowercase
//p = Pikeman, k = cavalry, a = archer, s = swordsman
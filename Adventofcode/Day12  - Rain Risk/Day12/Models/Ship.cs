using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12.Models
{
    public class Ship
    {
        public int EastWest { get; set; }
        public int NorthSouth { get; set; }
        public Direction Heading { get; set; }
        public int CurrentDegrees {get; set; }

        public Ship()
        {
            EastWest = 0;
            NorthSouth = 0;
            Heading = Direction.East;
        }

        public void Foward(int amount) //Move foward by the given value in the direction the ship is currently facing
        {
            if (Heading == Direction.East) //plus value if east
            {
                EastWest += amount;
            }
            if (Heading == Direction.West) //minus value if west
            {
                EastWest -= amount;
            }
            if (Heading == Direction.North) //Plus value if north
            {
                NorthSouth += amount;
            }
            if (Heading == Direction.South) //Minus value if south
            {
                NorthSouth -= amount;
            }
        }

        public void GoInDirection(Direction dir, int amount)
        {
            if (dir == Direction.East) //plus value if east
            {
                EastWest += amount;
            }
            if (dir == Direction.West) //minus value if west
            {
                EastWest -= amount;
            }
            if (dir == Direction.North) //Plus value if north
            {
                NorthSouth += amount;
            }
            if (dir == Direction.South) //Minus value if south
            {
                NorthSouth -= amount;
            }
        }

        public void Left(int degrees) //Turn left for certain degrees and change where the ship is facing
        {
            int currentDirFace = (int)Heading;
            CurrentDegrees -= degrees;


            
            if (currentDirFace == 0)
            {
                Heading = (Direction)3; //Same as Direction.South
            }
            else
            {
                Heading = (Direction)currentDirFace - 1; //Goes left
                Foward(amount); //Goes foward
            }
        }

        public void Right(int amount) //Changes the direction the ship is facing
        {
            int currentDirFace = (int)Heading;
            if (currentDirFace == 3)
            {
                Heading = (Direction)0; //Same as Direction.South
            }
            else
            {
                Heading = (Direction)currentDirFace + 1; //Goes Right
                Foward(amount); //Goes foward
            }
        }

    }
    public enum Direction
    {
        West,
        North,
        East,
        South,
    }


}

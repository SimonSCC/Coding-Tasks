namespace Day2Dive
{
    internal class Submarine
    {
        public Position Pos { get; set; }
        public Submarine()
        {
            Pos = new Position()
            {
                XPos = 0,
                YPos = 0,
                Aim = 0
            };
        }

        public void GoBackOrFoward(int amount)
        {
            Pos.XPos += amount;
            Pos.YPos += Pos.Aim * amount;
        }

        public void GoUpOrDown(int amount)
        {
            //If increase depth "down"
            //if (amount > 0)
            Pos.Aim += amount;


            //Pos.YPos += amount;
        }


    }
}
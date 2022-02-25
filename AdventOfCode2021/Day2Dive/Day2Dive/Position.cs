namespace Day2Dive
{
    public class Position
    {
        public int YPos { get; set; }
        public int XPos { get; set; }
        public int Aim { get; set; }

        public override string ToString()
        {
            return "Y: " + YPos.ToString() + " X: " + XPos.ToString() + " Aim: " + Aim.ToString();
        }
    }
}
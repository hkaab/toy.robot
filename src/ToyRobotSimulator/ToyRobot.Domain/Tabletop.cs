namespace ToyRobot.Domain
{
    public class Tabletop
    {
        public Tabletop(ushort rows, ushort cols)
        {
            Rows = rows;
            Cols = cols;
        }

        public Tabletop()
        {

        }
        public ushort Rows { get; set; }
        public ushort Cols { get; set; }    
    }
}

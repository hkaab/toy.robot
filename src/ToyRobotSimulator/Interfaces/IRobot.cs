namespace ToyRobot.Interfaces
{
    public interface IRobot
    {
        public bool Place(string param);
        public bool Move();
        public bool Left();
        public bool Right();
        public string Report();
    }
}
